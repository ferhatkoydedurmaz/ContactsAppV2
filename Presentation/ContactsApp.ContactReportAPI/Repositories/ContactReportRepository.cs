﻿using ContactsApp.ContactReportAPI.Data;
using ContactsApp.ContactReportAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsApp.ContactReportAPI.Repositories;

public interface IContactReportRepository
{
    Task<IEnumerable<ContactReport>> GetContactReportsAsync();
    Task<ContactReport> GetContactReportAsync(string id);
    Task<ContactReport> AddContactReportAsync(ContactReport contactReport);
    Task UpdateAsync(string reportId, int statusId);
}

public class ContactReportRepository: IContactReportRepository
{
    private readonly ContactReportContext _context;

    public ContactReportRepository(ContactReportContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ContactReport>> GetContactReportsAsync()
    {
        var result = await _context.ContactReports.ToListAsync();
        return result;
    }

    public async Task<ContactReport> GetContactReportAsync(string id)
    {
        var result = await _context.ContactReports.FindAsync(Guid.Parse(id));

        return result;
    }

    public async Task<ContactReport> AddContactReportAsync(ContactReport contactReport)
    {
        EntityEntry<ContactReport> result = await _context.ContactReports.AddAsync(contactReport);

        if (result.State != EntityState.Added)
            return default;

        await _context.SaveChangesAsync();

        return contactReport;
    }

    public async Task UpdateAsync(string reportId, int statusId)
    {
        var result = await _context.ContactReports.SingleOrDefaultAsync(s => s.Id == Guid.Parse(reportId));

        if (result is null) return;

        result.StatusId = statusId;
        result.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}
