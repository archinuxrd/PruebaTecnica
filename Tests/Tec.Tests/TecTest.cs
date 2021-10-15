using Moq;
using Xunit;
using System;
using Tec.Web.Data;
using System.Threading.Tasks;
using Tec.Web.Models.Catalog;
using Microsoft.EntityFrameworkCore;
using Tec.Web.Repositories;

namespace Tec.Tests
{
    public class TecTest
    {
        [Fact]
        public void Test1()
        {
            // //Setup DbContext and DbSet mock  
            // var dbContext = new Mock<ApplicationDbContext>(); 
            // var dbSetMock = new Mock<DbSet<Product>>();
            // dbSetMock.Setup(s => s.FindAsync(It.IsAny<int>()));  
            // dbContext.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object);  
            //
            // //Execute method of SUT (ProductsRepository)  
            // var productRepository = new ProductRepository(dbContext.Object);  
            // var product = productRepository.FirstAsync(x=>x.Id == 1).Result;  
            //
            // //Assert  
            // Assert.NotNull(product);  
            // Assert.IsAssignableFrom<Product>(product);
        }
        
        [Fact]
        public void Can_add_item()
        {
            using (var context = new ItemsContext(ContextOptions))
            {
                var controller = new ItemsController(context);

                var item = controller.PostItem("ItemFour").Value;

                Assert.Equal("ItemFour", item.Name);
            }

            using (var context = new ItemsContext(ContextOptions))
            {
                var item = context.Set<Item>().Single(e => e.Name == "ItemFour");

                Assert.Equal("ItemFour", item.Name);
                Assert.Equal(0, item.Tags.Count);
            }
        }
    }
}
