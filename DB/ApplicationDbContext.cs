using Microsoft.EntityFrameworkCore;
using NetCrud2.Models;
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
    }
}
