
namespace DZ_8Latypova
{
    internal class Task
    {
        private static int _counter = 0;

        public int Id { get; }
        public Project Project { get; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TeamLeader TeamLeader { get; }
        public Executor Executor { get; set; }
        public TaskStatus Status { get; set; }
        public Report Report { get; set; }

        public Task(Project project, string description, DateTime deadline, TeamLeader teamLeader)
        {
            Id = ++_counter;
            Project = project;
            Description = description;
            Deadline = deadline;
            TeamLeader = teamLeader;
            Status = TaskStatus.Assigned;
        }
    }
}