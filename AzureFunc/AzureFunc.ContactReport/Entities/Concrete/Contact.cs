using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace AzureFunc.ContactReport.Entities.Concrete;
[Table("Contacts")]
public class Contact : BaseEntity, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public ICollection<ContactFeature> ContactFeatures { get; } = new List<ContactFeature>();
}
