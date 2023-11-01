using ContactsApp.Core.Entities;

namespace ContactsApp.WebUI.Models;
public class ContactReport : BaseEntity, IEntity
{
    public int StatusId { get; set; }
    public ICollection<ContactReportDetail> ContactFeatures { get; }
}
