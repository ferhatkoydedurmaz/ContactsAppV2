using ContactsApp.Core.Results;
using ContactsApp.Core.Utitilies.Contants;
using ContactsApp.WebUI.Models;

namespace ContactsApp.WebUI.Services;

public class ContactFeatureService
{
    private readonly BaseService _baseService;

    public ContactFeatureService(BaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<BaseDataResponse<List<ContactFeature>>> GetContactFeaturesByContactIdAsync()
    {
        var result = await _baseService.DoGetRequest<List<ContactFeature>>(ApiHttpClientNameConstant.ContactsAPI, "api/contactfeatures");

        return result;
    }
    public async Task<BaseResponse> AddContactFeaturesAsync(ContactFeatureList model)
    {
        var result = await _baseService.DoPostRequest(ApiHttpClientNameConstant.ContactsAPI, "api/contactfeatures", model);

        return result;
    }
}
