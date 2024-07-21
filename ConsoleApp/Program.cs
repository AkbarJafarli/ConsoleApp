using ConsoleApp;
using ConsoleApp.Exceptions;

List<Classroom> classrooms = new List<Classroom>();

//while (true)
//{
Console.WriteLine("Menu:");
Console.WriteLine("=============================");
Console.WriteLine("1.Create classroom.");
Console.WriteLine("2.Create student.");
Console.WriteLine("3.Get all students.");
Console.WriteLine("4.Get students for classroom.");
Console.WriteLine("5.Remove student.");
Console.WriteLine("=============================");
restart:
Console.Write("Select:");
if (!int.TryParse(Console.ReadLine(), out int choice))
{
    Console.WriteLine("Invalid input,please enter a number...");
    goto restart;
}
switch (choice)
{
    case 1:
    restart2:
        Console.Write("Enter classroom name:");
        string classname = Console.ReadLine();
        if (!classname.checkClassname())
        {
            Console.WriteLine("Please enter a correct classname...");
            goto restart2;
        }
    restart3:
        Console.Write("Enter classroom type (Frontend,Backend):");
        string typeinput = Console.ReadLine();
        ClassroomType type;
        if (!Enum.TryParse(typeinput, true, out type))
        {
            Console.WriteLine("Invalid classroom type,please enter 'Frontend' or 'Backend'.");
            goto restart3;
        }
        Classroom classroom = new(classname, type);
        classrooms.Add(classroom);
        Console.WriteLine("Clasrooms created succesfully.");
        Console.ReadLine();
        Console.Clear();
        break;

    case 2:
    restart4:
        Console.Write("Enter student name:");
        string studentName = Console.ReadLine();
        Console.WriteLine("Enter student surname:");
        string studentSurname = Console.ReadLine();
        if (!studentName.isValidName() || !studentSurname.isValidSurname())
        {
            Console.WriteLine("Please enter a correct name and surname...");
            goto restart4;
        }
        Student student = new(studentName, studentSurname);
    restart5:
        Console.Write("Enter class id:");
        if (!int.TryParse(Console.ReadLine(), out int classId))
        {
            Console.WriteLine("Invalid input please enter a number...");
            goto restart5;
        }
        try
        {
            var classroomToAddStudent = classrooms.Find(c => c.Id == classId);
            if (classroomToAddStudent == null)
            {
                throw new ClassroomNotFoundException("Classroom not found.");
            }
            classroomToAddStudent.AddStudent(student);
            Console.WriteLine("Student added succesfully.");
            Console.ReadLine();
            Console.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        break;

    case 3:
        Console.WriteLine("All students:");
        foreach (var clasroom in classrooms)
        {
            foreach (var stud in classroom.students)
            {
                Console.WriteLine($"ID: {stud.Id}, Name: {stud.Name}, Surname: {stud.Surname}");
            }
        }
        break;

    case 4:
    restart6:
        Console.Write("Enter class id:");
        if (!int.TryParse(Console.ReadLine(), out int classIdForStudents))
        {
            Console.WriteLine("Invalid input please enter a number...");
            goto restart6;
        }
        try
        {
            var classroomToShowStudents = classrooms.Find(c => c.Id == classIdForStudents);
            if (classroomToShowStudents == null)
            {
                throw new ClassroomNotFoundException("Classroom not found...");
            }
            Console.WriteLine($"Students in classroom {classroomToShowStudents.Name}:");
            foreach (var stud in classroomToShowStudents.students)
            {
                Console.WriteLine($"ID: {stud.Id}, Name: {stud.Name}, Surname: {stud.Surname}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        break;

    case 5:
    restart7:
        Console.Write("Enter student ID for remove:");
        if (!int.TryParse(Console.ReadLine(), out int studentIdToRemove))
        {
            Console.WriteLine("Invalid input please enter a number...");
            goto restart7;

        }
        try
        {
            foreach (var clasroom in classrooms)
            {
                try
                {
                    classroom.Delete(studentIdToRemove);
                    Console.WriteLine("Student removes succesfully");
                    break;
                }
                catch (NotFoundException)
                {

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        break;

    default:
        Console.WriteLine("Invalid input.Please select a valid number...");
        break;


}
//


