using AutoMapper;
using Core.Entities;

namespace API.DTO.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductDTO>()
        .ForMember(
            dest => dest.ProductRating,
            opt => opt.MapFrom(from => $"{from.ProductRating.Rate} ({from.ProductRating.Count})")
        )
        .ForMember(
            dest => dest.ProductCategory,
            opt => opt.MapFrom(from => from.ProductCategory.Name)
        )
        .ForMember(
            dest => dest.PictureUrl,
            opt => opt.MapFrom<ProductUrlResolver>()
        );
    }
}
