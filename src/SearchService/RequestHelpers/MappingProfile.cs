using AutoMapper;
using Contracts;
using SearchService.Models;

namespace SearchService.RequestHelpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuctionCreated, Product>();
        CreateMap<AuctionUpdated, Product>();
        CreateMap<AuctionDeleted, Product>();
    }
}