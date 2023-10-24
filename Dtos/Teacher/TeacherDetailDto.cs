namespace OOPConcept.Dtos.Teacher
{
    public class TeacherDetailDto : BaseDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string StaffNumber { get; set; } = default!;
        public int Age { get; set; } = default!;

    }
}
