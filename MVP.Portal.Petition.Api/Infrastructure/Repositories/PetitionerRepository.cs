using MVP.Portal.Petition.Api.Infrastructure.Entities;

namespace MVP.Portal.Petition.Api.Infrastructure.Repositories;

public class PetitionerRepository : IPetitionerRepository
{
    public Task<PetitionerPersonalInfo> CreatePetitionerPersonalInfoAsync(PetitionerPersonalInfo personalInfo)
    {
        return Task.FromResult(personalInfo);
    }

    public Task<bool> DeletePetitionerPersonalInfoByIdAsync(int id)
    {
        return Task.FromResult(true);
    }

    public Task<IEnumerable<PetitionerPersonalInfo>> GetAllPetitionersPersonalInfoAsync()
    {
        var personalInfoList = new List<PetitionerPersonalInfo>
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 1, 1),
                CountryOfBirth = "USA",
                Phone = "123-456-7890",
                Email = "john.doe@example.com",
                HomeAddress = "123 Main St, Anytown, USA"
            },
            new()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateOnly(1985, 5, 15),
                CountryOfBirth = "Canada",
                Phone = "987-654-3210",
                Email = "jane.smith@example.com",
                HomeAddress = "456 Oak Ave, Anycity, Canada"
            },
            new()
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Johnson",
                DateOfBirth = new DateOnly(1992, 3, 10),
                CountryOfBirth = "UK",
                Phone = "555-123-4567",
                Email = "alice.johnson@example.com",
                HomeAddress = "789 Pine Rd, Anytown, UK"
            },
            new() {
                Id = 4,
                FirstName = "Bob",
                LastName = "Brown",
                DateOfBirth = new DateOnly(1988, 7, 20),
                CountryOfBirth = "Australia",
                Phone = "444-987-6543",
                Email = "bob.brown@example.com",
                HomeAddress = "101 Elm St, Anytown, Australia"
            },
            new() {
                Id = 5,
                FirstName = "Charlie",
                LastName = "Davis",
                DateOfBirth = new DateOnly(1995, 12, 5),
                CountryOfBirth = "New Zealand",
                Phone = "333-555-7777",
                Email = "charlie.davis@example.com",
                HomeAddress = "202 Maple Dr, Anytown, New Zealand"
            }
        };
        return Task.FromResult<IEnumerable<PetitionerPersonalInfo>>(personalInfoList);
    }

    public Task<PetitionerPersonalInfo> GetPetitionerPersonalInfoByIdAsync(int id)
    { 
        return Task.FromResult(new PetitionerPersonalInfo
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateOnly(1990, 1, 1),
            CountryOfBirth = "USA",
            Phone = "123-456-7890",
            Email = "john.doe@example.com",
            HomeAddress = "123 Main St, Anytown, USA"
        });
    }

    public Task<PetitionerPersonalInfo> UpdatePetitionerPersonalInfoAsync(int id, PetitionerPersonalInfo personalInfo)
    {
        return Task.FromResult(personalInfo);
    }
}
