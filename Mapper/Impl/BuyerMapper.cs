using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetCrud2.DB;
using NetCrud2.Generics;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;

namespace NetCrud2.Mapper.Impl
{
    public class BuyerMapper : IBuyerMapper
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Buyer> _dbSetBuyer;

        public BuyerMapper(ApplicationDbContext db)
        {
            _db = db;
            _dbSetBuyer = db.Buyers;
        }

        public Buyer CreateToEntity(BuyerCreate create)
        {
            Buyer buyer = new Buyer();
            buyer.Name = create.Name;
            buyer.PaymentMethod = create.PaymentMethod;
            return buyer;
        }

        public BuyerResponse EntityToResponse(Buyer entity)
        {
            BuyerResponse response = new BuyerResponse();
            response.Id = entity.Id;
            response.Name = entity.Name;
            response.PaymentMethod = entity.PaymentMethod; 
            return response;
        }

        public List<BuyerResponse> ListEntitytoResponse(List<Buyer> entities)
        {
            List<BuyerResponse> listResponse = new List<BuyerResponse>();
            foreach (var entity in entities)
            {
                listResponse.Add(EntityToResponse(entity));
            }
            return listResponse;

        }

        public Buyer UpdatetoEntity(BuyerUpdate update, Buyer entity)
        {
            entity.Name = update.Name;
            entity.PaymentMethod = update.PaymentMethod;
            return entity;
        }
    }
}
