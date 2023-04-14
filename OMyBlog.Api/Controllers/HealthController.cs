using Microsoft.AspNetCore.Mvc;
using OMyBlog.Domain.Contracts.Services;

namespace OMyBlog.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HealthController : Controller
{
    private readonly IHealthCheckService _healthCheckService;

    public HealthController(IHealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    [HttpGet("db")]
    public async Task<IActionResult> CheckDb()
    {
        var isHealthy = await _healthCheckService.PingDb();

        return isHealthy
            ? Ok("Healthy")
            : StatusCode(StatusCodes.Status503ServiceUnavailable, "Unhealthy");
    }    
    
    [HttpGet("elasticsearch")]
    public async Task<IActionResult> CheckElasticSearch()
    {
        var isHealthy = await _healthCheckService.PingElasticSearch();
        
        return isHealthy
            ? Ok("Healthy")
            : StatusCode(StatusCodes.Status503ServiceUnavailable, "Unhealthy");
    }    
    
    [HttpGet]
    public async Task<IActionResult> CheckApp()
    {
        return Ok("Healthy");
    }
}