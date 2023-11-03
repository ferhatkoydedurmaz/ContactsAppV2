using ContactsApp.ContactAPI.Data;
using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;

namespace ContactsApp.Tests.ContactAPI;
public class ContactRepositoryTest
{
    private readonly Mock<IContactContext> _contactContext;
    private readonly IContactRepository _contactRepository;
    private readonly Mock<DbSet<Contact>> _dbSet;
    private readonly Mock<EntityEntry<Contact>> _entityEntry;
    private readonly Guid _contactId = Guid.NewGuid();

    public ContactRepositoryTest()
    {
        _contactContext = new Mock<IContactContext>(MockBehavior.Loose);
        _contactRepository = new ContactRepository(_contactContext.Object);
        _dbSet = new Mock<DbSet<Contact>>();
        _entityEntry = new Mock<EntityEntry<Contact>>();
    }

    [Fact]
    public async Task GetContactsAsync_ReturnsTrue()
    {
        _contactContext.Setup(c => c.Contacts).ReturnsDbSet(new List<Contact>() { new Contact() { Id = _contactId, FirstName = "test", CompanyName = "test", LastName = "test" } });

        var result = await _contactRepository.GetContactsAsync();

        Assert.NotNull(result);
        Assert.True(result.Any());
    }

    [Fact]
    public async Task GetContactAsync_WithValidId_ReturnsContact()
    {
        var contact = new Contact { Id = _contactId, FirstName = "John", LastName = "Doe" };

        _contactContext.Setup(c => c.Contacts.FindAsync(It.IsAny<Guid>())).ReturnsAsync(contact);

        var result = await _contactRepository.GetContactAsync(_contactId.ToString());

        Assert.NotNull(result);
        Assert.Equal(_contactId, result.Id);
    }

    //[Fact]
    //public async Task DeleteContactAsync_ContactExists_ReturnsTrue()
    //{
    //    // Arrange

    //    _contactContext.Setup(c => c.Contacts).Returns(_dbSet.Object);
    //    _dbSet.Setup(s => s.FindAsync(It.IsAny<object[]>())).ReturnsAsync(new Contact { Id = _contactId });
    //    _contactContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1); // Simulate a successful save.

    //    // Act
    //    var result = await _contactRepository.DeleteContactAsync(_contactId.ToString());

    //    //Assert
    //    Assert.True(true);
    //    _dbSet.Verify(s => s.FindAsync(It.IsAny<object[]>()), Times.Once());
    //    _dbSet.Verify(s => s.Remove(It.IsAny<Contact>()), Times.Once());
    //    _contactContext.Verify(c => c.SaveChangesAsync(), Times.Once());
    //}

    [Fact]
    public async Task DeleteContactAsync_ContactDoesNotExist_ReturnsFalse()
    {
        // Arrange
        _contactContext.Setup(c => c.Contacts).Returns(_dbSet.Object);
        _dbSet.Setup(s => s.FindAsync(It.IsAny<object[]>())).ReturnsAsync((Contact)null); // Simulate contact not found.

        // Act
        var result = await _contactRepository.DeleteContactAsync(_contactId.ToString());

        // Assert
        Assert.False(result);
        _dbSet.Verify(s => s.FindAsync(It.IsAny<object[]>()), Times.Once());
    }
}
