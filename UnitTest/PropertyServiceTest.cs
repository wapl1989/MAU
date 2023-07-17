using Domain.Models;
using Infrastructure.Interfaces;
using Moq;
using Service;
using Service.Dtos;
using Service.Interfaces;

namespace UnitTest
{
    [TestFixture]
    public class PropertyServiceTest
    {
        private Mock<IPropertyRepository> _mockRepository;
        private IPropertyService _propertyService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPropertyRepository>();
            _propertyService = new PropertyService(_mockRepository.Object);
        }

        [Test]
        public async Task CreateProperty_ErrorAsync()
        {
            // Arrange
            string expectedErrorMessage = "Failed to create property";
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.Property>())).ThrowsAsync(new Exception(expectedErrorMessage));

            // Assert that the exception message matches the expected error message
            Exception ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await _propertyService.CreateProperty(new PropertyDto
                {
                    Address = "test",
                    CodeInternal = "Codtest",
                    IdOwner = 1,
                    Name = "testProperty",
                    Price = 30000000,
                    Year = 2023
                });
            });

            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public async Task CreateProperty_SuccessAsync()
        {
            // Arrange
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.Property>())).ReturnsAsync(1);

            // Act
            int result = await _propertyService.CreateProperty(new PropertyDto
            {
                Address = "test",
                CodeInternal = "Codtest",
                IdOwner = 1,
                Name = "testProperty",
                Price = 30000000,
                Year = 2023
            });

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task ChangePrice_PropertyFound_SuccessAsync()
        {
            // Arrange
            int propertyId = 1;
            decimal newPrice = 500000;

            Property property = new Property
            {
                IdProperty = propertyId,
                Address = "test",
                CodeInternal = "cod",
                IdOwner = 1,
                Year = 2020,
                Price = 100
            };

            _mockRepository.Setup(r => r.GetPropertyById(propertyId)).ReturnsAsync(property);
            _mockRepository.Setup(r => r.UpdateProperty(It.IsAny<Property>())).ReturnsAsync(true);

            // Act
            bool result = await _propertyService.ChangePrice(propertyId, newPrice);

            // Assert
            Assert.IsTrue(result);
            _mockRepository.Verify(r => r.GetPropertyById(propertyId), Times.Once);
            _mockRepository.Verify(r => r.UpdateProperty(It.IsAny<Property>()), Times.Once);
        }

        [Test]
        public async Task UpdateProperty_PropertyFound_SuccessAsync()
        {
            // Arrange
            int propertyId = 1;

            Property existingProperty = new Property
            {
                IdProperty = propertyId,
                Address = "test1",
                CodeInternal = "code",
                IdOwner = 1,
                Year = 2020,
                Price = 1000
            };

            _mockRepository.Setup(r => r.GetPropertyById(propertyId)).ReturnsAsync(existingProperty);
            _mockRepository.Setup(r => r.UpdateProperty(It.IsAny<Property>())).ReturnsAsync(true);

            PropertyDto updatedPropertyDto = new PropertyDto
            {
                IdProperty = propertyId,
                Address = "test",
                CodeInternal = "cod",
                IdOwner = 1,
                Year = 2020,
                Price = 100
            };

            // Act
            bool result = await _propertyService.UpdateProperty(propertyId, updatedPropertyDto);

            // Assert
            Assert.IsTrue(result);
            _mockRepository.Verify(r => r.GetPropertyById(propertyId), Times.Once);
            _mockRepository.Verify(r => r.UpdateProperty(It.IsAny<Property>()), Times.Once);
        }

        [Test]
        public async Task GetProperties_WithFilters_SuccessAsync()
        {
            // Arrange
            string nameFilter = "test";
            decimal minPrice = 100000;
            decimal maxPrice = 500000;
            int year = 2023;

            List<Property> properties = new List<Property>
            {
                new Property { IdProperty = 1, Name = "Property 1", Price = 200000, Year = 2023 },
                new Property { IdProperty = 2, Name = "Property 2", Price = 300000, Year = 2023 }
            };

            _mockRepository.Setup(r => r.GetProperties(nameFilter, minPrice, maxPrice, year)).ReturnsAsync(properties);

            // Act
            List<PropertyDto> propertyDtos = await _propertyService.GetProperties(nameFilter, minPrice, maxPrice, year);

            // Assert
            Assert.IsNotNull(propertyDtos);
            Assert.That(propertyDtos.Count, Is.EqualTo(2));
        }
    }
}
