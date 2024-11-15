using Application.Services.Lookups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers.Lookups
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ILogger<SubCategoryController> _logger;
        private readonly IMediator _mediator;

        public SubCategoryController(ILogger<SubCategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddSubCategory([FromBody] AddSubCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


       

        [HttpPost]
        public async Task<IActionResult> GetAllSubCategories([FromBody] GetAllSubCategoriesQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null && result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory([FromBody] DeleteCategoryCommand command)
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
