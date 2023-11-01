using ContactsApp.Core.Results;
using ContactsApp.Core.Utitilies.Contants;
using ContactsApp.WebUI.Models;

namespace ContactsApp.WebUI.Services;

public class ContactReportService
{
    private readonly BaseService _baseService;

    public ContactReportService(BaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<BaseDataResponse<List<ContactReport>>> GetAllReportAsync()
    {
        var result = await _baseService.DoGetRequest<List<ContactReport>>(ApiHttpClientNameConstant.ContactsReportAPI, "api/contactreports");

        return result;
    }

    public async Task<BaseDataResponse<List<ContactReportDetail>>> GetContactReportDetailAsync(string reportId)
    {
        var result = await _baseService.DoGetRequest<List<ContactReportDetail>>(ApiHttpClientNameConstant.ContactsReportAPI, "api/contactreports");

        return result;
    }

    public async Task<BaseResponse> CreateContactReportAsync()
    {
        var result = await _baseService.DoGetRequest(ApiHttpClientNameConstant.ContactsReportAPI, "api/create-report");

        return result;
    }
}
