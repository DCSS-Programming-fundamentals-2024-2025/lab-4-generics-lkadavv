using generics.Entities;

class Program
{
    static void Main(string[] args)
    {
        Faculty fpm = new Faculty();
        var KP41 = new Group { Id = 41, Name = "КП-41" };
        var KP42 = new Group { Id = 42, Name = "КП-42" };
        var KP43 = new Group { Id = 43, Name = "КП-43" };
        fpm.AddGroup(KP41);
        fpm.AddGroup(KP42);
        fpm.AddGroup(KP43);
        var s1 = new Student { Id = 1, Name = "Кравченко Владислава" };
        var s2 = new Student { Id = 2, Name = "Шозда Катерина" };
        fpm.AddStudentToGroup(41,s1);
        fpm.AddStudentToGroup(41, s2);
        var students = fpm.GetAllStudentsInGroup(41);
        {
            foreach (var VARIABLE in students)
            {
                Console.WriteLine(VARIABLE.Name);
            }
        }
        IReadOnlyRepository<Student, int> studRepo = new InMemoryRepository<Student, int>();
        IReadOnlyRepository<Person, int> persRepo = studRepo;
   
        IWriteRepository<Person, int> persWrite = new InMemoryRepository<Person, int>();
        IWriteRepository<Student, int> studWrite = persWrite;
        studWrite.Add(4, new Student { Id = 4, Name = "Назар Ференцюк" });
        studWrite.Remove(1);
    }
}
//Кравченко Владислава КП-41
