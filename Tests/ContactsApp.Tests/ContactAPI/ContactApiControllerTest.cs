using ContactsApp.ContactAPI.Controllers;
using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Services;
using ContactsApp.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactsApp.Tests.ContactAPI;

public class ContactApiControllerTest
{
    private readonly Mock<IContactFeatureService> _contactFeatureServiceMock;
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly ContactController _contactController;
    private readonly ContactFeatureController _contactFeatureController;
    private readonly string contactId = Guid.NewGuid().ToString();

    public ContactApiControllerTest()
    {
        _contactServiceMock = new Mock<IContactService>(MockBehavior.Loose);
        _contactFeatureServiceMock = new Mock<IContactFeatureService>(MockBehavior.Loose); ;
        _contactController = new ContactController(_contactServiceMock.Object);
        _contactFeatureController = new ContactFeatureController(_contactFeatureServiceMock.Object);
    }

    #region ContactController

    [Fact]
    public async Task AddContact_WhenCalled_ReturnsOkResult()
    {
        _contactServiceMock.Setup(i => i.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(true));
        var result = await _contactController.AddContact(AddOrUpdateContactRequest());

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task AddContact_WhenCalled_ReturnsBadRequestResult()
    {
        _contactServiceMock.Setup(i => i.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(false));
        var result = await _contactController.AddContact(AddOrUpdateContactRequest());

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task UpdateContact_WhenCalled_ReturnsOkResult()
    {
        _contactServiceMock.Setup(i => i.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(true));
        var result = await _contactController.UpdateContact(AddOrUpdateContactRequest());

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task UpdateContact_WhenCalled_ReturnsBadRequestResult()
    {
        _contactServiceMock.Setup(i => i.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(false));
        var result = await _contactController.UpdateContact(AddOrUpdateContactRequest());

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task DeleteContact_WhenCalled_ReturnsOkResult()
    {
        _contactServiceMock.Setup(i => i.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseResponse(true));

        var result = await _contactController.DeleteContact(contactId);

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task DeleteContact_WhenCalled_ReturnsBadRequestResult()
    {
        _contactServiceMock.Setup(i => i.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseResponse(false));

        var result = await _contactController.DeleteContact(contactId);

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }


    [Fact]
    public async Task GetContactById_WhenCalled_ReturnsOkResult()
    {
        _contactServiceMock.Setup(i => i.GetContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseDataResponse<Contact>(new Contact(), true));

        var result = await _contactController.GetContactById(contactId);

        var objectResult = (ObjectResult)result;
        var res = (BaseDataResponse<Contact>)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task GetContactById_WhenCalled_ReturnsBadRequestResult()
    {
        _contactServiceMock.Setup(i => i.GetContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseDataResponse<Contact>(new Contact(), false));

        var result = await _contactController.GetContactById(contactId);

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseDataResponse<Contact>)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task GetContacts_WhenCalled_ReturnsOkResult()
    {
        _contactServiceMock.Setup(i => i.GetContactsAsync()).ReturnsAsync(new BaseDataResponse<IEnumerable<Contact>>(new List<Contact>(), true));

        var result = await _contactController.GetContacts();

        var objectResult = (ObjectResult)result;
        var res = (BaseDataResponse<IEnumerable<Contact>>)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }


    [Fact]
    public async Task GetContacts_WhenCalled_ReturnsBadRequestResult()
    {
        _contactServiceMock.Setup(i => i.GetContactsAsync()).ReturnsAsync(new BaseDataResponse<IEnumerable<Contact>>(new List<Contact>(), false));

        var result = await _contactController.GetContacts();

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseDataResponse<IEnumerable<Contact>>)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    #endregion

    #region ContactFeatureController

    [Fact]
    public async Task AddOrUpdateContactFeature_WhenCalled_ReturnsOkResult()
    {
        _contactFeatureServiceMock.Setup(i => i.AddOrUpdateAsync(It.IsAny<ContactFeatureList>())).ReturnsAsync(new BaseDataResponse<ContactFeatureList>(new ContactFeatureList(), true));

        var result = await _contactFeatureController.AddOrUpdateContact(new ContactFeatureList());

        var objectResult = (ObjectResult)result;
        var res = (BaseDataResponse<ContactFeatureList>)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }


    [Fact]
    public async Task GetContactFeature_WhenCalled_ReturnsOkResult()
    {
        _contactFeatureServiceMock.Setup(i => i.GetContactFeaturesByContactIdAsync(It.IsAny<string>())).ReturnsAsync(new BaseDataResponse<IEnumerable<ContactFeature>>(new List<ContactFeature>(), true));

        var result = await _contactFeatureController.GetContactFeatures(contactId);

        var objectResult = (ObjectResult)result;
        var res = (BaseDataResponse<IEnumerable<ContactFeature>>)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    #endregion

    #region request

    private static Contact AddOrUpdateContactRequest()
    {
        return new Contact()
        {
            FirstName = "test",
            LastName = "test",
            CompanyName = "test"
        };
    }
    #endregion
}