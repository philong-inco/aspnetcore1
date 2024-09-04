using Microsoft.EntityFrameworkCore;
using NetCrud2.DB;
using NetCrud2.Models;

namespace NetCrud2.Respository.Impl
{
    public class BuyerRepository : Repository<Buyer, string>
    {
        public BuyerRepository(ApplicationDbContext db) : base(db) { }

        public override async Task<Buyer> UpdateAsync(Buyer buyer)
        {
            if (buyer != null)
                _dbSet.Update(buyer);
            SaveChangesAsync();
            return buyer;
        }
    }
}
