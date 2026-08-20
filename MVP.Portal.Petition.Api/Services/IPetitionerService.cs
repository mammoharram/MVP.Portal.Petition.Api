using MVP.Portal.Petition.Api.Models;

namespace MVP.Portal.Petition.Api.Services;

public interface IPetitionerService
{
    Task<PetitionerPersonalInfoResponse> CreatePetitionerPersonalInfoAsync(PetitionerPersonalInfoRequest request);
    Task<bool> DeletePetitionerPersonalInfoByIdAsync(int id);
    Task<IEnumerable<PetitionerPersonalInfoResponse>> GetAllPetitionersPersonalInfoAsync();
    Task<PetitionerPersonalInfoResponse> GetPetitionerPersonalInfoByIdAsync(int id);
    Task<PetitionerPersonalInfoResponse> UpdatePetitionerPersonalInfoAsync(int id, PetitionerPersonalInfoRequest request);
}