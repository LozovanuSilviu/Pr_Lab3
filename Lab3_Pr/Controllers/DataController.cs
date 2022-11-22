using Lab3_Pr.Models;
using Lab3_Pr.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_Pr.Controllers;

[ApiController]
[Route("api")]
public class DataController : ControllerBase
{
    private readonly DataService _service;

    public DataController(DataService service)
    {
        _service = service;
    }
    
    [HttpGet("get-by-id/{id}") ]
    
    public IActionResult GetById(Guid id)
    {
        var element = _service.GetById(id);
        return Ok(element);
    }
    
    [HttpGet("get-all-elements")]
    public IActionResult GetAllElements()
    {
        var elements = _service.GetAll();
        return Ok(elements);
    }
    
    [HttpPost("add-new-data")]
    public IActionResult AddData(CountryCapitalModel model)
    {
       var element= _service.Add(model);
        return Ok(element);
    }
    
    [HttpPut("update-element-by-id/{id}")]
    public IActionResult UpdateById(Guid id,CountryCapitalModel updated)
    {
        _service.Update(id, updated);
        return Ok();
    }
    
    [HttpDelete("delete-by-id/{id}")]
    public IActionResult DeleteById(Guid id)
    {
        _service.DeleteById(id);
        return Ok();
    }
    
    [HttpDelete("delete-all-elements")]
    public IActionResult DeleteAllElements()
    {
        _service.DeleteAll();
        return Ok();
    }
}