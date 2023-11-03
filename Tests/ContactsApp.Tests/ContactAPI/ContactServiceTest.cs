using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Repositories;
using ContactsApp.ContactAPI.Services;
using Moq;

namespace ContactsApp.Tests.ContactAPI;
public class ContactServiceTest
{
    private readonly Mock<IContactRepository> _contactRepository;
    private readonly IContactService _contactService;
    private readonly string contactId = Guid.NewGuid().ToString();

    public ContactServiceTest()
    {
        _contactRepository = new Mock<IContactRepository>(MockBehavior.Loose);
        _contactService = new ContactService(contactRepository: _contactRepository.Object);
    }
    [Fact]
    public async Task AddContact_WitNotNull_ReturnTrue()
    {
        _contactRepository.Setup(i => i.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(true);

        var result = await _contactService.AddContactAsync(ContactRequest());

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task AddContact_WithNull_ReturnFalse()
    {
        _contactRepository.Setup(i => i.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(true);

        var result = await _contactService.AddContactAsync(new Contact());

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task NotAddContact_WithNotNull_ReturnFalse()
    {
        _contactRepository.Setup(i => i.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(false);

        var result = await _contactService.AddContactAsync(ContactRequest());

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }


    [Fact]
    public async Task UpdateContact_WithNotNull_ReturnTrue()
    {
        _contactRepository.Setup(i => i.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(true);

        var result = await _contactService.UpdateContactAsync(ContactRequest());

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task UpdateContact_WithNullFirstName_ReturnFalse()
    {
        _contactRepository.Setup(i => i.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(true);

        var result = await _contactService.UpdateContactAsync(new Contact());

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task NotUpdateContact_WithNotNull_ReturnFalse()
    {
        _contactRepository.Setup(i => i.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(false);

        var result = await _contactService.UpdateContactAsync(ContactRequest());

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task DeleteContact_WithNotNull_ReturnTrue()
    {
        _contactRepository.Setup(i => i.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(true);

        var result = await _contactService.DeleteContactAsync(contactId);

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task NotDeleteContact_WithNotNull_ReturnFalse()
    {
        _contactRepository.Setup(i => i.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(false);

        var result = await _contactService.DeleteContactAsync(contactId);

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task DeleteContact_WithNullContactId_ReturnFalse()
    {
        _contactRepository.Setup(i => i.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(true);

        var result = await _contactService.DeleteContactAsync(default);

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task GetContactById_WithContactId_ReturnTrue()
    {
        _contactRepository.Setup(i => i.GetContactAsync(It.IsAny<string>())).ReturnsAsync(new Contact() { FirstName = "test", LastName = "test", CompanyName = "test" });

        var result = await _contactService.GetContactAsync(contactId);

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task GetContactById_WithNullContactId_ReturnFalse()
    {
        _contactRepository.Setup(i => i.GetContactAsync(It.IsAny<string>())).ReturnsAsync(new Contact());

        var result = await _contactService.GetContactAsync(default);

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public async Task NotGetContactById_WithContactId_ReturnFalse()
    {
        _contactRepository.Setup(i => i.GetContactAsync(It.IsAny<string>())).ReturnsAsync(new Contact());

        var result = await _contactService.GetContactAsync(contactId);

        Assert.NotNull(result);
        Assert.False(result.Success, result.Message);
    }

    #region request

    private static Contact ContactRequest()
    {
        var contact = new Contact()
        {
            FirstName = "test",
            LastName = "test",
            CompanyName = "test"
        };
        return contact;
    }

    #endregion
}
