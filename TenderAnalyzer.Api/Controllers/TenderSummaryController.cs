using Microsoft.AspNetCore.Mvc;
using TenderAnalyzer.Application.Features.Summary;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/tender-summary")]
public class TenderSummaryController : ControllerBase
{
    private readonly ITenderSummaryService _service;

    public TenderSummaryController(ITenderSummaryService service)
    {
        _service = service;
    }

    [HttpPost("{tenderId:guid}")]
    public async Task<IActionResult> Generate(Guid tenderId)
    {
        await _service.GenerateAsync(tenderId);
        return Ok();
    }

    [HttpGet("{tenderId:guid}")]
    public async Task<IActionResult> Get(Guid tenderId)
    {
        var result = await _service.GetLatestAsync(tenderId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}