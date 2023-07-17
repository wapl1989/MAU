using Infrastructure.Interfaces;
using Moq;
using Service.Dtos;
using Service.Interfaces;
using Service;

namespace UnitTest
{
    [TestFixture]
    public class PropertyImageServiceTest
    {
        private Mock<IPropertyImageRepository> _mockRepository;
        private IPropertyImageService _propertyImageService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPropertyImageRepository>();
            _propertyImageService = new PropertyImageService(_mockRepository.Object);
        }

        [Test]
        public async Task CreatePropertyImage_ErrorAsync()
        {
            // Arrange
            string expectedErrorMessage = "Failed to create Property Image";
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.PropertyImage>())).ThrowsAsync(new Exception(expectedErrorMessage));

            // Assert that the exception message matches the expected error message
            Exception ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await _propertyImageService.Create(new PropertyImageDto
                {
                    Enabled = true,
                    IdProperty = 1,
                    IdPropertyImage = 1,
                    File = new byte[0]
                });
            });

            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public async Task CreatePropertyImage_SuccessAsync()
        {
            // Arrange
            _mockRepository.Setup(r => r.Create(It.IsAny<Domain.Models.PropertyImage>())).ReturnsAsync(true);

            // Act
            bool result = await _propertyImageService.Create(new PropertyImageDto
            {
                Enabled = true,
                IdProperty = 1,
                IdPropertyImage = 1,
                File = new byte[0]
            });

            // Assert
            Assert.IsTrue(result);
        }
    }
}
