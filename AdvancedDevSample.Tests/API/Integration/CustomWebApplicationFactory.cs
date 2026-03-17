
using AdvancedDevSample.Application.Interface;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace AdvancedDevSample.Tests.API.Integration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                // Supprimer le vrai repository si nécessaire
                services.RemoveAll(typeof(IProductRepository));
                

                // Ajouter un repository InMemory
                services.AddSingleton<IProductRepository, InMemoryProductRepository>();

                services.RemoveAll(typeof(IProductService));
                services.AddScoped<IProductService, ProductService>();
            });


        }
    }
}