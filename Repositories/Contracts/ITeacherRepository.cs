using OOPConcept.Dtos.Teacher;

namespace OOPConcept.Repositories;

public interface ITeacherRepository
{
     TeacherDetailDto CreateTeacher(CreateTeacherDto request);

     List<TeacherDetailDto> ViewAllTeachers();

     TeacherDetailDto UpdateTeacher(UpdateTeacherDto request, Teacher teacher);

     Teacher FindTeacherForUpdate(string staffNumber);

     TeacherDetailDto FindTeacher(string staffNumber);

     void DeleteTeacher(string staffNumber);
}