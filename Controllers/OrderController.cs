using Microsoft.AspNetCore.Mvc;
using NetCrud2.Generics;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using NetCrud2.Service;
using NetCrud2.Service.Impl;
using System.Linq.Expressions;

namespace NetCrud2.Controllers
{
    [ApiController]
    [Route("/order/")]
    public class OrderController : ControllerBase
    {
        private readonly IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> _service;
        private readonly IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> _buyerService;
        private readonly IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> _mapper;
        private readonly OrderServiceChild _orderServiceChild;

        public OrderController(IServiceGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> service, 
            IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> buyerService, 
            IMapperGenerics<Order, OrderCreate, OrderUpdate, OrderResponse> mapper, 
            OrderServiceChild orderServiceChild)
        {
            _service = service;
            _buyerService = buyerService;
            _mapper = mapper;
            _orderServiceChild = orderServiceChild;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<OrderResponse>))]
        public async Task<ActionResult<APIResponse<IEnumerable<OrderResponse>>>> getAllList()
        {
            try
            {
                List<OrderResponse> list = await _service.GetAllList();
                if (list == null || list.Count <= 0)
                    return NotFound(new APIResponse<List<OrderResponse>>(
                        404, "Have not Order"
                        ));
                return Ok(new APIResponse<List<OrderResponse>>(
                        200, "GET Successfully", list
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderResponse))]
        public async Task<ActionResult<APIResponse<OrderResponse>>> FindByCondition(
                                                [FromQuery(Name = "name")] string column,
                                                [FromQuery(Name = "value")] string value)
        {
            try
            {
                Expression<Func<Order, bool>> filter = null;
                filter = Utils.UtilExpression.checkConditionalOrder(filter, column, value);
                if (filter == null)
                    return BadRequest(new APIResponse<OrderResponse>(
                        400, "Params valid in (id, status, address, buyerid)", null
                        ));
                OrderResponse response = await _service.Get(filter);
                return Ok(new APIResponse<OrderResponse>(
                        200, "Find Successfully", response
                ));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new APIResponse<OrderResponse>(
                        404, "Have not Order", null
                    ));
            } 
            
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(
                    400, ex.Message, null
                ));
            }
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderResponse))]
        public async Task<ActionResult<APIResponse<OrderResponse>>> Create([FromBody] OrderCreate create)
        {
            bool check = (create == null
                    || (create.Status != 0 && create.Status != 1)
                    || string.IsNullOrEmpty(create.BuyerId)
                    || string.IsNullOrEmpty(create.Address)) ? false : true;

            try
            {
                await _buyerService.Get(b => b.Id == create.BuyerId);
            } catch (NullReferenceException ex)
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
                OrderResponse response = await _service.Add(create);
                return Ok(new APIResponse<OrderResponse>(
                    200, "Add Successfully", response
                    ));
            }
            //catch (FormatException ex)
            //{

            //}
            //catch (InvalidOperationException ex)
            //{

            //}
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<object>(
                    400, ex.Message
                ));
            }

        }

        [HttpPut("update/{id:length(36)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(OrderResponse))]
        public async Task<ActionResult<APIResponse<OrderResponse>>> Update([FromBody] OrderUpdate update, string id)
        {
            bool check = (update == null
                    || string.IsNullOrEmpty(update.Id)
                    || (update.Status != 0 && update.Status != 1)
                    || string.IsNullOrEmpty(update.BuyerId)
                    || string.IsNullOrEmpty(update.Address)) ? false : true;
            try
            {
                await _buyerService.Get(b => b.Id == update.BuyerId);
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
                OrderResponse response = await _service.Update(update);
                return Ok(new APIResponse<OrderResponse>(
                    200, "Update Successfully", response
                    ));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new APIResponse<object>(
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
            OrderResponse response = await _service.Get(b => b.Id == id);
            if (response == null)
                return NotFound(new APIResponse<object>(
                    404, "Not have Order with ID: " + id
                    ));

            _service.Delete(id);
            return Ok(new APIResponse<object>(
                200, "DELETE successfully"
                ));

        }

        [HttpGet("search-order")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(object))]
        public ActionResult<APIResponse<FindOrderResponse>> findOrderCustom([FromQuery(Name = "payment")] string payment,
                                                                [FromQuery(Name = "start")] string startStr,
                                                                [FromQuery(Name = "end")] string endStr)
        {
            DateTime start, end;
            try
            {
                start = DateTime.Parse(startStr);
                end = DateTime.Parse(endStr);
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<FindOrderResponse>(
                400, "DateTime wrong! Cannot convert"
                ));
            }

            try
            {
                return Ok(new APIResponse<FindOrderResponse>(
                200, "Find Successfully", _orderServiceChild.findOrderByPaymentMethodAndDate(payment, start, end)
                ));
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse<FindOrderResponse>(
                400, ex.Message
                ));
            }
        }
    }
}
