using Bogus;
using Moq;
using Purchase.Application.DTO_s;
using Purchase.Application.Interfaces;
using Purchase.Application.Service;
using Purchase.Infra.Interfaces;

namespace Purchase.Application.Tests
{
    public class PurchaseServiceTests
    {
        private readonly Faker _faker = new Faker();

        private PurchaseDTO CreateFakeDto()
        {
            return new PurchaseDTO
            {
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = _faker.Random.Int(1, 10),
                UnitPrice = decimal.Parse(_faker.Commerce.Price(1, 1000)),
                Discount = 0m
            };
        }

        private Domain.Entities.Purchase CreateFakeEntity()
        {
            return Domain.Entities.Purchase.Create(
                Guid.NewGuid(),
                Guid.NewGuid(),
                _faker.Random.Int(1, 10),
                decimal.Parse(_faker.Commerce.Price(1, 1000))
            );
        }

        [Fact]
        public async Task Create_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new PurchaseDTO
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Discount = 0m
            };

            var repoMock = new Mock<IPurchaseRepository>();
            repoMock.Setup(r => r.Create(It.IsAny<Domain.Entities.Purchase>())).ReturnsAsync(entity);

            var mapperMock = new Mock<IPurchaseMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new PurchaseService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Create(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.CustomerId, result.CustomerId);
            Assert.Equal(dtoOut.ProductId, result.ProductId);
            Assert.Equal(dtoOut.Quantity, result.Quantity);
            Assert.Equal(dtoOut.UnitPrice, result.UnitPrice);

            repoMock.Verify(r => r.Create(It.Is<Domain.Entities.Purchase>(p => p.CustomerId == entity.CustomerId && p.ProductId == entity.ProductId)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Delete_Should_Return_True_When_Repository_Deletes()
        {
            // Arrange
            var id = Guid.NewGuid();

            var repoMock = new Mock<IPurchaseRepository>();
            repoMock.Setup(r => r.Delete(id)).ReturnsAsync(true).Verifiable();

            var mapperMock = new Mock<IPurchaseMapper>();
            var service = new PurchaseService(repoMock.Object, mapperMock.Object);

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
            var list = new List<Domain.Entities.Purchase> { entity };

            var repoMock = new Mock<IPurchaseRepository>();
            repoMock.Setup(r => r.GetAll()).ReturnsAsync(list);

            var mapperMock = new Mock<IPurchaseMapper>();
            mapperMock.Setup(m => m.ToDto(It.IsAny<Domain.Entities.Purchase>())).Returns((Domain.Entities.Purchase p) => new PurchaseDTO
            {
                CustomerId = p.CustomerId,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                Discount = 0m
            });

            var service = new PurchaseService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(entity.CustomerId, result.First().CustomerId);
            Assert.Equal(entity.ProductId, result.First().ProductId);

            repoMock.Verify(r => r.GetAll(), Times.Once);
            mapperMock.Verify(m => m.ToDto(It.IsAny<Domain.Entities.Purchase>()), Times.Exactly(list.Count));
        }

        [Fact]
        public async Task GetById_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = CreateFakeEntity();
            var dtoOut = new PurchaseDTO
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Discount = 0m
            };

            var repoMock = new Mock<IPurchaseRepository>();
            repoMock.Setup(r => r.GetById(id)).ReturnsAsync(entity).Verifiable();

            var mapperMock = new Mock<IPurchaseMapper>();
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut).Verifiable();

            var service = new PurchaseService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.CustomerId, result.CustomerId);
            Assert.Equal(dtoOut.ProductId, result.ProductId);

            repoMock.Verify(r => r.GetById(id), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Update_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new PurchaseDTO
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Discount = 0m
            };

            var repoMock = new Mock<IPurchaseRepository>();
            repoMock.Setup(r => r.Create(It.IsAny<Domain.Entities.Purchase>())).ReturnsAsync(entity);

            var mapperMock = new Mock<IPurchaseMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new PurchaseService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Update(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.Quantity, result.Quantity);
            Assert.Equal(dtoOut.UnitPrice, result.UnitPrice);

            repoMock.Verify(r => r.Update(It.Is<Domain.Entities.Purchase>(p => p.Id == entity.Id)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }
    }
}
