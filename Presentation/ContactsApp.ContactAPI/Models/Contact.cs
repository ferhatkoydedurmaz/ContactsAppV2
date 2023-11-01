using ContactsApp.Core.Entities;

namespace ContactsApp.ContactAPI.Models;
public class Contact : BaseEntity, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public ICollection<ContactFeature> ContactFeatures { get; }
}
