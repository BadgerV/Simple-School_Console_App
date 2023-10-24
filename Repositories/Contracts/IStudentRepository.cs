using OOPConcept.Dtos.Student;

namespace OOPConcept.Repositories;

public interface IStudentRepository
{
    StudentDetailDto CreateStudent(CreateStudentDto request);
    List<StudentDetailDto> ViewAllStudent();
    StudentDetailDto FindStudent(int id);
    StudentDetailDto UpdateStudent(UpdateStudentDto request, Student studentCard);

    Student FindStudentForUpdate(string admissionNumber);
    void DeleteStudent(int id);
}
