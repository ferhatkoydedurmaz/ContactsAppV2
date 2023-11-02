using ContactsApp.ContactAPI.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ContactsApp.ContactAPI.Models;
using ContactsApp.Core.Results;

namespace ContactsApp.ContactAPI.Services;

public class ContactService
{
    private readonly ContactRepository _contactRepository;

    public ContactService(ContactRepository contactRepository)
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
        var result = await _contactRepository.GetContactAsync(id);

        return new BaseDataResponse<Contact>(result, true);
    }

    public async Task<BaseResponse> AddContactAsync(Contact contact)
    {
        var result = await _contactRepository.AddContactAsync(contact);

        if (!result)
            return new BaseResponse(false, "Contact could not be added");

        return new BaseResponse(true, "Contact added successfully");

    }

    public async Task<BaseResponse> UpdateContactAsync(Contact contact)
    {
        var result = await _contactRepository.UpdateContactAsync(contact);

        if (!result)
            return new BaseResponse(false, "Contact could not be updated"); 

        return new BaseResponse(true, "Contact updated successfully");
    }

    public async Task<BaseResponse> DeleteContactAsync(string id)
    {
        var result = await _contactRepository.DeleteContactAsync(id);

        if (!result)
            return new BaseResponse(false, "Contact could not be deleted");

        return new BaseResponse(true, "Contact deleted successfully");
    }
}
