namespace generics.Entities
{
    public class Student : Person
    {
        public void SubmitWork()
        {
            Console.WriteLine($"{Name} submitted work");
        }

        public void SayName()
        {
            Console.WriteLine(Name);
        }
    }
}
