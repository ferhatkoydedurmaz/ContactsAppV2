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
    public async Task AddContactFeature_WitNotNull_ReturnTrue()
    {
        _contactFeatureRepository.Setup(i => i.AddAsync(It.IsAny<ContactFeature>())).ReturnsAsync(true);

        var result = await _contactFeatureService.AddOrUpdateAsync(new ContactFeatureList());

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task GetContactFeature_WitNotNull_ReturnTrue()
    {
        _contactFeatureRepository.Setup(i => i.GetContactFeaturesByContactIdAsync(It.IsAny<string>())).ReturnsAsync(new List<ContactFeature>());

        var result = await _contactFeatureService.GetContactFeaturesByContactIdAsync(contactId);

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task GetContactFeature_WitNullContactId_ReturnFalse()
    {
        _contactFeatureRepository.Setup(i => i.GetContactFeaturesByContactIdAsync(It.IsAny<string>())).ReturnsAsync(new List<ContactFeature>());

        var result = await _contactFeatureService.GetContactFeaturesByContactIdAsync(default);

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }
}
