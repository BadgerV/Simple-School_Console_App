using OOPConcept.Menu;
using OOPConcept.Repositories;
using OOPConcept.Service;
using OOPConcept.Service.Contracts;

StudentRepository studentRepository = new StudentRepository();
IStudentService studentService = new StudentService(studentRepository);
TeacherRepository teacherRepository = new TeacherRepository();
ITeacherService teacherService  = new TeacherService(teacherRepository);

Menu.MainMenu(studentService, teacherService);