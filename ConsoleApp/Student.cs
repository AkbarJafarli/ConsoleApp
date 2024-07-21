namespace ConsoleApp
{
    public class Student
    {
        private int _id;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Student(string name, string surname)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
        }
    }
}
