using ContactsApp.Core.Entities;

namespace ContactsApp.WebUI.Models;
public class Contact : BaseEntity, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
}
