using Tec.Web.Data;
using FluentValidation;
using Tec.Web.Repositories;
using Tec.Web.Models.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tec.Web.Validators.Catalog;

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
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddTransient<IValidator<ProductViewModel>, ProductViewModelValidator>();
            services.AddTransient<IValidator<Combination>, CombinationValidator>();
            return services;
        }
    }
}