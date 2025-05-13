namespace generics.Entities
{
    public class Teacher : Person
    {
        public void GradeStudent(Student student)
        {
            Console.WriteLine($"Student {student.Name} is graded");
        }

        public void ExpelStudent(Student student)
        {
            Console.WriteLine($"Student {student.Name} is expelled");

        }
        public void ShowPresentStudents(List<Student> students)
        {
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }
}
