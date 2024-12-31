using Application.Services.Lookups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers.Lookups
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpPost]
        public async Task<IActionResult> GetAllProducts([FromBody] GetAllProductsQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> HideProduct([FromBody] HideProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> GetProductById([FromBody] GetProductByIdQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> SearchProductByNameOrCode([FromBody] SearchProductByNameOrCode command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
