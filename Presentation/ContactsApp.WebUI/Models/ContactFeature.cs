using ContactsApp.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.WebUI.Models;
public class ContactFeature : BaseEntity, IEntity
{
    [ForeignKey(nameof(Contact))]
    public Guid ContactId { get; set; }
    public string FeatureType { get; set; }
    public string? FeatureInformation { get; set; }
}
