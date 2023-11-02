using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactFeatureController : ControllerBase
{
    private readonly ContactFeatureService _contactFeatureService;

    public ContactFeatureController(ContactFeatureService contactFeatureService)
    {
        _contactFeatureService = contactFeatureService;
    }

    [HttpGet("contact-details")]
    public async Task<IActionResult> GetContactFeatures([FromQuery] string id)
    {
        var result = await _contactFeatureService.GetContactFeaturesByContactId(id);

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpPost("contact-details")]
    public async Task<IActionResult> AddOrUpdateContact(ContactFeatureList model)
    {
        var result = await _contactFeatureService.AddOrUpdateAsync(model);

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
}
