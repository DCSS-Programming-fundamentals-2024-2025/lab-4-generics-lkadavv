using generics.Interfaces;

namespace generics.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();
        public void AddGroup(Group g) => _groups.Add(g.Id, g);
        public void RemoveGroup(int id) => _groups.Remove(id);
        public IEnumerable<Group> GetAllGroups() => _groups.GetAll();
        public Group GetGroup(int id) => _groups.Get(id);

        public void AddStudentToGroup(int groupId, Student s)
        {
            var group = _groups.Get(groupId);
            if (group == default)
            {
                throw new ArgumentException("Parametr doesn`t exist");
            }
            group.AddStudent(s);
        }
        public void RemoveStudentFromGroup(int groupId, int studentId)
        {
            var group = _groups.Get(groupId);
            if (group == default)
            {
                throw new ArgumentException("Parametr doesn`t exist");
            }
            group.RemoveStudent(studentId);
        }
        public IEnumerable<Student> GetAllStudentsInGroup(int groupId)
        {
            var group = _groups.Get(groupId);
            if (group == default)
            {
                throw new ArgumentException("Parametr doesn`t exist");
            }
            return group.GetAllStudents();

        }

        public Student FindStudentInGroup(int groupId, int studentId)
        {
            var group = _groups.Get(groupId);
            if (group == default)
            {
                throw new ArgumentException("Parametr doesn`t exist");
                return default;
            }

            return group.FindStudent(studentId);
        }
    }
}
