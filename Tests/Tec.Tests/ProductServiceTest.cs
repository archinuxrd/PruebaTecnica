using Xunit;
using System;
using System.Linq;
using Tec.Web.Data;
using Tec.Web.Models.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tec.Tests
{
    public class DbFixture
    {
        public DbFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlite("DataSource=test.db"),
                    ServiceLifetime.Transient);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
 
    public class ProductServiceTest:IClassFixture<DbFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public ProductServiceTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
        
        [Fact]
        public void TestGetProductByName()
        {
            //Arrange
            var productName = "SSD 80GB SanDisk";
            
            //Act
            var context = _serviceProvider.GetService<ApplicationDbContext>();
            var products = context.Products.Where(c => c.Name == productName).ToList();
            
            //Assert
            Assert.True(products.Count > 0);
        }

        [Fact]
        public void TestIfExistsAnyProduct()
        {
            //Arrange
            var productSku = "SSD001";
            
            //Act
            var context = _serviceProvider.GetService<ApplicationDbContext>();
            
            //Assert
            Assert.True(context.Products.Any(x=>x.Sku == productSku));
        }
        
        [Fact]
        public void TestAddNewProduct()
        {
            //Arrange
            var product = new Product
            {
                Name = "ProductName",
                Sku = "ProductSku",
                Description = "ProductDescription",
                CreatedAt = DateTime.Now
            };
            
            //Act
            var context = _serviceProvider.GetService<ApplicationDbContext>();
            var result = context.Products.Add(product);
            //Assert
            Assert.True(result.State == EntityState.Added);
        }
        
        [Fact]
        public void TestGetColorsByProductId()
        {
            //Arrange
            var productId = 1;
            
            //Act
            var context = _serviceProvider.GetService<ApplicationDbContext>();
            var colors = context.Combinations.Where(c => c.ProductId == productId).ToList();
            
            //Assert
            Assert.True(colors.Count > 0);
        }
    }
}
