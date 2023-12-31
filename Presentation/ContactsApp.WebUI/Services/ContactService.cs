﻿using ContactsApp.Core.Results;
using ContactsApp.Core.Utitilies.Contants;
using ContactsApp.WebUI.Models;

namespace ContactsApp.WebUI.Services;

public interface IContactService
{
    Task<BaseDataResponse<IEnumerable<Contact>>> GetAllContactAsync();
    Task<BaseDataResponse<Contact>> GetContactById(string contactId);
    Task<BaseResponse> AddContactAsync(Contact contact);
    Task<BaseResponse> UpdateContactAsync(Contact model);
    Task<BaseResponse> DeleteContactAsync(string contactId);
}

public class ContactService: IContactService
{
    private readonly BaseService _baseService;

    public ContactService(BaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<BaseDataResponse<IEnumerable<Contact>>> GetAllContactAsync()
    {
        var result = await _baseService.DoGetRequest<IEnumerable<Contact>>(ApiHttpClientNameConstant.ContactsAPI, "api/contacts");

        return result;
    }
    public async Task<BaseDataResponse<Contact>> GetContactById(string contactId)
    {
        var result = await _baseService.DoGetRequest<Contact>(ApiHttpClientNameConstant.ContactsAPI, $"api/contactbyid?id={contactId}");

        return result;
    }
    public async Task<BaseResponse> AddContactAsync(Contact contact)
    {
        var result = await _baseService.DoPostRequest(ApiHttpClientNameConstant.ContactsAPI, "api/contacts", contact);

        return result;
    }
    public async Task<BaseResponse> UpdateContactAsync(Contact model)
    {
        var result = await _baseService.DoPutRequest(ApiHttpClientNameConstant.ContactsAPI, $"api/contacts", model);

        return result;
    }
    public async Task<BaseResponse> DeleteContactAsync(string contactId)
    {
        var result = await _baseService.DoDeleteRequest(ApiHttpClientNameConstant.ContactsAPI, $"api/contacts?id={contactId}");

        return result;
    }
}
