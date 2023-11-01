using ContactsApp.ContactReportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactReportAPI.Data;

public class ContactReportContext : DbContext
{
    public ContactReportContext(DbContextOptions<ContactReportContext> options) : base(options)
    {

    }

    public DbSet<ContactReport> ContactReports { get; set; }
    public DbSet<ContactReportDetail> ContactReportDetails { get; set; }

}
