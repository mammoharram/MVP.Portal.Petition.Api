using MVP.Portal.Petition.Api.Infrastructure.Entities;

namespace MVP.Portal.Petition.Api.Infrastructure.Repositories
{
    public interface IPetitionerRepository
    {
        Task<PetitionerPersonalInfo> CreatePetitionerPersonalInfoAsync(PetitionerPersonalInfo personalInfo);
        Task<PetitionerPersonalInfo> UpdatePetitionerPersonalInfoAsync(int id, PetitionerPersonalInfo personalInfo);
        Task<bool> DeletePetitionerPersonalInfoByIdAsync(int id);
        Task<IEnumerable<PetitionerPersonalInfo>> GetAllPetitionersPersonalInfoAsync();
        Task<PetitionerPersonalInfo> GetPetitionerPersonalInfoByIdAsync(int id);
    }
}