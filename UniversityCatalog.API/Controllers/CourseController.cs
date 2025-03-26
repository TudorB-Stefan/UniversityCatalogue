using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController(ICourseService courseService ) : ControllerBase
{
    private readonly ICourseService _courseService=courseService;
    [HttpGet]
    [HttpGet("{id}")]
    [HttpPost]
    [HttpPut("{id}")]
    [HttpDelete]
}