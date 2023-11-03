using ContactsApp.Core.Results;
using ContactsApp.Core.Utitilies.Contants;
using ContactsApp.WebUI.Models;

namespace ContactsApp.WebUI.Services;

public interface IContactReportService
{
    Task<BaseDataResponse<IEnumerable<ContactReport>>> GetAllReportAsync();
    Task<BaseDataResponse<IEnumerable<ContactReportDetail>>> GetContactReportDetailAsync(string reportId);
    Task<BaseDataResponse<string>> CreateContactReportAsync();
}
public class ContactReportService: IContactReportService
{
    private readonly BaseService _baseService;

    public ContactReportService(BaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<BaseDataResponse<IEnumerable<ContactReport>>> GetAllReportAsync()
    {
        var result = await _baseService.DoGetRequest<IEnumerable<ContactReport>>(ApiHttpClientNameConstant.ContactsReportAPI, "api/reports");

        return result;
    }

    public async Task<BaseDataResponse<IEnumerable<ContactReportDetail>>> GetContactReportDetailAsync(string reportId)
    {
        var result = await _baseService.DoGetRequest<IEnumerable<ContactReportDetail>>(ApiHttpClientNameConstant.ContactsReportAPI, $"api/reportdetails?id={reportId}");

        return result;
    }

    public async Task<BaseDataResponse<string>> CreateContactReportAsync()
    {
        var result = await _baseService.DoGetRequest<string>(ApiHttpClientNameConstant.ContactsReportAPI, "api/create-report");

        return result;
    }
}
