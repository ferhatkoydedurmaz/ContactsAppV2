using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Repositories;
using ContactsApp.ContactAPI.Services;
using Moq;

namespace ContactsApp.Tests.ContactAPI;
public class ContactFeatureServiceTest
{
    private readonly Mock<IContactFeatureRepository> _contactFeatureRepository;
    private readonly IContactFeatureService _contactFeatureService;
    private readonly string contactId = Guid.NewGuid().ToString();

    public ContactFeatureServiceTest()
    {
        _contactFeatureRepository = new Mock<IContactFeatureRepository>(MockBehavior.Loose);
        _contactFeatureService = new ContactFeatureService(_contactFeatureRepository.Object);
    }

    [Fact]
    public async Task GetContactFeaturesByContactIdAsync_WithValidId_ReturnsSuccessResponse()
    {
        // Arrange
        var contactId = "validContactId";
        var contactFeatures = new List<ContactFeature>(); // Replace with your sample data
        _contactFeatureRepository.Setup(r => r.GetContactFeaturesByContactIdAsync(contactId))
            .ReturnsAsync(contactFeatures);

        // Act
        var result = await _contactFeatureService.GetContactFeaturesByContactIdAsync(contactId);

        // Assert
        Assert.True(result.Success);
        Assert.Same(contactFeatures, result.Data);
        Assert.Null(result.Message);
    }

    [Fact]
    public async Task AddOrUpdateAsync_WithValidModel_ReturnsSuccessResponse()
    {
        // Arrange
        var model = new ContactFeatureList(); // Replace with your sample data
        _contactFeatureRepository.Setup(r => r.GetByContactIdAndFeatureType(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync((ContactFeature)null); // Simulate not finding a contact feature
        _contactFeatureRepository.Setup(r => r.AddAsync(It.IsAny<ContactFeature>()))
            .ReturnsAsync(true);
        _contactFeatureRepository.Setup(r => r.UpdateAsync(It.IsAny<ContactFeature>()))
            .ReturnsAsync(true);


        // Act
        var result = await _contactFeatureService.AddOrUpdateAsync(model);

        // Assert
        Assert.True(result.Success);
        Assert.Same(model, result.Data);
        Assert.Null(result.Message);
    }
}
