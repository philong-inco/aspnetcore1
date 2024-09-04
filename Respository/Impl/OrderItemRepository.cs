using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Models;

namespace NetCrud2.Respository.Impl
{
    public class OrderItemRepository : Repository<OrderItem, string>
    {
        public OrderItemRepository(ApplicationDbContext db) : base(db) { }

        public override async Task<OrderItem> UpdateAsync(OrderItem item)
        {
            if (item != null)
                _dbSet.Update(item);
            SaveChangesAsync();
            return item;
        }
    }
}
