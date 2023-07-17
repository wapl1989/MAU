using Infrastructure.Interfaces;
using Moq;
using Service.Dtos;
using Service.Interfaces;
using Service;

namespace UnitTest
{
    [TestFixture]
    public class OwnerServiceTest
    {
        private Mock<IOwnerRepository> _mockRepository;
        private IOwnerService _ownerService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IOwnerRepository>();
            _ownerService = new OwnerService(_mockRepository.Object);
        }

        [Test]
        public async Task CreateOwner_ErrorAsync()
        {
            // Arrange
            string expectedErrorMessage = "Failed to create Owner";
            _mockRepository.Setup(r => r.CreateOwner(It.IsAny<Domain.Models.Owner>())).ThrowsAsync(new Exception(expectedErrorMessage));

            // Assert that the exception message matches the expected error message
            Exception ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await _ownerService.CreateOwner(new OwnerDto
                {
                    Address = "test",
                    Birthday = DateTime.UtcNow,
                    IdOwner = 1,
                    Name = "testOwner"
                    
                });
            });

            Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public async Task CreateOwner_SuccessAsync()
        {
            // Arrange
            _mockRepository.Setup(r => r.CreateOwner(It.IsAny<Domain.Models.Owner>())).ReturnsAsync(true);

            // Act
            bool result = await _ownerService.CreateOwner(new OwnerDto
            {
                Address = "test",
                Birthday = DateTime.UtcNow,
                IdOwner = 1,
                Name = "testOwner"

            });

            // Assert
            Assert.IsTrue(result);
        }
    }
}
