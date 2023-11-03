using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactReportAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Tests.ContactAPI;
public class ContactModelTest
{
    [Fact]
    public void Contact_FirstName_SetAndGetCorrectly()
    {
        // Arrange
        var contact = new Contact();
        var firstName = "test";

        // Act
        contact.FirstName = firstName;

        // Assert
        Assert.Equal(firstName, contact.FirstName);
    }

    [Fact]
    public void Contact_LastName_SetAndGetCorrectly()
    {
        // Arrange
        var contact = new Contact();
        var lastName = "test";

        // Act
        contact.LastName = lastName;

        // Assert
        Assert.Equal(lastName, contact.LastName);
    }

    [Fact]
    public void Contact_CompanyName_SetAndGetCorrectly()
    {
        // Arrange
        var contact = new Contact();
        var companyName = "Test";

        // Act
        contact.CompanyName = companyName;

        // Assert
        Assert.Equal(companyName, contact.CompanyName);
    }

    [Fact]
    public void Contact_ContactFeatures_Initialized()
    {
        // Arrange
        var contact = new Contact();

        // Act and Assert
        Assert.NotNull(contact.ContactFeatures);
    }

    [Fact]
    public void Contact_ContactFeatures_NotNullByDefault()
    {
        // Arrange and Act
        var contact = new Contact();

        // Assert
        Assert.NotNull(contact.ContactFeatures);
    }
    [Fact]
    public void ContactReportDetail_Id_SetAndGetCorrectly()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();
        var id = Guid.NewGuid();

        // Act
        contactReportDetail.Id = id;

        // Assert
        Assert.Equal(id, contactReportDetail.Id);
    }

    [Fact]
    public void ContactReportDetail_ContactReportId_SetAndGetCorrectly()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();
        var contactReportId = Guid.NewGuid();

        // Act
        contactReportDetail.ContactReportId = contactReportId;

        // Assert
        Assert.Equal(contactReportId, contactReportDetail.ContactReportId);
    }

    [Fact]
    public void ContactReportDetail_Address_SetAndGetCorrectly()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();
        var address = "test";

        // Act
        contactReportDetail.Address = address;

        // Assert
        Assert.Equal(address, contactReportDetail.Address);
    }

    [Fact]
    public void ContactReportDetail_ContactCount_SetAndGetCorrectly()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();
        var contactCount = 10;

        // Act
        contactReportDetail.ContactCount = contactCount;

        // Assert
        Assert.Equal(contactCount, contactReportDetail.ContactCount);
    }

    [Fact]
    public void ContactReportDetail_PhoneCount_SetAndGetCorrectly()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();
        var phoneCount = 5;

        // Act
        contactReportDetail.PhoneCount = phoneCount;

        // Assert
        Assert.Equal(phoneCount, contactReportDetail.PhoneCount);
    }

    [Fact]
    public void ContactReportDetail_Id_HasKeyAttribute()
    {
        // Arrange
        var contactReportDetail = new ContactReportDetail();

        // Act
        var property = contactReportDetail.GetType().GetProperty("Id");
        var hasKeyAttribute = Attribute.IsDefined(property, typeof(KeyAttribute));

        // Assert
        Assert.True(hasKeyAttribute);
    }
}
