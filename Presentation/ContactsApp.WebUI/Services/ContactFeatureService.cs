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

    public async Task<BaseDataResponse<IEnumerable<ContactFeature>>> GetContactFeaturesByContactIdAsync(string id)
    {
        var result = await _baseService.DoGetRequest<IEnumerable<ContactFeature>>(ApiHttpClientNameConstant.ContactsAPI, $"api/contact-details?id={id}");

        return result;
    }
    public async Task<BaseDataResponse<ContactFeatureList>> AddOrUpdateContactFeaturesAsync(ContactFeatureList model)
    {
        var result = await _baseService.DoPostRequest<ContactFeatureList,ContactFeatureList>(ApiHttpClientNameConstant.ContactsAPI, "api/contact-details", model);

        return result;
    }
}
