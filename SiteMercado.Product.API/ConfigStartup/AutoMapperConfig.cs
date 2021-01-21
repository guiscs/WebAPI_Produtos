using AutoMapper;
using SiteMercado.Product.Business.Models;
using SiteMercado.Product.Data.Models;

namespace SiteMercado.Product.API
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
