using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Response;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Net;


namespace NetCrud2.DB
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration
            modelBuilder.Entity<Buyer>(builder =>
            {
                builder.ToTable("Buyer");
                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id).IsRequired().HasColumnType("VARCHAR2(36 char)").HasMaxLength(36);
                builder.Property(o => o.Name).IsRequired().HasColumnType("VARCHAR2(255 char)").HasMaxLength(255);
                builder.Property(o => o.PaymentMethod).IsRequired().HasColumnType("VARCHAR2(255 char").HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(buider =>
            {
                buider.ToTable("Order");
                buider.HasKey(o => o.Id);
                buider.Property(o => o.Id).IsRequired().HasColumnType("VARCHAR2(36 char)").HasMaxLength(36);
                buider.Property(o => o.CreateDate).IsRequired().HasColumnType("TIMESTAMP");
                buider.Property(o => o.Status).IsRequired().HasColumnType("NUMBER(10)");
                buider.Property(o => o.Address).IsRequired().HasColumnType("VARCHAR2(255 char)");
                buider.Property(o => o.BuyerId).HasColumnType("VARCHAR2(36 char)");
            });

            modelBuilder.Entity<OrderItem>(builder => 
            {
                builder.ToTable("OrderItem");
                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id).IsRequired().HasColumnType("VARCHAR2(36 char)").HasMaxLength(36);
                builder.Property(o => o.Units).IsRequired().HasColumnType("VARCHAR2(255 char)").HasMaxLength(255);
                builder.Property(o => o.UnitsPrice).IsRequired().HasColumnType("VARCHAR2(255 char)").HasMaxLength(255);
                builder.Property(o => o.OrderId).HasColumnType("VARCHAR2(36 char)").HasMaxLength(36);
                builder.Property(o => o.ProductId).HasColumnType("VARCHAR2(36 char)").HasMaxLength(36);
            });
                
            // Seed data
            Buyer[] buyerArr = new Buyer[100];
            Order[] orderArr = new Order[100];
            OrderItem[] orderItemsArr = new OrderItem[100];

            seedData(buyerArr, orderArr, orderItemsArr);

            modelBuilder.Entity<Buyer>().HasData(buyerArr);
            modelBuilder.Entity<Order>().HasData(orderArr);
            modelBuilder.Entity<OrderItem>().HasData(orderItemsArr);

            // object hứng result query
            modelBuilder.Entity<FindOrderResponse>().HasNoKey();

            base.OnModelCreating(modelBuilder);

        }

        private void seedData(Buyer[] buyerArr, Order[] orderArr, OrderItem[] orderItemsArr)
        {
            for (int i = 0; i < 100; i++)
            {
                buyerArr[i] = new Buyer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Buyer " + (i+1),
                    PaymentMethod = "Payment " + (i+1)
                };
                orderArr[i] = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now,
                    Status = 1,
                    Address = "Address " + (i + 1),
                    BuyerId = buyerArr[i].Id
                };
                orderItemsArr[i] = new OrderItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    Units = (i + 100).ToString(),
                    UnitsPrice = (i + 200).ToString(),
                    OrderId = orderArr[i].Id,
                    ProductId = Guid.NewGuid().ToString()
                };
            }
        }

        public FindOrderResponse findOrderCustom(string paymentMethod, DateTime start, DateTime end)
        {
            int[] statusArr = Utils.ConvertPaymentMethod.convertPaymentMethodStrToStatusOrder(paymentMethod);
            
            FindOrderResponse response = new FindOrderResponse();

            string connectString = "User Id=sa;Password=123456;Data Source=localhost:1521/mypdb;";

            using (var connection = new OracleConnection(connectString))
            {
                connection.Open(); // Mở kết nối
                using (var command = new OracleCommand("TESTPROCEDURE", connection))
                {
                    // Tham số IN
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("p_status1", OracleDbType.Int32).Value = statusArr[0];
                    command.Parameters.Add("p_status2", OracleDbType.Int32).Value = statusArr[1];
                    command.Parameters.Add("p_start", OracleDbType.TimeStamp).Value = start;
                    command.Parameters.Add("p_end", OracleDbType.TimeStamp).Value = end;

                    // Tham số OUT
                    var o_order_count = new OracleParameter("o_order_count", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    var o_buyer_count = new OracleParameter("o_buyer_count", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    var o_total_payment = new OracleParameter("o_total_payment", OracleDbType.Decimal) { Direction = ParameterDirection.Output };
                    var o_max_payment_buyer = new OracleParameter("o_max_payment_buyer", OracleDbType.Varchar2) { Direction = ParameterDirection.Output };
                    var o_min_payment_buyer = new OracleParameter("o_min_payment_buyer", OracleDbType.Varchar2) { Direction = ParameterDirection.Output };

                    // Add các tham số OUT vào command
                    command.Parameters.Add(o_order_count);
                    command.Parameters.Add(o_buyer_count);
                    command.Parameters.Add(o_total_payment);
                    command.Parameters.Add(o_max_payment_buyer);
                    command.Parameters.Add(o_min_payment_buyer);

                    // Thực thi
                    command.ExecuteNonQuery();

                    var x1 = o_order_count.Value.ToString();
                    var x2 = o_buyer_count.Value.ToString();
                    var x3 = o_total_payment.Value.ToString();
                    var x4 = o_min_payment_buyer.Value.ToString();
                    var x5 = o_max_payment_buyer.Value.ToString();

                    // Gán result OUT cho response
                    response.countOrderId = Convert.ToInt32(o_order_count.Value);
                    response.countBuyerUsedPaymentMethod = Convert.ToInt32(o_buyer_count.Value);
                    response.moneyTotal = Convert.ToDecimal(o_total_payment.Value);
                    response.buyerUsedMin = o_min_payment_buyer.Value.ToString();
                    response.buyerUsedMax = o_max_payment_buyer.Value.ToString();
                   
                }    
            }

            return response;

        }
    }
}
