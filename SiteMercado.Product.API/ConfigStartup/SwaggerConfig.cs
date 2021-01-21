using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.Product.API.ConfigStartup
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureServiceSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CRUD Produto",
                        Version = "v1",
                        Description = "API REST para listagem, cadastro, edição e exclusão de produtos",
                        Contact = new OpenApiContact
                        {
                            Name = "Guilherme M Pires",
                            Url = new Uri("https://github.com/guiscs")
                        }
                    });
            });

            return services;
        }
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Produtos");
            });

            return app;
        }
    }

     
}
