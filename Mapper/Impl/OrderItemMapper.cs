using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Models;
using NetCrud2.DB;
using Microsoft.EntityFrameworkCore;
using NetCrud2.Generics;

namespace NetCrud2.Mapper.Impl
{
    public class OrderItemMapper : IOrderItemMapper
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Order> _dbSetOrder;

        public OrderItemMapper(ApplicationDbContext db)
        {
            _db = db;
            _dbSetOrder = db.Orders;
        }

        public OrderItem CreateToEntity(OrderItemCreate create)
        {
            Order order = _dbSetOrder.FirstOrDefault(o => o.Id == create.OrderId);
            if (order == null)
                throw new InvalidOperationException("Cannot find Order with OrderId: " + create.OrderId);
            OrderItem entity = new OrderItem();
            entity.OrderId = create.OrderId;
            entity.ProductId = "null";
            entity.UnitsPrice = create.UnitPrice;
            entity.Units = create.Units;

            return entity;
            
        }

        public OrderItemResponse EntityToResponse(OrderItem entity)
        {
            Order order = _dbSetOrder.FirstOrDefault(o => o.Id == entity.OrderId);
            if (order == null) 
                throw new InvalidOperationException("Cannot find order with OrderId: " + entity.OrderId);
            OrderItemResponse response = new OrderItemResponse();
            response.Id = entity.Id;
            response.ProductName = "null";
            response.Status = (order.Status == 1) ? "Success" : "Canceled";
            response.UnitPrice = entity.UnitsPrice;
            response.Units = entity.Units;
            response.CreateDate = order.CreateDate.ToString();
            return response;
        }

        public List<OrderItemResponse> ListEntitytoResponse(List<OrderItem> entities)
        {
            List<OrderItemResponse> listResponse = new List<OrderItemResponse>();
            try
            {
                foreach (OrderItem entity in entities)
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

        public OrderItem UpdatetoEntity(OrderItemUpdate update, OrderItem entity)
        {
            entity.UnitsPrice = update.UnitPrice;
            entity.Units = update.Units;
            entity.ProductId = "null";
            entity.OrderId = update.OrderId;

            return entity;
        }
    }
}
