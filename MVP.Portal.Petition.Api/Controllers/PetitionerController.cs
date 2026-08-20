using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP.Portal.Petition.Api.Models;
using MVP.Portal.Petition.Api.Services;

namespace MVP.Portal.Petition.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetitionerController(IPetitionerService petitionerService) : ControllerBase
{
    [HttpGet("personal-info/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetitionerPersonalInfoResponse>> GetPetitionerPersonalInfoByIdAsync(int id)
    {
        if (id == 0)
            return BadRequest("Invalid user ID");

        var personalInfo = await petitionerService.GetPetitionerPersonalInfoByIdAsync(id);
        return Ok(personalInfo);
    }

    [HttpGet("personal-info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PetitionerPersonalInfoResponse>>> GetAllPetitionersPersonalInfoAsync() //add pagination parameters
    {
        var allUsersPersonalInfo = await petitionerService.GetAllPetitionersPersonalInfoAsync();

        return Ok(allUsersPersonalInfo);
    }

    [HttpPost("personal-info")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetitionerPersonalInfoResponse>> CreatePetitionerPersonalInfoAsync([FromBody] PetitionerPersonalInfoRequest request)
    {
        if (request == null)
            return BadRequest("Invalid personal info request");

        // Validate the request data here (e.g., check for required fields, data formats, etc.)

        var personalInfo = await petitionerService.CreatePetitionerPersonalInfoAsync(request);

        return CreatedAtAction(nameof(GetPetitionerPersonalInfoByIdAsync), new { id = personalInfo.Id }, personalInfo);
    }


    [HttpPut("personal-info/{id}")]
    [ProducesResponseType(typeof(PetitionerPersonalInfoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PetitionerPersonalInfoResponse>> UpdatePetitionerPersonalInfoAsync(int id, [FromBody] PetitionerPersonalInfoRequest request)
    {
        if (id == 0 || request == null)
            return BadRequest("Invalid petitioner ID or personal info request");

        // Validate the request data here (e.g., check for required fields, data formats, etc.)

        var updatedPersonalInfo = await petitionerService.UpdatePetitionerPersonalInfoAsync(id, request);
        if (updatedPersonalInfo == null)
            return NotFound($"Petitioner with ID {id} not found");

        return Ok(updatedPersonalInfo);
    }

    [HttpDelete("personal-info/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteUserPersonalInfoByIdAsync(int id)
    {
        if (id == 0)
            return BadRequest("Invalid petitioner ID");
        var result = await petitionerService.DeletePetitionerPersonalInfoByIdAsync(id);
        return NoContent();
    }
}
