namespace MVP.Portal.Petition.Api.Infrastructure.Entities;

public class PetitionerPersonalInfo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string CountryOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string HomeAddress { get; set; }
}
