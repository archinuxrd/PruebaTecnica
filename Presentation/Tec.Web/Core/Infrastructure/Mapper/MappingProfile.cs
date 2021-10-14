using AutoMapper;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Core.Infrastructure.Mapper
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            
            CreateMap<Combination, CombinationViewModel>().ReverseMap();
            CreateMap<CombinationViewModel, Combination>().ReverseMap();
        }
    }
}