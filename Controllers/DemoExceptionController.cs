using Microsoft.AspNetCore.Mvc;
using NetCrud2.Exceptions;

namespace NetCrud2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoExceptionController : ControllerBase
    {
        [HttpGet("[action]")]
        public ActionResult Status404()
        {
            throw new NotFoundException("Long long");
        }

        [HttpGet("[action]")]
        public ActionResult StatusBadRequest()
        {
            throw new BadRequestException("Long long");
        }

        [HttpGet("[action]")]
        public ActionResult StatusValidator()
        {
            throw new ValidationException("Long long");
        }

        [HttpGet("[action]")]
        public ActionResult StatusAPICustomException()
        {
            throw new APICustomException("Long long");
        }
    }
}
