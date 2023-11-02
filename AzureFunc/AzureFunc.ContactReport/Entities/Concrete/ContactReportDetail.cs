using System;
using System.ComponentModel.DataAnnotations;

namespace AzureFunc.ContactReport.Entities.Concrete;
public class ContactReportDetail
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    public Guid ContactReportId { get; set; }
    public string Address { get; set; }
    public int ContactCount { get; set; }
    public int PhoneCount { get; set; }
}
