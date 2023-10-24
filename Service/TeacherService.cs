using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using OOPConcept.Dtos.Teacher;
using OOPConcept.Helper;
using OOPConcept.Repositories;
using OOPConcept.Service.Contracts;

namespace OOPConcept.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void CreateTeacher()
        {
            try
            {
                Console.Write("Enter Firstname: ");
                string firstName = Console.ReadLine()!;

                Console.Write("Enter Lastname: ");
                string lastName = Console.ReadLine()!;

                Console.Write("Enter Middlename: ");
                string? middlename = Console.ReadLine();

                Console.Write("Enter Teacher Email: ");
                string email = Console.ReadLine()!;

                Console.Write("Provide Teacher Gender: ");
                int genderValue = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Date of birth (2000-10-10): ");
                DateOnly dob = DateOnly.Parse(Console.ReadLine()!);

                Console.Write("Enter phone number: ");
                string PhoneNumber = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
                {
                    Utility.PrintErrorMessage("Provide values for required fields (e.g: firstname, lastname or email field cannot be null or empty!)");
                    return;
                }


                var newTeacher = new CreateTeacherDto
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middlename,
                    Email = email,
                    Gender = (Gender)genderValue,
                    DateOfBirth = dob,
                    PhoneNumber = PhoneNumber
                };

                var teacher = _teacherRepository.CreateTeacher(newTeacher);
                Utility.PrintSuccessMessage($"Record for {teacher.FirstName} {teacher.LastName} with {teacher.StaffNumber} is successfully created!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void DeleteTeacher()
        {
            try {
                Console.WriteLine("Enter the teahcer's Staff Number you want to delete: ");

                string staffNumber = Console.ReadLine()!;
                var findTeacher = _teacherRepository.FindTeacher(staffNumber);

                if(findTeacher == null) {
                    Utility.PrintErrorMessage("Teacher not found");
                    return;
                }

                _teacherRepository.DeleteTeacher(staffNumber);
                Utility.PrintSuccessMessage("Teacher record deleted successfully!");
            } catch(Exception ex) {
                Utility.PrintErrorMessage(ex.Message);
            }
        }

        public void UpdateTeacher()
        {
            Console.WriteLine($"Enter Staff Number");
            string staffNumber = Console.ReadLine()!;

            var teacher = _teacherRepository.FindTeacherForUpdate(staffNumber);


            while (teacher == null)
            {
                Utility.PrintErrorMessage("Invalid Admission Number. Please try again\n");

                UpdateTeacher();
            }

            try
            {
                Console.WriteLine($"Enter Firstname, leave blank if don't want this property changed!");
                string firstname = Console.ReadLine()!;

                Console.WriteLine($"Enter Lastname, leave blank if don't want this property changed!");
                string lastname = Console.ReadLine()!;

                Console.WriteLine($"Enter Middlename, leave blank if don't want this property changed!");
                string middlename = Console.ReadLine()!;

                Console.WriteLine($"Enter Emai, leave blank if don't want this property changed!l");
                string email = Console.ReadLine()!;

                Console.WriteLine($"Enter Phonenumber, leave blank if don't want this property changed!");
                string PhoneNumber = Console.ReadLine()!;

                UpdateTeacherDto newTeacherDto = new UpdateTeacherDto
                {
                    FirstName = firstname == "" ? teacher.FirstName : firstname,
                    LastName = lastname == "" ? teacher.LastName : lastname,
                    Email = email == "" ? teacher.Email : email,
                    MiddleName = middlename == "" ? teacher.MiddleName : middlename,
                    PhoneNumber = PhoneNumber == "" ? teacher.PhoneNumber : PhoneNumber
                };

                var updatedTeacher = _teacherRepository.UpdateTeacher(newTeacherDto, teacher);

                Utility.PrintSuccessMessage("Teacher Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
        }

        public void ViewAllTeacher()
        {
            var teachers = _teacherRepository.ViewAllTeachers();

            if (teachers.Count == 0)
            {
                Utility.PrintInfoMessage("No Records found");
            }
            else
            {
                var table = new ConsoleTable("Firstname", "Lastname", "Staff Number", "Age");

                foreach (var teacher in teachers)
                {
                    table.AddRow(teacher.FirstName, teacher.LastName, teacher.StaffNumber, teacher.Age);
                }

                table.Write(Format.Alternative);
            }
        }

        public void ViewTeacher()
        {
            try
            {
                Console.WriteLine("Enter the staff number you want to view: ");
                string teacherStaffNumber = Console.ReadLine()!;

                var findTeacher = _teacherRepository.FindTeacher(teacherStaffNumber);

                while (findTeacher == null)
                {
                    Utility.PrintErrorMessage("Staff not found, please try again");
                    ViewTeacher();
                }

                Utility.PrintSuccessMessage($"========Staff Record=======\nFirstname: {findTeacher.FirstName}\nLastname: {findTeacher.LastName}\nMiddleName: {findTeacher.MiddleName}\nGender: {findTeacher.Gender}\nAdmission Number: {findTeacher.StaffNumber}\nAge: {findTeacher.Age}\n========Staff Record========");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}