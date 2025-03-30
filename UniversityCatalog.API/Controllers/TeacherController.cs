using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.DTOs.Teachers;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeacherController(ITeacherService teacherService):ControllerBase
{
    private readonly ITeacherService _teacherService=teacherService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAllTeachersAsync()
    {
        var teachers = await _teacherService.GetAllTeachersAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDto>> GetTeacherByIdAsync(int id)
    {
        var teacher = await _teacherService.GetTeachersByIdAsync(id);
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacherByIdAsync([FromBody]TeacherCreateDto teacherDto)
    {
        var newTeacher = await _teacherService.CreateTeacherAsync(teacherDto);
        return Ok(newTeacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacherAsync([FromBody]TeacherUpdateDto teacherDto)
    {
        var updateTeacher = _teacherService.UpdateTeacherAsync(teacherDto);
        return Ok(updateTeacher);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacherAsync(int id)
    {
        await _teacherService.DeleteTeacherAsync(id);
        return NoContent();
    }
}