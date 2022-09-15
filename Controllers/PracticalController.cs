using JustCause.Dtos;
using JustCause.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCause.Controllers;

[Route("api/practicals")]
[ApiController]
public class PracticalController : ControllerBase
{
	private readonly IServiceManager serviceManager;

	public PracticalController(IServiceManager serviceManager)
	{
		this.serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<ActionResult<List<PracticalDto>>> GetAllPracticals()
	{
		var practicals = await serviceManager.PracticalService.GetAllPracticalsAsync();
		return Ok(practicals);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<PracticalDto>> GetPractical(int id)
	{
		var practical = await serviceManager.PracticalService.GetPracticalAsync(id);
        return practical ?? (ActionResult<PracticalDto>)NotFound();
    }

	[HttpPost]
	public async Task<ActionResult<PracticalDto>> CreatePractical(PracticalDto practical)
	{
		var practicalToReturn = await serviceManager.PracticalService.CreatePracticalAsync(practical);
		await serviceManager.Save();
		return Ok(practicalToReturn);
	}

	[HttpDelete("{practicalId:int}")]
	public async Task<ActionResult> DeletePractical(int practicalId)
	{
        await serviceManager.PracticalService.DeletePracticalAsync(practicalId);
        await serviceManager.Save();
        return NoContent();
    }

	[HttpPut]
	public async Task<ActionResult<PracticalDto>> UpdatePractical(PracticalDto practicalDto)
	{
        var practical = await serviceManager.PracticalService.UpdatePracticalAsync(practicalDto);
        await serviceManager.Save();
        return Ok(practical);
    }


}
