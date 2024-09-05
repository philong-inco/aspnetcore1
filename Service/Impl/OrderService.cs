using NetCrud2.Generics;
using NetCrud2.Mapper.Impl;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Respository;
using NetCrud2.Respository.Impl;
using System.Linq.Expressions;

namespace NetCrud2.Service.Impl
{
    public class OrderService : IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse>, OrderServiceChild
    {

        private readonly IRepositoryGenerics<Order, string> _orderRepository;
        private readonly IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> _mapper;
        private readonly OrderRepositoryChild _orderRepositoryChild;

        public OrderService(IRepositoryGenerics<Order, string> orderRepository, 
            IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> mapper, 
            OrderRepositoryChild orderRepositoryChild)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderRepositoryChild = orderRepositoryChild;
        }

        public async Task<OrderResponse> Add(OrderCreate create)
        {
            try
            {
                Order entity = _mapper.CreateToEntity(create);
                Order entityResult = await _orderRepository.CreateAsync(entity);
                return _mapper.EntityToResponse(entityResult);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            Order entity = await _orderRepository.GetAsync(o => o.Id == id);
            if (entity != null) 
                await _orderRepository.Delete(entity);
        }

        public FindOrderResponse findOrderByPaymentMethodAndDate(string paymentMethod, DateTime start, DateTime end)
        {
            return _orderRepositoryChild.findOrderByPaymentMethodAndDate(paymentMethod, start, end);
        }

        public async Task<OrderResponse> Get(Expression<Func<Order, bool>> filter)
        {
            try
            {
                Order entity = await _orderRepository.GetAsync(filter);
                if (entity == null)
                    throw new NullReferenceException("Have not Order");
                return _mapper.EntityToResponse(entity);
            } catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderResponse>> GetAllList(Expression<Func<Order, bool>> filter = null, bool tracked = true)
        {
            List<Order> listEntity = await _orderRepository.GetAllAsync(filter, tracked);
            if (listEntity == null || listEntity.Count == 0)
                throw new NullReferenceException("Have not Order");
            try
            {
                return _mapper.ListEntitytoResponse(listEntity);
            }
            catch(InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public async Task<OrderResponse> Update(OrderUpdate update)
        {
            Order entity = await _orderRepository.GetAsync(o => o.Id == update.Id);
            if (entity == null)
                throw new InvalidOperationException("Cannot find Order with Id: " + update.Id);
            try
            {
                Order entityMapped = _mapper.UpdatetoEntity(update, entity);
                Order entityResult = await _orderRepository.UpdateAsync(entityMapped);
                return _mapper.EntityToResponse(entityResult);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

    }
}
