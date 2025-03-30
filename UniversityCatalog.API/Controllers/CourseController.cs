using Microsoft.AspNetCore.Mvc;
using UniversityCatalog.Core.DTOs.Courses;
using UniversityCatalog.Core.Interfaces.Services;

namespace UniversityCatalog.API.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController(ICourseService courseService ) : ControllerBase
{
    private readonly ICourseService _courseService=courseService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesAsync()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetCourseByIdAsync(int id)
    {
        var course = await _courseService.GetCoursesByIdAsync(id);
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourseAsync([FromBody] CourseCreateDto courseDto)
    {
        var newCourse = await _courseService.CreateCourseAsync(courseDto);
        return Ok(newCourse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseAsync([FromBody]CourseUpdateDto courseDto)
    {
        var updatedCourse = await _courseService.UpdateCourseAsync(courseDto);
        return Ok(updatedCourse);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseAsync(int id)
    {
        await _courseService.DeleteCoursesAsync(id);
        return NoContent();
    }
}