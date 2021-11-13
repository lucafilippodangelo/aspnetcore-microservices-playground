using AutoMapper;
using Cube_Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cube_Auction.Application.Mapper
{
    public class AuctionMappingProfile : Profile
    {
        public AuctionMappingProfile()
        {
            CreateMap<Auction, AuctionCommand>().ReverseMap();
            CreateMap<Auction, AuctionResponse>().ReverseMap();
        }
    }
}
