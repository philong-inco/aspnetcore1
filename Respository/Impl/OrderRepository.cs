using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Respository.Impl
{
    public class OrderRepository : Repository<Order, string>, OrderRepositoryChild
    {
        public OrderRepository(ApplicationDbContext db) : base(db) { }

        public FindOrderResponse findOrderByPaymentMethodAndDate(string paymentMethod, DateTime start, DateTime end)
        {
            return _db.findOrderCustom(paymentMethod, start, end);
        }

        public override async Task<Order> UpdateAsync(Order order)
        {
            if (order != null)
                _dbSet.Update(order);
            SaveChangesAsync();
            return order;
        }

    }
}
