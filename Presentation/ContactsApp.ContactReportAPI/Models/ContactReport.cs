using ContactsApp.Core.Entities;

namespace ContactsApp.ContactReportAPI.Models;
public class ContactReport : BaseEntity, IEntity
{
    public int StatusId { get; set; }
    public ICollection<ContactReportDetail> ContactFeatures { get; } = new List<ContactReportDetail>();
}
