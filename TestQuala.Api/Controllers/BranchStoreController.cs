using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestQuala.Application.Features.BranchStores.Commands.CreateBranchStore;
using TestQuala.Application.Features.BranchStores.Commands.DeleteBranchStore;
using TestQuala.Application.Features.BranchStores.Commands.UpdateBranchStore;
using TestQuala.Application.Features.BranchStores.Queries.GetBranchStores;
using TestQuala.Domain.Entities.Common;

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

        [HttpGet]
        public async Task<ResponseModel<List<BranchStoreVM>>> GetBranchs()
        {
            return await mediator.Send(new GetBranchStoresQuery());
        }


        [HttpPost("CreateBranch")]
        public async Task<ActionResult> CreateBranch([FromBody] CreateBranchStoreCommand query)
        {

            var response = await mediator.Send(query);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpPut("UpdateBranch")]
        public async Task<ActionResult> UpdateBranch([FromBody] UpdateBranchStoreCommand query)
        {

            var response = await mediator.Send(query);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpDelete("DeleteBranch")]
        public async Task<ActionResult> DeleteBranch([FromBody] DeleteBranchStoreCommand query)
        {
            var response = await mediator.Send(query);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}