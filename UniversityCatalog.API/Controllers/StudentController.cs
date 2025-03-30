using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.DTOs.Students;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService=studentService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudentsByIdAsync(int id)
    {
        var student = await _studentService.GetStudentsByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudentAsync([FromBody]StudentCreateDto studentDto)
    {
        var newStudent = await _studentService.CreateStudentAsync(studentDto);
        return Ok(newStudent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudentAsync([FromBody]StudentUpdateDto studentDto)
    {
        var updateStudent = await _studentService.UpdateStudentAsync(studentDto);
        return Ok(updateStudent);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentAsync(int id)
    {
        await _studentService.DeleteStudentsAsync(id);
        return NoContent();
    }
}