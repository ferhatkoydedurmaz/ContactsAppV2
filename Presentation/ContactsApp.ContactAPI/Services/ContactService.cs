using ContactsApp.ContactAPI.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ContactsApp.ContactAPI.Models;
using ContactsApp.Core.Results;

namespace ContactsApp.ContactAPI.Services;
public interface IContactService
{
    Task<BaseDataResponse<IEnumerable<Contact>>> GetContactsAsync();
    Task<BaseDataResponse<Contact>> GetContactAsync(string id);
    Task<BaseResponse> AddContactAsync(Contact contact);
    Task<BaseResponse> UpdateContactAsync(Contact contact);
    Task<BaseResponse> DeleteContactAsync(string id);
}
public class ContactService: IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<BaseDataResponse<IEnumerable<Contact>>> GetContactsAsync()
    {
        var result = await _contactRepository.GetContactsAsync();

        return new BaseDataResponse<IEnumerable<Contact>>(result, true);
    }

    public async Task<BaseDataResponse<Contact>> GetContactAsync(string id)
    {
        if(string.IsNullOrEmpty(id) == true)
            return new BaseDataResponse<Contact>(default, false, "Id cannot be null");

        var result = await _contactRepository.GetContactAsync(id);

        if(result is null || result.FirstName is null)
            return new BaseDataResponse<Contact>(default, false, "Contact not found");

        return new BaseDataResponse<Contact>(result, true);
    }

    public async Task<BaseResponse> AddContactAsync(Contact contact)
    {
        if (contact is null || contact.FirstName is null)
            return new BaseResponse(false, "FirstName cannot be null");

        var result = await _contactRepository.AddContactAsync(contact);

        if (!result)
            return new BaseResponse(false, "Contact could not be added");

        return new BaseResponse(true, "Contact added successfully");

    }

    public async Task<BaseResponse> UpdateContactAsync(Contact contact)
    {

        if (contact is null || contact.FirstName is null)
            return new BaseResponse(false, "FirstName cannot be null");

        var result = await _contactRepository.UpdateContactAsync(contact);

        if (!result)
            return new BaseResponse(false, "Contact could not be updated"); 

        return new BaseResponse(true, "Contact updated successfully");
    }

    public async Task<BaseResponse> DeleteContactAsync(string id)
    {
        if(string.IsNullOrEmpty(id) == true)
            return new BaseResponse(false, "Id cannot be null");

        var result = await _contactRepository.DeleteContactAsync(id);

        if (!result)
            return new BaseResponse(false, "Contact could not be deleted");

        return new BaseResponse(true, "Contact deleted successfully");
    }
}
