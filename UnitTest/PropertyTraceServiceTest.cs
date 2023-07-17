using Infrastructure.Interfaces;
using Moq;
using Service.Dtos;
using Service.Interfaces;
using Service;

namespace UnitTest
{
    [TestFixture]
    public class PropertyTraceServiceTest
    {
        private Mock<IPropertyTraceRepository> _mockRepository;
        private IPropertyTraceService _propertyTraceService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPropertyTraceRepository>();
            _propertyTraceService = new PropertyTraceService(_mockRepository.Object);
        }

        [Test]
        public async Task CreateProperty_ErrorAsync()
        {
            // Arrange
            string expectedErrorMessage = "Failed to create property";
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.PropertyTrace>())).ThrowsAsync(new Exception(expectedErrorMessage));

            // Assert that the exception message matches the expected error message
            Exception ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await _propertyTraceService.Create(new PropertyTraceDto
                {                    
                    Name = "testProperty",
                    DateSale = DateTime.Now,
                    IdProperty = 1,
                    IdPropertyTrace = 1,
                    Tax = 10000.90M,
                    Value = 3000000
                });
            });

            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public async Task CreateProperty_SuccessAsync()
        {
            // Arrange
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.PropertyTrace>())).ReturnsAsync(true);

            // Act
            bool result = await _propertyTraceService.Create(new PropertyTraceDto
            {
                Name = "testProperty",
                DateSale = DateTime.Now,
                IdProperty = 1,
                IdPropertyTrace = 1,
                Tax = 10000.90M,
                Value = 3000000
            });

            // Assert
            Assert.IsTrue(result);
        }
    }
}
