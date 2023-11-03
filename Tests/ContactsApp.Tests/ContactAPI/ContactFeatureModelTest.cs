using ContactsApp.ContactAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Tests.ContactAPI;
public class ContactFeatureModelTest
{
    [Fact]
    public void ContactFeature_ContactId_SetAndGetCorrectly()
    {
        // Arrange
        var contactFeature = new ContactFeature();
        var contactId = Guid.NewGuid();

        // Act
        contactFeature.ContactId = contactId;

        // Assert
        Assert.Equal(contactId, contactFeature.ContactId);
    }

    [Fact]
    public void ContactFeature_FeatureType_SetAndGetCorrectly()
    {
        // Arrange
        var contactFeature = new ContactFeature();
        var featureType = "Email";

        // Act
        contactFeature.FeatureType = featureType;

        // Assert
        Assert.Equal(featureType, contactFeature.FeatureType);
    }

    [Fact]
    public void ContactFeature_FeatureInformation_SetAndGetCorrectly()
    {
        // Arrange
        var contactFeature = new ContactFeature();
        var featureInformation = "contact@test.com"; 

        // Act
        contactFeature.FeatureInformation = featureInformation;

        // Assert
        Assert.Equal(featureInformation, contactFeature.FeatureInformation);
    }

    [Fact]
    public void ContactFeature_ContactId_HasForeignKeyAttribute()
    {
        // Arrange
        var contactFeature = new ContactFeature();

        // Act
        var property = contactFeature.GetType().GetProperty("ContactId");
        var hasForeignKeyAttribute = Attribute.IsDefined(property, typeof(ForeignKeyAttribute));

        // Assert
        Assert.True(hasForeignKeyAttribute);
    }
    [Fact]
    public void ContactFeatureList_ContactFeatures_SetAndGetCorrectly()
    {
        // Arrange
        var contactFeatureList = new ContactFeatureList();
        var contactFeatures = new List<ContactFeature>();

        // Act
        contactFeatureList.ContactFeatures = contactFeatures;

        // Assert
        Assert.Same(contactFeatures, contactFeatureList.ContactFeatures);
    }

    [Fact]
    public void ContactFeatureList_ContactFeatures_Initialized()
    {
        // Arrange
        var contactFeatureList = new ContactFeatureList();

        // Act and Assert
        Assert.NotNull(contactFeatureList.ContactFeatures);
    }

    [Fact]
    public void ContactFeatureList_ContactFeatures_NotNullByDefault()
    {
        // Arrange and Act
        var contactFeatureList = new ContactFeatureList();

        // Assert
        Assert.NotNull(contactFeatureList.ContactFeatures);
    }
}
