using Microsoft.AspNetCore.Mvc;
using OMyBlog.Domain.Contracts.Services;
using OMyBlog.Domain.Dtos.Person;
using OMyBlog.Domain.Filters.Search;

namespace OMyBlog.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PersonsController : Controller
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPatch("{id:guid}/interests")]
    public async Task<IActionResult> UpdateOne(Guid id, [FromBody] PersonInterestsUpdateRequest request)
    {
        var result = await _personService.UpdateOne(id, request);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _personService.GetById(id);
        return Ok(result);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search(PersonSearchFilter filter)
    {
        //var result = await _personService.Search(filter);
        return Ok();
    }
// TODO SearchController ?
}