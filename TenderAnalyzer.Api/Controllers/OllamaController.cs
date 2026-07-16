using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace TenderAnalyzer.Api.Controllers;

[ApiController]
[Route("api/ollama")]
public class OllamaController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public OllamaController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        try
        {
            var request = new
            {
                model = "phi3:mini",
                prompt = "Summarize this: Tender for CCTV installation in Mumbai.",
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", request);

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                StatusCode = (int)response.StatusCode,
                Response = content
            });
        }
        catch (Exception ex)
        {
            return Ok(new
            {
                Error = ex.Message,
                InnerException = ex.InnerException?.Message
            });
        }
    }
}