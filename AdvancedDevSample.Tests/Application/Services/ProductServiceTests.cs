using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Pricing;
using AdvancedDevSample.Tests.Application.Fakes;

namespace AdvancedDevSample.Tests.Application.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void ChangeProductPrice_Should_Save_Product_When_Price_Is_Valid()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(10);// état initial valide

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            // Act
            var request = new ChangePriceRequest { NewPrice = 20 };
            service.ChangeProductPrice(product.Id, request);

            // Assert
            Assert.Equal(20, product.Price);
            Assert.True(repo.WasSaved);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(5)]
        public void ChangeProductPrice_Should_Save_Product_When_Price_Is_Valided(decimal newprice )
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(10);// état initial valide

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            // Act
            var request = new ChangePriceRequest { NewPrice = newprice };
            service.ChangeProductPrice(product.Id, request);

            // Assert
            Assert.Equal(newprice, product.Price);
            Assert.True(repo.WasSaved);
        }

        [Fact]
        public void ChangeProductLibelle_Should_Save_Product_When_Libelle_Is_Valid() { 
        
            var product = new Product();
            product.ChangeLibelle("Bob le bricoleur ");

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            var request = new ChangeLibelleRequest { NewLibelle = "Thomas le comédien" };
            service.ChangeProductLibelle(product.Id, request);

            Assert.Equal("Thomas le comédien", product.Libelle );
            Assert.True(repo.WasSaved);
        }

        [Theory]
        [InlineData("Jordan le basketeur ")]
        [InlineData("Kamel le CEO ")]
        public void ChangeProductLibelle_Should_Save_Product_When_Libelle_Is_Valided(string libelle) {
            var product = new Product();

            product.ChangeLibelle("Bob le bricoleur ");

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            var request = new ChangeLibelleRequest { NewLibelle = "Thomas le comédien" };
            service.ChangeProductLibelle(product.Id, request);

            Assert.Equal(libelle , product.Libelle);
            Assert.True(repo.WasSaved);
        }
    }
}
