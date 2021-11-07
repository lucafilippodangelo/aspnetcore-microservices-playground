using Cube_Auction.Application;
using Cube_Auction.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cube_Auction.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(IMediator mediator, ILogger<AuctionController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuctionResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuctionResponse>>> GetAuctionByName(string name)
        {
            var query = new GetAuctionByNameQuery(name);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        
    }
}
