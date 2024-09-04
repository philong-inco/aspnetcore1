using Microsoft.AspNetCore.Mvc;
using NetCrud2.Generics;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Models;
using System.Linq.Expressions;

namespace NetCrud2.Controllers
{
    [ApiController]
    [Route("/order-item/")]
    public class OrderItemController : ControllerBase
    {
        private readonly IServiceGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> _service;
        private readonly IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> _orderService;
        private readonly IMapperGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> _mapper;

        public OrderItemController(IServiceGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> service,
            IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> orderService,
            IMapperGenerics<OrderItem, OrderItemCreate, OrderItemUpdate, OrderItemResponse> mapper)
        {
            _service = service;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderItemResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<OrderItemResponse>))]
        public async Task<ActionResult<APIResponse<IEnumerable<OrderItemResponse>>>> getAllList()
        {
            try
            {
                List<OrderItemResponse> list = await _service.GetAllList();
                if (list == null || list.Count <= 0)
                    return NotFound(new APIResponse<List<OrderItemResponse>>(
                        404, "Have not OrderItem"
                        ));
                return Ok(new APIResponse<List<OrderItemResponse>>(
                        200, "GET Successfully", list
                    ));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new APIResponse<object>(
                    404, ex.Message
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("find")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OrderItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderItemResponse))]
        public async Task<ActionResult<APIResponse<OrderItemResponse>>> FindByCondition(
                                                [FromQuery(Name = "name")] string column,
                                                [FromQuery(Name = "value")] string value)
        {
            try
            {
                Expression<Func<OrderItem, bool>> filter = null;
                filter = Utils.UtilExpression.checkConditionalOrderItem(filter, column, value);
                if (filter == null)
                    return BadRequest(new APIResponse<OrderItemResponse>(
                        400, "Params valid in (id, units, unitsprice, orderid, productid)"
                        ));
                OrderItemResponse response = await _service.Get(filter);
                if (response == null) return NotFound(new APIResponse<OrderItemResponse>(
                        404, "Have not OrderItem"
                    ));
                return Ok(new APIResponse<OrderItemResponse>(
                        200, "Find Successfully", response
                    ));
            }
            catch (InvalidOperationException ex)
            {
                return Ok(new APIResponse<string>(
                        400, ex.Message
                    ));
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse<string>(
                        400, ex.Message
                    ));
            }
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderItemResponse))]
        public async Task<ActionResult<APIResponse<OrderItemResponse>>> Create([FromBody] OrderItemCreate create)
        {
            bool check = (create == null
                    || string.IsNullOrEmpty(create.Units)
                    || string.IsNullOrEmpty(create.UnitPrice)
                    || string.IsNullOrEmpty(create.OrderId)
                    ) ? false : true;

            try
            {
                await _orderService.Get(b => b.Id == create.OrderId);
            }
            catch (NullReferenceException ex)
            {
                check = false;
            }

            if (!check)
            {
                return Ok(new APIResponse<object>(
                    400, "Have error from input"
                    ));
            }

            try
            {
                OrderItemResponse response = await _service.Add(create);
                return Ok(new APIResponse<OrderItemResponse>(
                    200, "Add Successfully", response
                    ));
            }
            catch (InvalidOperationException ex)
            {
                return Ok(new APIResponse<string>(
                    400, ex.Message
                    ));
            } 
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(
                    400, ex.Message
                ));
            }

        }

        [HttpPut("update/{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderItemResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OrderItemResponse))]
        public async Task<ActionResult<APIResponse<OrderItemResponse>>> Update([FromBody] OrderItemUpdate update, string id)
        {
            bool check = (update == null
                   || string.IsNullOrEmpty(update.Id)
                   || string.IsNullOrEmpty(update.Units)
                   || string.IsNullOrEmpty(update.UnitPrice)
                   || string.IsNullOrEmpty(update.OrderId)
                   || string.IsNullOrEmpty(update.ProductId)
                   ) ? false : true;

            try
            {
                await _orderService.Get(b => b.Id == update.OrderId);
            }
            catch (NullReferenceException ex)
            {
                check = false;
            }

            if (!check)
            {
                return BadRequest(new APIResponse<object>(
                    200, "Have error from input"
                    ));
            }

            if (!update.Id.Equals(id))
            {
                return BadRequest(new APIResponse<object>(
                    200, "Id params different Id in Body"
                    ));
            }

            try
            {
                OrderItemResponse response = await _service.Update(update);
                return Ok(new APIResponse<OrderItemResponse>(
                    200, "Update Successfully", response
                    ));
            }
            catch (InvalidOperationException ex)
            {
                return Ok(new APIResponse<string>(
                    404, ex.Message
                    ));
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(
                    400, ex.Message
                ));
            }
        }




        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(object))]

        public async Task<ActionResult<APIResponse<object>>> Delete(string id)
        {
            
            try
            {
                OrderItemResponse response = await _service.Get(b => b.Id == id);
                _service.Delete(id);
                return Ok(new APIResponse<object>(
                    200, "DELETE successfully"
                    ));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new APIResponse<object>(
                   404, "Not have OrderItem with ID: " + id
                   ));
            }

        }
    }
}
