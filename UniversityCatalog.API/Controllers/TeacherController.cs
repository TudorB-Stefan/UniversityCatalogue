using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeacherController(ITeacherService teacherService):ControllerBase
{
    private readonly ITeacherService _teacherService=teacherService;
    [HttpGet]
    [HttpGet("{id}")]
    [HttpPost]
    [HttpPut("{id}")]
    [HttpDelete]
}