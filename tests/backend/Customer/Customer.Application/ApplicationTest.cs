using Bogus;
using Customer.Application.Interfaces;
using Customer.Application.Service;
using Customer.Infra.Interfaces;
using Moq;

namespace Customer.Application
{
    public class CustomerServiceTests
    {
        private readonly Faker _faker = new Faker();

        private CustomerDTO CreateFakeDto()
        {
            return new CustomerDTO
            {
                FullName = _faker.Name.FullName(),
                Email = _faker.Internet.Email()
            };
        }

        private Domain.Entities.Customer CreateFakeEntity()
        {
            return new Domain.Entities.Customer(_faker.Name.FullName(), _faker.Internet.Email());
        }

        [Fact]
        public async Task Create_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new CustomerDTO { FullName = entity.FullName, Email = entity.Email };

            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(r => r.Create(It.IsAny<Domain.Entities.Customer>()))
                    .ReturnsAsync(entity); // retorna um DomainCustomer

            var mapperMock = new Mock<ICustomerMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new CustomerService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Create(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.FullName, result.FullName);
            Assert.Equal(dtoOut.Email, result.Email);

            repoMock.Verify(r => r.Create(It.Is<Domain.Entities.Customer>(c => c.FullName == entity.FullName && c.Email == entity.Email)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Delete_Should_Return_True_When_Repository_Deletes()
        {
            // Arrange
            var id = Guid.NewGuid();

            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(r => r.Delete(id)).ReturnsAsync(true).Verifiable();

            var mapperMock = new Mock<ICustomerMapper>();
            var service = new CustomerService(repoMock.Object, mapperMock.Object);

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
            var list = new List<Domain.Entities.Customer> { entity };

            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(r => r.GetAll()).ReturnsAsync(list);

            var mapperMock = new Mock<ICustomerMapper>();
            var service = new CustomerService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(entity.FullName, result.First().FullName);
            Assert.Equal(entity.Email, result.First().Email);

            repoMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetById_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = CreateFakeEntity();
            var dtoOut = new CustomerDTO { FullName = entity.FullName, Email = entity.Email };

            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(r => r.GetById(id)).ReturnsAsync(entity).Verifiable();

            var mapperMock = new Mock<ICustomerMapper>();
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut).Verifiable();

            var service = new CustomerService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.FullName, result.FullName);
            Assert.Equal(dtoOut.Email, result.Email);

            repoMock.Verify(r => r.GetById(id), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }

        [Fact]
        public async Task Update_Should_Call_Repository_And_Return_Mapped_Dto()
        {
            // Arrange
            var dtoIn = CreateFakeDto();
            var entity = CreateFakeEntity();
            var dtoOut = new CustomerDTO { FullName = entity.FullName, Email = entity.Email };

            var repoMock = new Mock<ICustomerRepository>();
            repoMock.Setup(r => r.Update(It.IsAny<Domain.Entities.Customer>()))
                               .ReturnsAsync(entity); // retorna um DomainCustomer

            var mapperMock = new Mock<ICustomerMapper>();
            mapperMock.Setup(m => m.ToEntity(dtoIn)).Returns(entity);
            mapperMock.Setup(m => m.ToDto(entity)).Returns(dtoOut);

            var service = new CustomerService(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.Update(dtoIn);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dtoOut.FullName, result.FullName);
            Assert.Equal(dtoOut.Email, result.Email);

            repoMock.Verify(r => r.Create(It.Is<Domain.Entities.Customer>(c => c.FullName == entity.FullName && c.Email == entity.Email)), Times.Once);
            mapperMock.Verify(m => m.ToEntity(dtoIn), Times.Once);
            mapperMock.Verify(m => m.ToDto(entity), Times.Once);
        }
    }
}
