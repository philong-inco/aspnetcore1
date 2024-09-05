using NetCrud2.DB;
using NetCrud2.Generics;
using NetCrud2.Mapper.Impl;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Respository;
using NetCrud2.Respository.Impl;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Linq.Expressions;

namespace NetCrud2.Service.Impl
{
    public class OrderService : IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse>, OrderServiceChild
    {

        private readonly IRepositoryGenerics<Order, string> _orderRepository;
        private readonly IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> _mapper;
        private readonly OrderRepositoryChild _orderRepositoryChild;
        private readonly OracleConnection _cn;
        private readonly DbContext2 _dbContext2;

        public OrderService(IRepositoryGenerics<Order, string> orderRepository, 
            IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> mapper, 
            OrderRepositoryChild orderRepositoryChild,
            DbContext2 dbContext2)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderRepositoryChild = orderRepositoryChild;
            _dbContext2 = dbContext2;
            _cn = dbContext2.GetConnection();
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
            //return _orderRepositoryChild.findOrderByPaymentMethodAndDate(paymentMethod, start, end);


            int[] statusArr = Utils.ConvertPaymentMethod.convertPaymentMethodStrToStatusOrder(paymentMethod);
            FindOrderResponse response = new FindOrderResponse();

            try
            {
                _dbContext2.Open();
                using (var command = new OracleCommand("GETORDERSUMMARY", _cn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine(_cn);
                    // Tham số IN
                    command.Parameters.Add("p_status1", OracleDbType.Int32).Value = statusArr[0];
                    command.Parameters.Add("p_status2", OracleDbType.Int32).Value = statusArr[1];
                    command.Parameters.Add("p_start", OracleDbType.TimeStamp).Value = start;
                    command.Parameters.Add("p_end", OracleDbType.TimeStamp).Value = end;

                    // Tham số OUT
                    var o_order_count = new OracleParameter("o_order_count", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    var o_buyer_count = new OracleParameter("o_buyer_count", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    var o_total_payment = new OracleParameter("o_total_payment", OracleDbType.Decimal) { Direction = ParameterDirection.Output };
                    var o_max_payment_buyer = new OracleParameter("o_max_payment_buyer", OracleDbType.Varchar2, 100) { Direction = ParameterDirection.Output };
                    var o_min_payment_buyer = new OracleParameter("o_min_payment_buyer", OracleDbType.Varchar2, 100) { Direction = ParameterDirection.Output };

                    // Add các tham số OUT vào command
                    command.Parameters.Add(o_order_count);
                    command.Parameters.Add(o_buyer_count);
                    command.Parameters.Add(o_total_payment);
                    command.Parameters.Add(o_max_payment_buyer);
                    command.Parameters.Add(o_min_payment_buyer);

                    // Thực thi
                    command.ExecuteNonQuery();

                    // Gán result OUT cho response
                    response.countOrderId = Convert.ToInt32(((OracleDecimal)o_order_count.Value).Value);
                    response.countBuyerUsedPaymentMethod = Convert.ToInt32(((OracleDecimal)o_buyer_count.Value).Value);
                    response.moneyTotal = Convert.ToDecimal(((OracleDecimal)o_total_payment.Value).Value);
                    response.buyerUsedMin = o_min_payment_buyer.Value.ToString();
                    response.buyerUsedMax = o_max_payment_buyer.Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbContext2.Close();
            }
            
            return response;

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
