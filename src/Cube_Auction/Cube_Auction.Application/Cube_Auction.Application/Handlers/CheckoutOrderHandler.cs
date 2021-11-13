using Cube_Auction.Application.Mapper;
using Cube_Auction.Core.Entities;
using Cube_Auction.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cube_Auction.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<AuctionCommand, AuctionResponse>
    {
        private readonly IAuctionRepository _auctionRepository;

        public CheckoutOrderHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository ?? throw new ArgumentNullException(nameof(auctionRepository));
        }

        public async Task<AuctionResponse> Handle(AuctionCommand request, CancellationToken cancellationToken)
        {
            var auctionEntity = AuctionMapper.Mapper.Map<Auction>(request);
            if (auctionEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newOrder = await _auctionRepository.AddAsync(auctionEntity);

            var orderResponse = AuctionMapper.Mapper.Map<AuctionResponse>(newOrder);
            return orderResponse;
        }
    }
}
