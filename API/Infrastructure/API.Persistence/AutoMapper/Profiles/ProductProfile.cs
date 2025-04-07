using AutoMapper;

namespace API.Persistence.AutoMapper.Profiles
{
    using Model.Dtos.Product;
    using Model.Entities;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductDto, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<Product, ProductResponseDto>();
        }
    }
}
