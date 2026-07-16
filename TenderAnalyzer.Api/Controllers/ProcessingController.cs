using Microsoft.AspNetCore.Mvc;
using TenderAnalyzer.Application.Features.Processing;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/processing")]
public class ProcessingController : ControllerBase
{
    private readonly ITenderProcessingService _service;

    public ProcessingController(ITenderProcessingService service)
    {
        _service = service;
    }

    [HttpPost("{tenderId:guid}")]
    public async Task<IActionResult> Process(Guid tenderId)
    {
        await _service.ProcessAsync(tenderId);
        return Ok();
    }
}