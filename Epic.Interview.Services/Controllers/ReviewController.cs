using System.Threading.Tasks;
using Epic.Interview.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactor.Core;

namespace Epic.Interview.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController
    {
        private readonly IMediator mediator;

        public ReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IMono<Unit>> Post([FromBody] ReviewRequest request)
        {
            return await mediator.Send(request);
        }
    }
}