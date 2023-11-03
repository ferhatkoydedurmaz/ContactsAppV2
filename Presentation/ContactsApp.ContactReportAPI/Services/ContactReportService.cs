using ContactsApp.ContactReportAPI.Models;
using ContactsApp.ContactReportAPI.Repositories;
using ContactsApp.Core.Enums;
using ContactsApp.Core.Results;
using ContactsApp.QueueService.QueueService;

namespace ContactsApp.ContactReportAPI.Services;

public interface IContactReportService
{
    Task<BaseDataResponse<string>> CreateReport();
    Task<BaseDataResponse<IEnumerable<ContactReport>>> GetReportsAsync();
    Task UpdateStatus(string reportId, ContactReportStatusEnum status);
}
public class ContactReportService: IContactReportService
{
    private readonly IContactReportRepository _contactReportRepository;
    private readonly IQueueServiceHelper _queueServiceHelper;

    public ContactReportService(IContactReportRepository contactReportRepository, IQueueServiceHelper queueServiceHelper)
    {
        _contactReportRepository = contactReportRepository;
        _queueServiceHelper = queueServiceHelper;
    }

    public async Task<BaseDataResponse<string>> CreateReport()
    {
        ContactReport report = new()
        {
            StatusId = (int)ContactReportStatusEnum.Hazırlanıyor,
        };

        var result = await _contactReportRepository.AddContactReportAsync(report);

        if(result is null)
            return new BaseDataResponse<string>(default, false, "Report could not be created");

        await _queueServiceHelper.SendQueueMessage("contactreport", result.Id.ToString());

        return new BaseDataResponse<string>(result.Id.ToString(), true);

    }

    public async Task<BaseDataResponse<IEnumerable<ContactReport>>> GetReportsAsync()
    {
        var result = await _contactReportRepository.GetContactReportsAsync();

        return new BaseDataResponse<IEnumerable<ContactReport>>(result, true);
    }

    public async Task UpdateStatus(string reportId, ContactReportStatusEnum status)
    {
        await _contactReportRepository.UpdateAsync(reportId, (int)status);
    }
}
