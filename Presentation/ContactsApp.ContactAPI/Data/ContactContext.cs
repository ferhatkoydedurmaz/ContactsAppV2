using ContactsApp.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactAPI.Data;

public class ContactContext:DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactFeature> ContactFeatures { get; set; }
}
