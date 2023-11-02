using ContactsApp.ContactAPI.Data;
using ContactsApp.ContactAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsApp.ContactAPI.Repositories;

public class ContactFeatureRepository
{
    private readonly ContactContext _context;

    public ContactFeatureRepository(ContactContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ContactFeature>> GetContactFeaturesByContactIdAsync(string contactId)
    {
        var result = await _context.ContactFeatures?.Where(s => s.ContactId == Guid.Parse(contactId))?.ToListAsync();
        return result;
    }

    public async Task<ContactFeature> GetByContactIdAndFeatureType(string contactId, string featureType)
    {
        var result = await _context.ContactFeatures.SingleOrDefaultAsync(s => s.ContactId == Guid.Parse(contactId) && s.FeatureType == featureType);
        return result;
    }

    public async Task<bool> AddAsync(ContactFeature model)
    {
        EntityEntry<ContactFeature> add = await _context.ContactFeatures.AddAsync(model);

        if (add.State != EntityState.Added)
            return false;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(ContactFeature model)
    {

        var contactFeatures = await _context.ContactFeatures.FindAsync(model.Id);

        if (contactFeatures is null)
            return false;

        contactFeatures.FeatureType = model.FeatureType;
        contactFeatures.FeatureInformation = model.FeatureInformation;
        contactFeatures.UpdatedAt = model.UpdatedAt;

        await _context.SaveChangesAsync();
        return true;
    }
}
    