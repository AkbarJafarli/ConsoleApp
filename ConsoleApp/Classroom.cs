using ConsoleApp.Exceptions;

namespace ConsoleApp
{
    public partial class Classroom
    {
        private int _id;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public ClassroomType Type { get; set; }
        public List<Student> students = new List<Student>();
        public Classroom(string name, ClassroomType type)
        {
            _id++;
            Id = _id;
            Name = name;
            Type = type;
            if (type == ClassroomType.Frontend)
            {
                Limit = 15;
            }
            if (type == ClassroomType.Backend)
            {
                Limit = 15;
            }
        }
        public void AddStudent(Student student)
        {
            if (students.Count >= Limit)
            {
                throw new InvalidOperationException("Classroom is full...");
            }
            students.Add(student);
        }
        public Student FindId(int id)
        {
            foreach (var item in students)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new NotFoundException("Id not found...");
        }
        public void Delete(int id)
        {
            Student student = FindId(id);
            students.Remove(student);
        }


    }
}
