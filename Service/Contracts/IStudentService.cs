using OOPConcept.Dtos.Student;

namespace OOPConcept.Service.Contracts
{
    public interface IStudentService
    {
        void CreateStudent();
        void ViewAllStudent();
        void FindStudent();
        void UpdateStudent();
        void DeleteStudent();
    }
}