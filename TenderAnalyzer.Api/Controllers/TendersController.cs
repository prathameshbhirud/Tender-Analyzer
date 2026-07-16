using Microsoft.AspNetCore.Mvc;
using TenderAnalyzer.Application.DTOs.Tenders;
using TenderAnalyzer.Application.Features.Tenders;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TendersController : ControllerBase
{
    private readonly ITenderService _service;

    public TendersController(ITenderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateTenderRequest request)
    {
        var id = await _service.CreateAsync(request);
        return Ok(id);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is required.");

        await using var stream = file.OpenReadStream();

        var result = await _service.UploadAsync(stream, file.FileName);

        return Ok(result);
    }
}