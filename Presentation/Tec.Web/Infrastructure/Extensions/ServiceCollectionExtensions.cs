using AutoMapper;
using Tec.Web.Data;
using FluentValidation;
using Tec.Web.Repositories;
using Tec.Web.Models.Catalog;
using Tec.Web.Services.Catalog;
using Tec.Web.Validators.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tec.Web.Core.Infrastructure.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tec.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICombinationRepository, CombinationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddTransient<IValidator<ProductViewModel>, ProductViewModelValidator>();
            services.AddTransient<IValidator<Combination>, CombinationValidator>();
            return services;
        }
        
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCombinationService, ProductCombinationService>();
            return services;
        }
    }
}