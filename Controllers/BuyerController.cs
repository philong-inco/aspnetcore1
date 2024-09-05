using Microsoft.AspNetCore.Mvc;
using NetCrud2.Generics;
using NetCrud2.Models;
using NetCrud2.Models.DTO.Request;
using NetCrud2.Models.DTO.Response;
using System.Linq.Expressions;
using NetCrud2.Utils;

namespace NetCrud2.Controllers
{
    [Route("/buyer/")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> _service;
        public BuyerController(IServiceGenerics<Buyer, BuyerCreate, BuyerUpdate, BuyerResponse> service)
        {
            _service = service;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BuyerResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<BuyerResponse>))]
        public async Task<ActionResult<APIResponse<IEnumerable<BuyerResponse>>>> GetAllList()
        {
            try
            {
                return Ok(new APIResponse<IEnumerable<BuyerResponse>>(
                    200, "GET Successfully", await _service.GetAllList()
                    ));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new APIResponse<IEnumerable<BuyerResponse>>(
                    999, ex.Message, null
                    ));
            }

        }

        [HttpGet("find")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BuyerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BuyerResponse))]
        public async Task<ActionResult<APIResponse<BuyerResponse>>> GetByCondtionnal(
                                                        [FromQuery(Name = "column")] string column,
                                                        [FromQuery(Name = "value")] string value)
        {
            Expression<Func<Buyer, bool>> filter = null;
            filter = UtilExpression.checkConditionalBuyer(filter, column, value);

            if (filter == null || string.IsNullOrEmpty(value))
            {
                return BadRequest(new APIResponse<BuyerResponse>(
                    400, "Cannot get with param " + column + ". Only [id, name, paymentmethod]."
                    ));
            }
            BuyerResponse buyerResponse;
            try
            {
                buyerResponse = await _service.Get(filter);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new APIResponse<BuyerResponse>(
                    404, ex.Message
                    ));
            }

            return Ok(new APIResponse<BuyerResponse>(
                    200, "GET Successfully", buyerResponse
                ));

        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BuyerResponse))]
        public async Task<ActionResult<APIResponse<BuyerResponse>>> Create([FromBody] BuyerCreate create)
        {
            bool check = (create == null
                    || string.IsNullOrEmpty(create.Name)
                    || string.IsNullOrEmpty(create.PaymentMethod)) ? false : true;

            if (!check)
            {
                return Ok(new APIResponse<object>(
                    400, "Have error from input",
                    ModelState.Where(ms => ms.Value.Errors.Count > 0)
                    .ToDictionary(k => k.Key, k => k.Value.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray())
                    ));
            }

            try
            {
                BuyerResponse response = await _service.Add(create);
                return Ok(new APIResponse<BuyerResponse>(
                    200, "Add Successfully", response
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BuyerResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BuyerResponse))]
        public async Task<ActionResult<APIResponse<BuyerResponse>>> Update([FromBody] BuyerUpdate update, string id)
        {
            bool check = (update == null
                    || string.IsNullOrEmpty(update.Id)
                    || string.IsNullOrEmpty(update.Name)
                    || string.IsNullOrEmpty(update.PaymentMethod)) ? false : true;

            if (!check)
            {
                return BadRequest(new APIResponse<object>(
                    200, "Have error from input",
                    ModelState.Where(ms => ms.Value.Errors.Count > 0)
                    .ToDictionary(k => k.Key, k => k.Value.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray())
                    ));
            }

            if (!update.Id.Equals(id))
            {
                return BadRequest(new APIResponse<object>(
                    400, "Id params different Id in Body"
                    ));
            }

            try
            {
                BuyerResponse response = await _service.Update(update);
                return Ok(new APIResponse<BuyerResponse>(
                    200, "Update Successfully", response
                    ));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(new APIResponse<object>(
                    400, ex.Message
                    ));
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(object))]

        public async Task<ActionResult<APIResponse<object>>> Delete(string id)
        {
            BuyerResponse response = await _service.Get(b => b.Id == id);
            if (response == null)
                return NotFound(new APIResponse<object>(
                    404, "Not have Buyer with ID: " + id
                    ));
            
            _service.Delete(id);
            return Ok(new APIResponse<object>(
                200, "DELETE successfully"
                ));

        }


    }
}
