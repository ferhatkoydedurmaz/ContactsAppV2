using ContactsApp.ContactReportAPI.Models;
using ContactsApp.ContactReportAPI.Repositories;
using ContactsApp.Core.Enums;
using ContactsApp.Core.Results;

namespace ContactsApp.ContactReportAPI.Services;

public interface IContactReportDetailService
{
    Task CreateReportDetailAsync(List<ContactReportDetail> reportDetails);
    Task<BaseDataResponse<List<ContactReportDetail>>> GetContactReportDetailsByReportIdAsync(string reportId);
}

public class ContactReportDetailService: IContactReportDetailService
{
    private readonly IContactReportDetailRepository _contactReportDetailRepository;
    private readonly IContactReportService _contactReportService;

    public ContactReportDetailService(IContactReportDetailRepository contactReportDetailRepository, IContactReportService contactReportService)
    {
        _contactReportDetailRepository = contactReportDetailRepository;
        _contactReportService = contactReportService;
    }

    public async Task CreateReportDetailAsync(List<ContactReportDetail> reportDetails)
    {
        await _contactReportDetailRepository.AddAsync(reportDetails);
        await _contactReportService.UpdateStatus(reportDetails.First().ContactReportId.ToString(), ContactReportStatusEnum.Tamamlandı);
    }

    public async Task<BaseDataResponse<List<ContactReportDetail>>> GetContactReportDetailsByReportIdAsync(string reportId)
    {
        var result = await _contactReportDetailRepository.ContactReportDetailsByReportIdAsync(reportId);
        return new BaseDataResponse<List<ContactReportDetail>>(result, true);
    }

}
