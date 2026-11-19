
namespace DZ_8Latypova
{
    internal class Project
    {
        private static int _counter = 0;

        public int Id { get; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Customer Customer { get; }
        public TeamLeader TeamLeader { get; set; }
        public List<Task> Tasks { get; }
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, Customer customer)
        {
            Id = ++_counter;
            Description = description;
            Deadline = deadline;
            Customer = customer;
            Tasks = new List<Task>();
            Status = ProjectStatus.Project;
        }

        public void TryClose()
        {
            if (Status != ProjectStatus.Execution || Tasks.Count == 0)
                return;

            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Completed)
                    return;
            }

            Status = ProjectStatus.Closed;
            Console.WriteLine($"Все задачи выполнены. Проект '{Description}' успешно закрыт!");
        }
    }
}
