using MVP.Portal.Petition.Api.Infrastructure.Entities;
using MVP.Portal.Petition.Api.Infrastructure.Repositories;
using MVP.Portal.Petition.Api.Models;

namespace MVP.Portal.Petition.Api.Services;

public class PetitionerService(IPetitionerRepository petitionerRepo) : IPetitionerService
{
    public async Task<PetitionerPersonalInfoResponse> GetPetitionerPersonalInfoByIdAsync(int id)
    {
        var personalInfo = await petitionerRepo.GetPetitionerPersonalInfoByIdAsync(id);

        if(personalInfo == null)
            return null;

        var response = new PetitionerPersonalInfoResponse
        {
            Id = personalInfo.Id,
            FirstName = personalInfo.FirstName,
            LastName = personalInfo.LastName,
            DateOfBirth = personalInfo.DateOfBirth,
            CountryOfBirth = personalInfo.CountryOfBirth,
            Phone = personalInfo.Phone,
            Email = personalInfo.Email,
            HomeAddress = personalInfo.HomeAddress
        };
        return response;
    }

    public async Task<IEnumerable<PetitionerPersonalInfoResponse>> GetAllPetitionersPersonalInfoAsync()
    {
        IEnumerable<PetitionerPersonalInfo> allPersonalInfo = await petitionerRepo.GetAllPetitionersPersonalInfoAsync();
        var responseList = allPersonalInfo.Select(personalInfo => new PetitionerPersonalInfoResponse
        {
            Id = personalInfo.Id,
            FirstName = personalInfo.FirstName,
            LastName = personalInfo.LastName,
            DateOfBirth = personalInfo.DateOfBirth,
            CountryOfBirth = personalInfo.CountryOfBirth,
            Phone = personalInfo.Phone,
            Email = personalInfo.Email,
            HomeAddress = personalInfo.HomeAddress
        });    

        return responseList;
    }
    public Task<bool> DeletePetitionerPersonalInfoByIdAsync(int id)
    {
        return petitionerRepo.DeletePetitionerPersonalInfoByIdAsync(id);
    }


    public async Task<PetitionerPersonalInfoResponse> CreatePetitionerPersonalInfoAsync(PetitionerPersonalInfoRequest request)
    {
        var personalInfo = new PetitionerPersonalInfo
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            CountryOfBirth = request.CountryOfBirth,
            Phone = request.Phone,
            Email = request.Email,
            HomeAddress = request.HomeAddress
        };
        var createdPersonalInfo = await petitionerRepo.CreatePetitionerPersonalInfoAsync(personalInfo);
        return new PetitionerPersonalInfoResponse
        {
            Id = createdPersonalInfo.Id,
            FirstName = createdPersonalInfo.FirstName,
            LastName = createdPersonalInfo.LastName,
            DateOfBirth = createdPersonalInfo.DateOfBirth,
            CountryOfBirth = createdPersonalInfo.CountryOfBirth,
            Phone = createdPersonalInfo.Phone,
            Email = createdPersonalInfo.Email,
            HomeAddress = createdPersonalInfo.HomeAddress
        };
    }

    public async Task<PetitionerPersonalInfoResponse> UpdatePetitionerPersonalInfoAsync(int id, PetitionerPersonalInfoRequest request)
    {
        PetitionerPersonalInfo personalInfo = await petitionerRepo.GetPetitionerPersonalInfoByIdAsync(id);
        
        if(personalInfo == null) return null;

        personalInfo.FirstName = request.FirstName;
        personalInfo.LastName = request.LastName;
        personalInfo.DateOfBirth = request.DateOfBirth;
        personalInfo.CountryOfBirth = request.CountryOfBirth;
        personalInfo.Phone = request.Phone;
        personalInfo.Email = request.Email;
        personalInfo.HomeAddress = request.HomeAddress;

        var updatedPersonalInfo = await petitionerRepo.UpdatePetitionerPersonalInfoAsync(id, personalInfo);
        return new PetitionerPersonalInfoResponse
        {
            Id = updatedPersonalInfo.Id,
            FirstName = updatedPersonalInfo.FirstName,
            LastName = updatedPersonalInfo.LastName,
            DateOfBirth = updatedPersonalInfo.DateOfBirth,
            CountryOfBirth = updatedPersonalInfo.CountryOfBirth,
            Phone = updatedPersonalInfo.Phone,
            Email = updatedPersonalInfo.Email,
            HomeAddress = updatedPersonalInfo.HomeAddress
        };
    }

}
