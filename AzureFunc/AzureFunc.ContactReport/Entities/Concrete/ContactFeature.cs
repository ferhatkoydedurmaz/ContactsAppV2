using Dapper.Contrib.Extensions;
using System;

namespace AzureFunc.ContactReport.Entities.Concrete;
[Table("Contacts")]
public class ContactFeature : BaseEntity, IEntity
{
    public Guid ContactId { get; set; }
    public string FeatureType { get; set; }
    public string FeatureInformation { get; set; }
}
