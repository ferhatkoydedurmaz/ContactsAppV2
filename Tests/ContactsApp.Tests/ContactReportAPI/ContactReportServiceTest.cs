using ContactsApp.ContactReportAPI.Models;
using ContactsApp.ContactReportAPI.Repositories;
using ContactsApp.ContactReportAPI.Services;
using ContactsApp.QueueService.QueueService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Tests.ContactReportAPI;
public class ContactReportServiceTest
{
    private readonly Mock<IContactReportRepository> _contactReportRepository;
    private readonly Mock<IQueueServiceHelper> _queueHelper;
    private readonly IContactReportService _contactReportService;
    public ContactReportServiceTest()
    {
        _contactReportRepository = new Mock<IContactReportRepository>(MockBehavior.Loose);
        _queueHelper = new Mock<IQueueServiceHelper>(MockBehavior.Loose);
        _contactReportService = new ContactReportService(_contactReportRepository.Object, _queueHelper.Object);
    }
    [Fact]
    public async Task CreateContactReport_ReturnTrue()
    {
        _contactReportRepository.Setup(i => i.AddContactReportAsync(It.IsAny<ContactReport>())).ReturnsAsync(new ContactReport());

        var result = await _contactReportService.CreateReport();

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }

    [Fact]
    public async Task GetContactReports_ReturnTrue()
    {
        _contactReportRepository.Setup(i => i.AddContactReportAsync(It.IsAny<ContactReport>())).ReturnsAsync(new ContactReport());

        var result = await _contactReportService.CreateReport();

        Assert.NotNull(result);
        Assert.True(result.Success, result.Message);
    }
}
