using ContactsApp.ContactReportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactReportAPI.Data;


public interface IContactReportContext
{
    DbSet<ContactReport> ContactReports { get; set; }
    DbSet<ContactReportDetail> ContactReportDetails { get; set; }
    Task<int> SaveChangesAsync();
}

public class ContactReportContext : DbContext, IContactReportContext
{
    public ContactReportContext(DbContextOptions<ContactReportContext> options) : base(options)
    {

    }

    public DbSet<ContactReport> ContactReports { get; set; }
    public DbSet<ContactReportDetail> ContactReportDetails { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}
