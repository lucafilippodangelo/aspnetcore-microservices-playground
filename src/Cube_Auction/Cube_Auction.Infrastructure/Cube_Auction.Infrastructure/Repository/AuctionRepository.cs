using Cube_Auction.Core.Entities;
using Cube_Auction.Core.Repositories;
using Cube_Auction.Infrastructure.Data;
using Cube_Auction.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube_Auction.Infrastructure.Repository
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {
        public AuctionRepository(AuctionContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            var auctionList = await _dbContext.Auctions
                      .ToListAsync();

            return auctionList;
        }

        public async Task<IEnumerable<Auction>> GetAuctionByName(string name)
        {
            var auctionList = await _dbContext.Auctions
                      .Where(o => o.Name == name)
                      .ToListAsync();

            return auctionList;
        }
    }
}
