using ContactsApp.ContactAPI.Data;
using ContactsApp.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsApp.ContactAPI.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetContactsAsync();
    Task<Contact> GetContactAsync(string id);
    Task<bool> AddContactAsync(Contact contact);
    Task<bool> UpdateContactAsync(Contact contact);
    Task<bool> DeleteContactAsync(string id);
}

public class ContactRepository: IContactRepository
{
    private readonly IContactContext _context;

    public ContactRepository(IContactContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetContactsAsync()
    {
        var result = await _context.Contacts.ToListAsync();
        return result;
    }

    public async Task<Contact> GetContactAsync(string id)
    {
        var result = await _context.Contacts.FindAsync(Guid.Parse(id));

        return result;
    }

    public async Task<bool> AddContactAsync(Contact contact)
    {
        EntityEntry<Contact> result = await _context.Contacts.AddAsync(contact);

        if (result.State != EntityState.Added)
            return false;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateContactAsync(Contact contact)
    {
        EntityEntry<Contact> result = _context.Contacts.Update(contact);

        if (result.State != EntityState.Modified)
            return false;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteContactAsync(string id)
    {
        var contact = await _context.Contacts.FindAsync(Guid.Parse(id));

        if (contact == null)
            return false;

        EntityEntry<Contact> result = _context.Contacts.Remove(contact);

        if (result.State != EntityState.Deleted)
            return false;

        await _context.SaveChangesAsync();

        return true;
    }   
}
