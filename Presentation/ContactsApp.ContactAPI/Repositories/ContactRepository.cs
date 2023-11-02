using ContactsApp.ContactAPI.Data;
using ContactsApp.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsApp.ContactAPI.Repositories;

public class ContactRepository
{
    private readonly ContactContext _context;

    public ContactRepository(ContactContext context)
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
