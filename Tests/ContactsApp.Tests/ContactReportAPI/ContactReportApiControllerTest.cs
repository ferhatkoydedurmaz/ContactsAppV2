using ContactsApp.ContactReportAPI.Controllers;
using ContactsApp.ContactReportAPI.Models;
using ContactsApp.ContactReportAPI.Services;
using ContactsApp.Core.Enums;
using ContactsApp.Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactsApp.Tests.ContactReportAPI;
public class ContactReportApiControllerTest
{
    private readonly Mock<IContactReportService> _contactReportServiceMock;
    private readonly Mock<IContactReportDetailService> _contactReportDetailServiceMock;
    private readonly ContactReportController _controller;
    private readonly string reportId = Guid.NewGuid().ToString();

    public ContactReportApiControllerTest()
    {
        _contactReportServiceMock = new Mock<IContactReportService>(MockBehavior.Loose);
        _contactReportDetailServiceMock = new Mock<IContactReportDetailService>(MockBehavior.Loose);
        _controller = new ContactReportController(contactReportService: _contactReportServiceMock.Object, contactReportDetailService: _contactReportDetailServiceMock.Object);
    }

    [Fact]
    public async Task GetReports_WhenCalled_ReturnsOkResult()
    {
        _contactReportServiceMock.Setup(i => i.GetReportsAsync()).ReturnsAsync(new BaseDataResponse<IEnumerable<ContactReport>>(new List<ContactReport>(), true));
        var result = await _controller.GetReport();

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }


    [Fact]
    public async Task GetReports_WhenCalled_ReturnsBadRequestResult()
    {
        _contactReportServiceMock.Setup(i => i.GetReportsAsync()).ReturnsAsync(new BaseDataResponse<IEnumerable<ContactReport>>(new List<ContactReport>(), false));
        var result = await _controller.GetReport();

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task CreateReport_WhenCalled_ReturnsOkResult()
    {
        _contactReportServiceMock.Setup(i => i.CreateReport()).ReturnsAsync(new BaseDataResponse<string>(reportId, true));
        var result = await _controller.CreateReport();

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task CreateReport_WhenCalled_ReturnsBadRequestResult()
    {
        _contactReportServiceMock.Setup(i => i.CreateReport()).ReturnsAsync(new BaseDataResponse<string>(default, false));
        var result = await _controller.CreateReport();

        var objectResult = (BadRequestObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task GetReportDetails_WhenCalled_ReturnsOkResult()
    {
        _contactReportDetailServiceMock.Setup(i => i.GetContactReportDetailsByReportIdAsync(It.IsAny<string>())).ReturnsAsync(new BaseDataResponse<List<ContactReportDetail>>(new List<ContactReportDetail>(), true));
        var result = await _controller.GetReportDetails(reportId);

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.True(res.Success, res.Message);
    }

    [Fact]
    public async Task GetReportDetails_WhenCalled_ReturnsBadRequestResult()
    {
        _contactReportDetailServiceMock.Setup(i => i.GetContactReportDetailsByReportIdAsync(It.IsAny<string>())).ReturnsAsync(new BaseDataResponse<List<ContactReportDetail>>(new List<ContactReportDetail>(), false));
        var result = await _controller.GetReportDetails(reportId);

        var objectResult = (ObjectResult)result;
        var res = (BaseResponse)objectResult.Value;
        Assert.NotNull(res);
        Assert.False(res.Success, res.Message);
    }

    [Fact]
    public async Task CreateReportDetails_WhenCalled_ReturnsOkResult()
    {
        _contactReportDetailServiceMock.Setup(i => i.CreateReportDetailAsync(It.IsAny<List<ContactReportDetail>>()));
        var result = await _controller.CreateReportDetails(CreateContactReportDetailRequest());

        var objectResult = (OkResult)result;
        Assert.NotNull(objectResult);
        Assert.True(objectResult.StatusCode == StatusCodes.Status200OK);
    }

    #region request
    private static List<ContactReportDetail> CreateContactReportDetailRequest()
    {
        return new List<ContactReportDetail>(new List<ContactReportDetail>());
    }
    #endregion
}
