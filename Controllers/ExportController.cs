using JustCause.Dtos;
using JustCause.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JustCause.Controllers;

[Route("api/export")]
[ApiController]
public class ExportController : ControllerBase
{
	private readonly IServiceManager serviceManager;
	private readonly string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
	public ExportController(IServiceManager serviceManager)
	{
		this.serviceManager = serviceManager;
	}

	[HttpGet("{practicalId:int}")]
	public async Task<ActionResult> ServeFile(int practicalId)
	{
        List<PracticalDto> practicals = new();
        if(practicalId == 0)
		{
            practicals.AddRange( await serviceManager.PracticalService.GetAllPracticalsAsync()
			);
        }
		else
		{
            var practical = await serviceManager.PracticalService.GetPracticalAsync(practicalId);
			if(practical != null)
            	practicals.Add(practical!);
        }
        var fileName = "Registrations" + DateTime.Now.ToLongDateString()+".xlsx";
        return File(serviceManager.ExportService.CreateExport(practicals), contentType,fileName);
    }
}
