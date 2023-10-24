using ConsoleTables;
using OOPConcept.Dtos.Student;
using OOPConcept.Helper;
using OOPConcept.Repositories;
using OOPConcept.Service.Contracts;

namespace OOPConcept.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent()
        {
            try
            {
                Console.Write("enter firstname: ");
                string firstName = Console.ReadLine()!;

                Console.Write("enter lastname: ");
                string lastName = Console.ReadLine()!;

                Console.Write("enter middlename: ");
                string? middlename = Console.ReadLine();

                Console.Write("enter student email: ");
                string email = Console.ReadLine()!;

                Console.Write("Provide student gender: ");
                int genderValue = int.Parse(Console.ReadLine()!);

                Console.Write("enter date of birth (2000-10-10): ");
                DateOnly dob = DateOnly.Parse(Console.ReadLine()!);

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
                {
                    Utility.PrintErrorMessage("Provide values for required fields (e.g: firstname, lastname or email field cannot be null or empty!)");
                    return;
                }

                var newStudent = new CreateStudentDto
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middlename,
                    Email = email,
                    Gender = (Gender)genderValue,
                    DateOfBirth = dob
                };

                var student = _studentRepository.CreateStudent(newStudent);
                Utility.PrintSuccessMessage($"Record for {student.FirstName} {student.LastName} with {student.AdmissionNumber} is successfully created!");
            }
            catch (Exception ex)
            {
                Utility.PrintErrorMessage(ex.Message);
            }
        }

        public void DeleteStudent()
        {
            try
            {
                Console.WriteLine("Enter the student ID you want to delete: ");
                int studentId = int.Parse(Console.ReadLine()!);
                var findStudent = _studentRepository.FindStudent(studentId);

                if (findStudent == null)
                {
                    Utility.PrintErrorMessage("Student not found!");
                    return;
                }

                _studentRepository.DeleteStudent(studentId);
                Utility.PrintSuccessMessage("Student record deleted successfully!");
            }
            catch (Exception ex)
            {
                Utility.PrintErrorMessage(ex.Message);
            }
        }

        public void FindStudent()
        {
            try
            {
                Console.WriteLine("Enter the student ID you want to view: ");
                int studentId = int.Parse(Console.ReadLine()!);

                var findStudent = _studentRepository.FindStudent(studentId);

                if (findStudent == null)
                {
                    Utility.PrintErrorMessage("Student not found!");
                    return;
                }

                Utility.PrintSuccessMessage($"========Student record=======\nFirstname: {findStudent.FirstName}\nLastname: {findStudent.LastName}\nMiddleName: {findStudent.MiddleName}\nGender: {findStudent.Gender}\nAdmission Number: {findStudent.AdmissionNumber}\nAge: {findStudent.Age}\n========Student Record========");
            }
            catch (Exception ex)
            {
                Utility.PrintErrorMessage(ex.Message);
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine($"Enter Admission number");
            string admissionNumber = Console.ReadLine()!;
            var student = _studentRepository.FindStudentForUpdate(admissionNumber);

            while (student == null)
            {
                Utility.PrintErrorMessage("Invalid Admission Number. Please try again\n");

                UpdateStudent();
            }

            try
            {
                Console.WriteLine($"Enter Firstname");
                string firstname = Console.ReadLine()!;

                Console.WriteLine($"Enter Lastname");
                string lastname = Console.ReadLine()!;

                Console.WriteLine($"Enter Middlename");
                string middlename = Console.ReadLine()!;

                Console.WriteLine($"Enter Email");
                string email = Console.ReadLine()!;

                UpdateStudentDto newStudentDto = new UpdateStudentDto
                {
                    FirstName = firstname == "" ? student.FirstName : firstname,
                    LastName = lastname == "" ? student.LastName : lastname,
                    Email = email == "" ? student.Email : email,
                    MiddleName = middlename == "" ? student.MiddleName : middlename
                };

                var uodateTeacher = _studentRepository.UpdateStudent(newStudentDto, student);

                Utility.PrintInfoMessage("Student updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
        }

        public void ViewAllStudent()
        {
            try
            {
                var students = _studentRepository.ViewAllStudent();

                if (students.Count == 0)
                {
                    Utility.PrintInfoMessage("No records found");
                }

                var table = new ConsoleTable("Firstname", "Lastname", "Admission No", "Age");

                foreach (var student in students)
                {
                    table.AddRow(student.FirstName, student.LastName, student.AdmissionNumber, student.Age);
                }

                table.Write(Format.Alternative);
            }
            catch (Exception ex)
            {
                Utility.PrintErrorMessage(ex.Message);
            }
        }
    }
}