using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Repositories;
using ContactsApp.Core.Results;

namespace ContactsApp.ContactAPI.Services;

public class ContactFeatureService
{
    private readonly ContactFeatureRepository _contactFeatureRepository;

    public ContactFeatureService(ContactFeatureRepository contactFeatureRepository)
    {
        _contactFeatureRepository = contactFeatureRepository;
    }

    public async Task<BaseDataResponse<IEnumerable<ContactFeature>>> GetContactFeaturesByContactId(string contactId)
    {
        try
        {
            if (string.IsNullOrEmpty(contactId) == true)
                return new BaseDataResponse<IEnumerable<ContactFeature>>(default, false, message: "Kayıt bulunamadı");

            var result = await _contactFeatureRepository.GetContactFeaturesByContactIdAsync(contactId);

            return new BaseDataResponse<IEnumerable<ContactFeature>>(result, true);
        }
        catch
        {
            return new BaseDataResponse<IEnumerable<ContactFeature>>(default, false, "Beklenmedik bir hata oluştu");
        }
    }

    public async Task<BaseDataResponse<ContactFeatureList>> AddOrUpdateAsync(ContactFeatureList model)
    {
        try
        {
            foreach (var feature in model.ContactFeatures)
            {

                var contactFeature = await GetContactFeatureByContactIdAndFeatureType(feature.ContactId.ToString(), feature.FeatureType);

                if (contactFeature is null)
                    await _contactFeatureRepository.AddAsync(feature);
                else
                {
                    contactFeature.UpdatedAt = DateTime.UtcNow;
                    contactFeature.FeatureInformation = feature.FeatureInformation;
                    await _contactFeatureRepository.UpdateAsync(contactFeature);
                }
            }

            return new BaseDataResponse<ContactFeatureList>(model, true);
        }
        catch
        {

            return new BaseDataResponse<ContactFeatureList>(default, false, "Beklenmedik bir hata oluştu");
        }
    }
    private async Task<ContactFeature> GetContactFeatureByContactIdAndFeatureType(string contactId, string featureType)
    {
        var result = await _contactFeatureRepository.GetByContactIdAndFeatureType(contactId, featureType);

        return result;
    }
}
