
namespace DZ_8Latypova
{
    internal class Customer : Emploee
    {
        public Customer(string name, Post post) : base(name, post) { }

        public Project CreateProject(string description, DateTime deadline)
        {
            Project project = new Project(description, deadline, this);
            Console.WriteLine($"Заказчик {Name} создал проект: '{description}'");
            return project;
        }
    }
}
