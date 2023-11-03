using ContactsApp.ContactReportAPI.Data;
using ContactsApp.ContactReportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactReportAPI.Repositories;

public interface IContactReportDetailRepository
{
    Task<bool> AddAsync(List<ContactReportDetail> reportDetails);
    Task<List<ContactReportDetail>> ContactReportDetailsByReportIdAsync(string reportId);
}
public class ContactReportDetailRepository: IContactReportDetailRepository
{
    private readonly ContactReportContext _context;

    public ContactReportDetailRepository(ContactReportContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(List<ContactReportDetail> reportDetails)
    {
        await _context.ContactReportDetails.AddRangeAsync(reportDetails);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ContactReportDetail>> ContactReportDetailsByReportIdAsync(string reportId)
    {
        var result = await _context.ContactReportDetails.Where(s => s.ContactReportId == Guid.Parse(reportId)).ToListAsync();

        return result;
    }
}
