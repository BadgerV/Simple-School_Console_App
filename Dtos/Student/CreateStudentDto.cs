namespace OOPConcept.Dtos.Student;

public class CreateStudentDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; }
    public string Email { get; set; } = default!;
    public Gender Gender { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string AdmissionNumber { get; set; } = default!;
}