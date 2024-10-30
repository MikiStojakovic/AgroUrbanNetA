using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using RateLimiter.Attributes;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest("Not a good request");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }
        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This is a test exception");
        }
        [RateLimit(5, 2)]
        [HttpPost("validationerror")]
        public IActionResult GetValidationError(ProductDto product)
        {
            return Ok();
        }
    }
}