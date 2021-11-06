using System;
using System.Collections.Generic;
using System.Text;

namespace Cube_Auction.Core.Entities
{
    public class AuctionStatusHistory
    {
        
        public Auction Auction { get; set; } //many history associated with one Auction
        public Auction HistoryForAuction { get; set; }
        public AuctionStatus AuctionStatus { get; set; }


    }

    public enum AuctionStatus
    {
        Created = 1,
        InProgress = 2,
        Finalised = 3
    }
}
