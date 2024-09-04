using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Models;
using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Generics;

namespace NetCrud2.Mapper.Impl
{
    public class OrderMapper : IOrderMapper
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Buyer> _dbSetBuyer;

        public OrderMapper(ApplicationDbContext db)
        {
            _db = db;
            _dbSetBuyer = db.Buyers;
        }

        public Order CreateToEntity(OrderCreate create) 
        {
            Buyer buyer; 
            DateTime dateTime;

            try
            {
                buyer = _dbSetBuyer.FirstOrDefault(b => b.Id == create.BuyerId);
                if (buyer == null) 
                    throw new InvalidOperationException("Cannot find Buyer with BuyerId: " + create.BuyerId);
                dateTime = (string.IsNullOrEmpty(create.CreateDate)) 
                    ? DateTime.Now : DateTime.Parse(create.CreateDate);
            } 
            catch (InvalidOperationException ex)
            {
                throw ex;
            } 
            catch (FormatException ex)
            {
                throw new FormatException("Cannot format CreateDate to DateTime");
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            Order order = new Order();
            order.Status = create.Status;
            order.Address = create.Address;
            order.BuyerId = buyer.Id;
            order.CreateDate = dateTime;
            
            return order;
        }

        public OrderResponse EntityToResponse(Order entity)
        {
            Buyer buyer = _dbSetBuyer.FirstOrDefault(b => b.Id == entity.BuyerId);
            if (buyer == null)
                throw new InvalidOperationException("Cannot find Buyer with BuyerId: " + entity.BuyerId);

            OrderResponse order = new OrderResponse();
            order.Id = entity.Id;
            order.Address = entity.Address;
            order.CreateDate = entity.CreateDate.ToString();
            order.Status = (entity.Status == 1) ? "Active" : "Inactive";
            order.BuyerName = buyer.Name;
            order.PaymentMethod = buyer.PaymentMethod;

            return order;
        }

        public List<OrderResponse> ListEntitytoResponse(List<Order> entities)
        {
            List<OrderResponse> listResponse = new List<OrderResponse>();
            try
            {
                foreach (Order entity in entities)
                {
                    listResponse.Add(EntityToResponse(entity));
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            
            return listResponse;
        }

        public Order UpdatetoEntity(OrderUpdate update, Order entity)
        {
            
            try
            {
                entity.CreateDate = DateTime.Parse(update.CreateDate);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Cannot parse CreateDate to DateTime");
            }
            entity.Id = update.Id;
            entity.Status = update.Status;
            entity.Address = update.Address;
            entity.BuyerId = update.BuyerId;

            return entity;
        }
    }
}
