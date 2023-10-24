using OOPConcept.Helper;
using OOPConcept.Service;
using OOPConcept.Service.Contracts;

namespace OOPConcept.Menu;

public class Menu
{
    public static void MainMenu(IStudentService studentService, ITeacherService teacherService)
    {
        bool flag = true;

        try
        {
            while (flag)
            {
                PrintMainMenu();
                Console.Write("\nPlease enter your preferred option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        StudentMenu(studentService);
                        break;
                    case "2":
                        Console.Clear();
                        TeacherMenu(teacherService);
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        throw new InvalidOperationException("Unknown menu option!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.PrintErrorMessage(ex.Message);
        }
    }

    public static void StudentMenu(IStudentService studentService)
    {
        bool flag = true;
        try
        {
            while (flag)
            {
                PrintStudentMenu();
                Console.Write("\nPlease enter your preferred option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        studentService.CreateStudent();
                        break;
                    case "2":
                        Console.Clear();

                        studentService.ViewAllStudent();
                        break;
                    case "3":
                        Console.Clear();
                        studentService.FindStudent();
                        break;
                    case "4":
                        Console.Clear();

                        studentService.UpdateStudent();
                        break;
                    case "5":
                        Console.Clear();

                        studentService.DeleteStudent();
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        throw new InvalidOperationException("Unknown student menu option!");
                }
            }
        }
        catch (Exception ex)
        {
            Utility.PrintErrorMessage(ex.Message);
        }
    }


    public static void TeacherMenu(ITeacherService teacherService)
    {
        bool flag = true;
        try
        {
            while (flag)
            {
                PrintTeacherMenu();
                Console.WriteLine($"\n\nSelect your preffered option");

                string result = Console.ReadLine()!;

                switch (result)
                {
                    case "1":
                        Console.Clear();
                        teacherService.CreateTeacher();
                        break;
                    case "2":
                        Console.Clear();
                        teacherService.ViewAllTeacher();
                        break;
                    case "3":
                        Console.Clear();
                        teacherService.ViewTeacher();
                        break;
                    case "4":
                        Console.Clear();
                        teacherService.UpdateTeacher();
                        break;
                    case "5":
                        Console.Clear();
                        teacherService.DeleteTeacher();
                        break;
                    case "0":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine($"The other options have not been implemented yet. Please be patient");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Utility.PrintErrorMessage(ex.Message);
        }
    }

    private static void PrintMainMenu()
    {
        Console.WriteLine("1. Student's Menu");
        Console.WriteLine("2. Teacher's Menu");
        Console.WriteLine("0. Exit application");
    }

    private static void PrintStudentMenu()
    {
        Console.WriteLine("1. Register new student");
        Console.WriteLine("2. View all student");
        Console.WriteLine("3. Search student");
        Console.WriteLine("4. Update student");
        Console.WriteLine("5. Delete student");
        Console.WriteLine("0. Go back to main menu");
    }

    private static void PrintTeacherMenu()
    {
        Console.WriteLine("1. Register new teacher");
        Console.WriteLine("2. View all teacher");
        Console.WriteLine("3. Search teacher");
        Console.WriteLine("4. Update teacher");
        Console.WriteLine("5. Delete teacher");
        Console.WriteLine("0. Go back to main menu");
    }
}
