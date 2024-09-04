using AutoMapper;
using NetCrud2.Generics;
using NetCrud2.Mapper.Impl;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Respository.Impl;
using System.Linq.Expressions;

namespace NetCrud2.Service.Impl
{
    public class OrderItemService : IServiceGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse>
    {
        private readonly IRepositoryGenerics<OrderItem, string> _orderItemRepository;
        private readonly IMapperGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> _mapper;

        public OrderItemService(IRepositoryGenerics<OrderItem, string> orderItemRepository, 
            IMapperGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResponse> Add(OrderItemCreate create)
        {
            try
            {
                OrderItem entity = _mapper.CreateToEntity(create);
                OrderItem entityResult = await _orderItemRepository.CreateAsync(entity);
                return _mapper.EntityToResponse(entityResult);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            OrderItem entity = await _orderItemRepository.GetAsync(ot => ot.Id == id);
            if (entity == null) 
                throw new InvalidOperationException("Cannot find OrderItem with Id: " + id);
            await _orderItemRepository.Delete(entity);
        }

        public async Task<OrderItemResponse> Get(Expression<Func<OrderItem, bool>> filter)
        {
            OrderItem entity = await _orderItemRepository.GetAsync(filter);
            if (entity == null)
                throw new InvalidOperationException("Have not OrderItem");

            return _mapper.EntityToResponse(entity);
        }

        public async Task<List<OrderItemResponse>> GetAllList(Expression<Func<OrderItem, bool>> filter = null, bool tracked = true)
        {
            List<OrderItem> listEntity = await _orderItemRepository.GetAllAsync(filter, tracked);
            if (listEntity == null || listEntity.Count == 0)
                throw new InvalidOperationException("Have not OrderItem");

            return _mapper.ListEntitytoResponse(listEntity);
        }

        public async Task<OrderItemResponse> Update(OrderItemUpdate update)
        {
            OrderItem entity = await _orderItemRepository.GetAsync(ot => ot.Id == update.Id);
            if (entity == null)
                throw new InvalidOperationException("Cannot find OrderItem with Id: " + update.Id);
            OrderItem entityTemp = _mapper.UpdatetoEntity(update, entity);
            OrderItem entityResult = await _orderItemRepository.UpdateAsync(entityTemp);

            return _mapper.EntityToResponse(entityResult);
        }
    }
}
