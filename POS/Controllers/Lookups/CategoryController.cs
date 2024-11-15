using Application.Services;
using Application.Services.Lookups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers.Lookups
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IMediator _mediator;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess )
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> GetAllCategoriesWithSubCategory([FromBody] GetAllCategoriesWithSubCategoryQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> GetAllCategories([FromBody] GetAllCategoriesQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
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
