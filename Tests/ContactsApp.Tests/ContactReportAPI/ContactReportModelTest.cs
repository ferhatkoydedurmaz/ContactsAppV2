using ContactsApp.ContactReportAPI.Models;

namespace ContactsApp.Tests.ContactReportAPI;
public class ContactReportModelTest
{
    [Fact]
    public void ContactReport_StatusId_SetAndGetCorrectly()
    {
        // Arrange
        var contactReport = new ContactReport();
        var statusId = 1;

        // Act
        contactReport.StatusId = statusId;

        // Assert
        Assert.Equal(statusId, contactReport.StatusId);
    }

    [Fact]
    public void ContactReport_ContactFeatures_Initialized()
    {
        // Arrange
        var contactReport = new ContactReport();

        // Act and Assert
        Assert.NotNull(contactReport.ContactFeatures);
    }

    [Fact]
    public void ContactReport_ContactFeatures_NotNullByDefault()
    {
        // Arrange and Act
        var contactReport = new ContactReport();

        // Assert
        Assert.NotNull(contactReport.ContactFeatures);
    }
}
