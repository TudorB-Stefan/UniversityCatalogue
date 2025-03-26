namespace UniversityCatalog.API.DTOs.Students;

public class StudentCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int CurrentYear { get; set; }
    public DateTime LastYear { get; set; }
}