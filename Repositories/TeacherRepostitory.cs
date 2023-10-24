using OOPConcept.Dtos.Teacher;
using OOPConcept.Helper;

namespace OOPConcept.Repositories;

public class TeacherRepository : ITeacherRepository
{
    readonly List<Teacher> teachers;

    public TeacherRepository()
    {
        teachers = new List<Teacher>();
    }
    public TeacherDetailDto CreateTeacher(CreateTeacherDto request)
    {
        int id = teachers.Count != 0 ? teachers[teachers.Count - 1].Id + 1 : 1;
        string staffNumber = Utility.GenerateId("STF", id, request.LastName);

        var teacher = new Teacher
        {
            Id = id,
            StaffNumber = staffNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = DateTime.Now,
        };


        teachers.Add(teacher);

        var TeacherDetailDto = new TeacherDetailDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            StaffNumber = staffNumber,
            MiddleName = request.MiddleName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,

        };

        return TeacherDetailDto;
    }

    public void DeleteTeacher(string staffNumber)
    {
        var teacher = teachers.Find(t => t.StaffNumber == staffNumber)!;

        teachers.Remove(teacher);
    }

    public TeacherDetailDto FindTeacher(string staffNumber)
    {
        Teacher teacher = teachers.Find(s => s.StaffNumber == staffNumber)!;

        TeacherDetailDto teacherDetailDto = new TeacherDetailDto {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            MiddleName = teacher.MiddleName,
            Email = teacher.Email,
            Gender = teacher.Gender,
            StaffNumber = teacher.StaffNumber,
            Age = Utility.AgeCalculator(teacher.DateOfBirth)
        };

        return teacherDetailDto;
    }

    public Teacher FindTeacherForUpdate(string staffNumber)
    {
        Teacher teacher = teachers.Find(s => s.StaffNumber == staffNumber)!;

        return teacher;
    }

    


    public TeacherDetailDto UpdateTeacher(UpdateTeacherDto request, Teacher teacherCard)
    {
        teachers.Remove(teacherCard);

        teacherCard.FirstName = request.FirstName;
        teacherCard.LastName = request.LastName;
        teacherCard.PhoneNumber = request.PhoneNumber;
        teacherCard.MiddleName = request.MiddleName;
        teacherCard.Email = request.Email;

        teachers.Add(teacherCard);

        return new TeacherDetailDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            Email = request.Email,
            Gender = teacherCard.Gender,
            StaffNumber = teacherCard.StaffNumber
        };
    }

    public List<TeacherDetailDto> ViewAllTeachers()
    {
        var studentList = teachers.Select(teacher => new TeacherDetailDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            Gender = teacher.Gender,
            StaffNumber = teacher.StaffNumber,
            Age = Utility.AgeCalculator(teacher.DateOfBirth)

        }).ToList();

        return studentList;
    }
}