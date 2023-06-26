using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore;

namespace TestQuala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchStoreController : ControllerBase
    {
        private readonly IMediator mediator;

        public BranchStoreController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrach([FromBody] CreateBranchStoreCommand query)
        {

            var response = await mediator.Send(query);
            if (response.Succeeded)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(new { Mensaje = response.Message });
            }

        }

    }
}