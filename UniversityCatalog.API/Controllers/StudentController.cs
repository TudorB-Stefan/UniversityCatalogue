using API.Models;
using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.API.DTOs.Students;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService=studentService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudentsById(int id)
    {
        var students = await _studentService.GetStudentsByIdAsync(id);
        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody]StudentCreateDto studentDto)
    {
        var newStudent = await _studentService.CreateStudentAsync(studentDto);
        return CreatedAtAction(nameof(GetStudentsById),new {id = newStudent.Id},newStudent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudentAsync([FromBody]StudentUpdateDto student)
    {
        var updateStudent = _studentService.GetStudentsByIdAsync(student.Id);
        return Ok(updateStudent);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentAsync(int id)
    {
        await _studentService.DeleteStudentsAsync(id);
        return NoContent();
    }
}