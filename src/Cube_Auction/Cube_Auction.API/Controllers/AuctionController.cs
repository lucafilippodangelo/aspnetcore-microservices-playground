using Cube_Auction.Application;
using Cube_Auction.Application.Queries;
using Cube_Auction.Core.Repositories;
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
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _repository;
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(IAuctionRepository repository, ILogger<AuctionController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuctionResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuctionResponse>>> GetAuctions()
        {
            var auctions = await _repository.GetAuctions();
            return Ok(auctions);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuctionResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AuctionResponse>>> GetAuctionByName(string name)
        {
            var auctions = await _repository.GetAuctionByName(name);
            return Ok(auctions);
        }

        
    }
}
