using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Repositories;
using ContactsApp.Core.Results;

namespace ContactsApp.ContactAPI.Services;
public interface IContactFeatureService
{
    Task<BaseDataResponse<IEnumerable<ContactFeature>>> GetContactFeaturesByContactIdAsync(string contactId);
    Task<BaseDataResponse<ContactFeatureList>> AddOrUpdateAsync(ContactFeatureList model);
}
public class ContactFeatureService: IContactFeatureService
{
    private readonly IContactFeatureRepository _contactFeatureRepository;

    public ContactFeatureService(IContactFeatureRepository contactFeatureRepository)
    {
        _contactFeatureRepository = contactFeatureRepository;
    }

    public async Task<BaseDataResponse<IEnumerable<ContactFeature>>> GetContactFeaturesByContactIdAsync(string contactId)
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

                var contactFeature = await GetContactFeatureByContactIdAndFeatureTypeAsync(feature.ContactId.ToString(), feature.FeatureType);

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
    private async Task<ContactFeature> GetContactFeatureByContactIdAndFeatureTypeAsync(string contactId, string featureType)
    {
        var result = await _contactFeatureRepository.GetByContactIdAndFeatureType(contactId, featureType);

        return result;
    }
}
