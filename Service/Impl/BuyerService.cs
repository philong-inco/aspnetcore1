using NetCrud2.Generics;
using NetCrud2.Mapper.Impl;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Respository.Impl;
using System.Linq.Expressions;

namespace NetCrud2.Service.Impl
{
    public class BuyerService : IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse>
    {
        private readonly IRepositoryGenerics<Buyer, string> _buyerRespository;
        private readonly IMapperGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> _mapper;

        public BuyerService(IRepositoryGenerics<Buyer, string> buyerRespository, 
            IMapperGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> mapper)
        {
            _buyerRespository = buyerRespository;
            _mapper = mapper;
        }

        public async Task<BuyerResponse> Add(BuyerCreate create)
        {
            Buyer entity = _mapper.CreateToEntity(create);
            await _buyerRespository.CreateAsync(entity);
            return _mapper.EntityToResponse(entity);
        }

        public async Task Delete(string id)
        {
            Buyer entity = await _buyerRespository.GetAsync(b => b.Id == id);
            if (entity != null) 
                _buyerRespository.Delete(entity);
        }

        public async Task<BuyerResponse> Get(Expression<Func<Buyer, bool>> filter)
        {
            Buyer entity = await _buyerRespository.GetAsync(filter);
            if (entity == null)
                throw new NullReferenceException("Have not Buyer");
            return _mapper.EntityToResponse(entity);
        }

        public async Task<List<BuyerResponse>> GetAllList(Expression<Func<Buyer, bool>> filter = null, bool tracked = true)
        {
            List<Buyer> listEntity = await _buyerRespository.GetAllAsync(filter, tracked);
            if (listEntity == null || listEntity.Count == 0)
                throw new NullReferenceException("Have not Buyer");
            return _mapper.ListEntitytoResponse(listEntity);
        }

        public async Task<BuyerResponse> Update(BuyerUpdate update)
        {
            Buyer entityTemp = await _buyerRespository.GetAsync(b => b.Id == update.Id);
            if (entityTemp == null)
                throw new NullReferenceException("Have not Buyer");
            Buyer entity = _mapper.UpdatetoEntity(update, entityTemp);
            _buyerRespository.UpdateAsync(entity);
            return _mapper.EntityToResponse(entity);
        }
    }
}
