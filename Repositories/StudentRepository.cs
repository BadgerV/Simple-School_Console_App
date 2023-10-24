using OOPConcept.Dtos.Student;
using OOPConcept.Helper;

namespace OOPConcept.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>();
        }

        public StudentDetailDto CreateStudent(CreateStudentDto request)
        {
            int id = students.Count != 0 ? students[students.Count - 1].Id + 1 : 1;
            string admissionNumber = Utility.GenerateId("STD", id, request.LastName);

            var student = new Student
            {
                Id = id,
                AdmissionNumber = admissionNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                CreatedAt = DateTime.Now
            };

            students.Add(student);

            var studentDetail = new StudentDetailDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Email = student.Email,
                Gender = student.Gender,
                AdmissionNumber = student.AdmissionNumber,
                Age = Utility.AgeCalculator(student.DateOfBirth)
            };

            return studentDetail;
        }


        public void DeleteStudent(int id)
        {
            var student = students.Find(s => s.Id == id)!;
            students.Remove(student);
        }


        public Student FindStudentForUpdate(string admissionNumber)
        {
            Student student = students.Find(s => s.AdmissionNumber == admissionNumber)!;

            return student;
        }
        public StudentDetailDto UpdateStudent(UpdateStudentDto request, Student studentCard)
        {

            students.Remove(studentCard);

            studentCard.FirstName = request.FirstName;
            studentCard.LastName = request.LastName;
            studentCard.MiddleName = request.MiddleName;
            studentCard.Email = request.Email;

            students.Add(studentCard);

            return new StudentDetailDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Gender = studentCard.Gender,
                AdmissionNumber = studentCard.AdmissionNumber,
                Age = Utility.AgeCalculator(studentCard.DateOfBirth)
            };
        }

        public List<StudentDetailDto> ViewAllStudent()
        {
            var studentList = students.Select(student => new StudentDetailDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Email = student.Email,
                Gender = student.Gender,
                AdmissionNumber = student.AdmissionNumber,
                Age = Utility.AgeCalculator(student.DateOfBirth)
            }).ToList();

            return studentList;
        }

        public StudentDetailDto FindStudent(int id)
        {
            var student = students.Find(s => s.Id == id)!;

            var studentDetail = new StudentDetailDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Email = student.Email,
                Gender = student.Gender,
                AdmissionNumber = student.AdmissionNumber,
                Age = Utility.AgeCalculator(student.DateOfBirth)
            };

            return studentDetail;
        }
    }
}