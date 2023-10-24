using System.ComponentModel.DataAnnotations;
using OOPConcept.Menu;
using OOPConcept.Repositories;
using OOPConcept.Service;
using OOPConcept.Service.Contracts;

// StudentRepository studentRepository = new StudentRepository();
// IStudentService studentService = new StudentService(studentRepository);
// TeacherRepository teacherRepository = new TeacherRepository();
// ITeacherService teacherService  = new TeacherService(teacherRepository);

// Menu.MainMenu(studentService, teacherService);

int max;
int min;



void FindMinmax(int[] numbers, out int min, out int max)
{
    min = numbers[0];
    max = numbers[0];
    foreach (int num in numbers)
    {
        if (num < min) min = num;

        if (num > max) max = num;
    }

}


int[] numbers = { 5, 3, 9, 2, 7 };

FindMinmax(numbers, out min, out max);

Console.WriteLine($"{min} {max}");
