using AuctionService.Dtos;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

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
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateAuctionDto, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<AuctionDto, AuctionCreated>();

        CreateMap<Auction, AuctionUpdated>()
            .IncludeMembers(x => x.Product);
        CreateMap<Product, AuctionUpdated>();

        CreateMap<Auction, AuctionDeleted>();
    }

}
