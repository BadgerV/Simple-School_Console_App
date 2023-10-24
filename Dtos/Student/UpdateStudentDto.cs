namespace OOPConcept.Dtos.Student
{
    public class UpdateStudentDto : BaseDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = default!;
    }
}