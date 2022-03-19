using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Application.Interfaces;
using MacorratiMVC.Application.Maps;
using MacorratiMVC.Application.Services;
using MacorratiMVC.Infra.data.Context;
using MacorratiMVC.Infra.data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MacorattiMVC.Infra.ioc
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AdicionaInfraestrutura(this IServiceCollection services, IConfiguration configuration) {


            services.AddDbContext<BancoContexto>(options => options.UseSqlServer(configuration.GetConnectionString("StringDeConecao"),
                b => b.MigrationsAssembly(typeof(BancoContexto).Assembly.FullName)));

            services.AddScoped<BancoContexto>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(DomainTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("MacorratiMVC.Application");
            services.AddMediatR(myhandlers);

            return services;
        }

    }
}
