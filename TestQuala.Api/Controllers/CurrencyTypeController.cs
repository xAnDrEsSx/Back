using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestQuala.Application.Features.BranchStores.Queries.GetBranchStores;
using TestQuala.Application.Features.CurrencyTypes.Queries.GetCurrencyTypes;
using TestQuala.Domain.Entities.Common;

namespace TestQuala.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public CurrencyTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseModel<List<CurrencyTypeVM>>> GetCurrencyTypes()
        {
            return await mediator.Send(new GetCurrencyTypesQuery());
        }
    }
}