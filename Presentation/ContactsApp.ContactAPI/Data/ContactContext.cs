using ContactsApp.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactAPI.Data;

public interface IContactContext
{
    DbSet<Contact> Contacts { get; set; }
    DbSet<ContactFeature> ContactFeatures { get; set; }
    Task<int> SaveChangesAsync();
}
public class ContactContext : DbContext, IContactContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactFeature> ContactFeatures { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
