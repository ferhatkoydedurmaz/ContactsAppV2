using ContactsApp.Core.Results;
using ContactsApp.WebUI.Controllers;
using ContactsApp.WebUI.Models;
using ContactsApp.WebUI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Tests.WebUI;
public class WebUIControllerTest
{
    private readonly Mock<IContactService> _contactService;
    private readonly Mock<IContactFeatureService> _contactFeatureService;
    private readonly Mock<IContactReportService> _contactReportService;
    private readonly ContactController _controller;
    private readonly Contact _contact = new();
    private readonly ContactFeatureList _contactFeatureList = new();
    private readonly string _contactId = Guid.NewGuid().ToString();

    public WebUIControllerTest()
    {
        _contactFeatureService = new Mock<IContactFeatureService>(MockBehavior.Loose);
        _contactService = new Mock<IContactService>(MockBehavior.Loose);
        _contactReportService= new Mock<IContactReportService>(MockBehavior.Loose);
        _controller = new ContactController(contactFeatureService: _contactFeatureService.Object, contactReportService: _contactReportService.Object, contactService: _contactService.Object);
    }

    [Fact]
    public async Task AddContact_WithValidModel_ReturnsJsonResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("SomeField", "Some error message"); // Simulate ModelState error.

        // Act
        var result = await _controller.AddContact(_contact) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task AddContact_WithInvalidModel_ReturnsJsonResult()
    {

        // Arrange
        _contactService.Setup(c => c.AddContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(true));

        // Act
        var result = await _controller.AddContact(_contact) as JsonResult;

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task DeleteContact_WithValidId_ReturnsJsonResult()
    {
        // Arrange
        _contactService.Setup(c => c.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseResponse(true));

        // Act
        var result = await _controller.DeleteContact(_contactId) as JsonResult;

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task DeleteContact_WithInvalidId_ReturnsJsonResult()
    {
        // Arrange
        _contactService.Setup(c => c.DeleteContactAsync(It.IsAny<string>())).ReturnsAsync(new BaseResponse(false));

        // Act
        var result = await _controller.DeleteContact(_contactId) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task UpdateContact_WithValidModel_ReturnsJsonResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("SomeField", "Some error message"); // Simulate ModelState error.

        // Act
        var result = await _controller.UpdateContact(_contact) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task UpdateContact_WithInvalidModel_ReturnsJsonResult()
    {
        // Arrange
        _contactService.Setup(c => c.UpdateContactAsync(It.IsAny<Contact>())).ReturnsAsync(new BaseResponse(true));

        // Act
        var result = await _controller.UpdateContact(_contact) as JsonResult;

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task UpdateContactFeature_WithValidModel_ReturnsJsonResult()
    {
        // Arrange
        _contactFeatureService.Setup(c => c.AddOrUpdateContactFeaturesAsync(It.IsAny<ContactFeatureList>())).ReturnsAsync(new BaseDataResponse<ContactFeatureList>(new ContactFeatureList(),true));
        // Act
        var result = await _controller.UpdateContactFeature(_contactFeatureList) as JsonResult;

        // Assert
        Assert.NotNull(result);

    }

    [Fact]
    public async Task UpdateContactFeature_WithInvalidModel_ReturnsBadRequestResult()
    {
        // Arrange
        _contactFeatureService.Setup(c => c.AddOrUpdateContactFeaturesAsync(It.IsAny<ContactFeatureList>())).ReturnsAsync(new BaseDataResponse<ContactFeatureList>(new ContactFeatureList(),false));

        // Act
        var result = await _controller.UpdateContactFeature(_contactFeatureList) as BadRequestObjectResult;

        // Assert
        var res = (BaseDataResponse<ContactFeatureList>)result.Value;
        Assert.NotNull(result);
        Assert.False(res.Success);
    }
}
