using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Models;

namespace NetCrud2.Respository.Impl
{
    public class OrderRepository : Repository<Order, string>
    {
        public OrderRepository(ApplicationDbContext db) : base(db) { }
        public override async Task<Order> UpdateAsync(Order order)
        {
            if (order != null)
                _dbSet.Update(order);
            SaveChangesAsync();
            return order;
        }

    }
}
