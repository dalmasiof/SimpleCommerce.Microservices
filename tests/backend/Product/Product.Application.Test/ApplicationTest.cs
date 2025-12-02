using Bogus;
using Moq;
using Product.Application.Interfaces;
using Product.Application.Service;
using Product.Domain.DTOs;
using Product.Infra.Interfaces;

namespace Product.Application.Tests
{
    public class ProductServiceTests
    {
        private readonly Faker _faker = new Faker();

        private ProductDTO CreateFakeDto()
        {
            return new ProductDTO
            {
                Name = _faker.Commerce.ProductName(),
                Description = _faker.Commerce.ProductAdjective(),
                Price = decimal.Parse(_faker.Commerce.Price()),
                StockQuantity = _faker.Random.Int(0, 1000)
            };
        }

        private Domain.Entities.Product CreateFakeEntity()
        {
            return new Domain.Entities.Product(
                _faker.Commerce.ProductName(),
                _faker.Commerce.ProductDescription(),
                decimal.Parse(_faker.Commerce.Price()),
                _faker.Random.Int(0, 1000)
            );
        }

        [Fact]
        public async Task Create_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new ProductDTO { Name = entity.Name, Description = entity.Description, Price = entity.Price, StockQuantity = entity.StockQuantity };

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.Update(It.IsAny<Domain.Entities.Product>()))
                                                    .ReturnsAsync(entity);

            var mapperMock = new Mock<IProductMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new ProductService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Create(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.Name, result.Name);
            Assert.Equal(dtoOut.Description, result.Description);
            Assert.Equal(dtoOut.Price, result.Price);
            Assert.Equal(dtoOut.StockQuantity, result.StockQuantity);

            repoMock.Verify(r => r.Create(It.Is<Domain.Entities.Product>(p => p.Name == entity.Name && p.Price == entity.Price)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Delete_Should_Return_True_When_Repository_Deletes()
        {
            // Arrange
            var id = Guid.NewGuid();

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.Delete(id)).ReturnsAsync(true).Verifiable();

            var mapperMock = new Mock<IProductMapper>();
            var service = new ProductService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Delete(id);

            // Assert
            Assert.True(result);
            repoMock.Verify(r => r.Delete(id), Times.Once);
        }

        [Fact]
        public async Task GetAll_Should_Return_List_Of_Dtos_Mapped_From_Repository()
        {
            // Arrange
            var entity = CreateFakeEntity();
            var list = new List<Domain.Entities.Product> { entity };

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.GetAll()).ReturnsAsync(list);

            var mapperMock = new Mock<IProductMapper>();
            mapperMock.Setup(m => m.ToDto(It.IsAny<Domain.Entities.Product>())).Returns((Domain.Entities.Product p) => new ProductDTO { Name = p.Name, Description = p.Description, Price = p.Price, StockQuantity = p.StockQuantity });

            var service = new ProductService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(entity.Name, result.First().Name);
            Assert.Equal(entity.Description, result.First().Description);

            repoMock.Verify(r => r.GetAll(), Times.Once);
            mapperMock.Verify(m => m.ToDto(It.IsAny<Domain.Entities.Product>()), Times.Exactly(list.Count));
        }

        [Fact]
        public async Task GetById_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = CreateFakeEntity();
            var dtoOut = new ProductDTO { Name = entity.Name, Description = entity.Description, Price = entity.Price, StockQuantity = entity.StockQuantity };

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.GetById(id)).ReturnsAsync(entity).Verifiable();

            var mapperMock = new Mock<IProductMapper>();
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut).Verifiable();

            var service = new ProductService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.Name, result.Name);
            Assert.Equal(dtoOut.Description, result.Description);

            repoMock.Verify(r => r.GetById(id), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Update_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new ProductDTO { Name = entity.Name, Description = entity.Description, Price = entity.Price, StockQuantity = entity.StockQuantity };

            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.Update(It.IsAny<Domain.Entities.Product>()))
                                         .ReturnsAsync(entity);

            var mapperMock = new Mock<IProductMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new ProductService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Update(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.Name, result.Name);
            Assert.Equal(dtoOut.Description, result.Description);

            repoMock.Verify(r => r.Update(It.Is<Domain.Entities.Product>(p => p.Name == entity.Name && p.Price == entity.Price)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }
    }
}
