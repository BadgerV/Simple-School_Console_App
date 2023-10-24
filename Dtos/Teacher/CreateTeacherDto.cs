namespace OOPConcept.Dtos.Teacher
{
    public class CreateTeacherDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
    }
}