using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPConcept.Dtos.Teacher
{
    public class UpdateTeacherDto : BaseDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? MiddleName { get; set; }

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
    }
}