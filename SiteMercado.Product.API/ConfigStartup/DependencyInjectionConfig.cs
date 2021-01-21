using SiteMercado.Product.Business.Business;
using SiteMercado.Product.Business.Interfaces;
using SiteMercado.Product.Business.Notificacoes;
using SiteMercado.Product.Data.Context;
using SiteMercado.Product.Data.Interfaces;
using SiteMercado.Product.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SiteMercado.Product.API.ConfigStartup
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProductContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
