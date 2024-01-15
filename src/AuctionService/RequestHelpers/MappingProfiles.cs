using AuctionService.Dtos;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>()
            .IncludeMembers(x => x.Product);
        CreateMap<Product, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src));
        CreateMap<CreateAuctionDto, Product>();
        CreateMap<UpdateAuctionDto, Auction>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src));
        CreateMap<UpdateAuctionDto, Product>();

    }

}
