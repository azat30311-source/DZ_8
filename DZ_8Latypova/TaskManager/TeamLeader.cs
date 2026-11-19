
namespace DZ_8Latypova
{
    internal class TeamLeader : Emploee
    {
        public TeamLeader(string name, Post post) : base(name, post) { }

        public void TakeProject(Project project)
        {
            project.TeamLeader = this;
            Console.WriteLine($"Тимлид {Name} взял в работу проект '{project.Description}'");
        }

        public Task CreateTask(Project project, string description, DateTime deadline)
        {
            if (project.Status != ProjectStatus.Project)
            {
                throw new InvalidOperationException("Задачи можно создавать только в статусе проекта 'Проект'.");
            }

            Task task = new Task(project, description, deadline, this);
            project.Tasks.Add(task);
            Console.WriteLine($"Тимлид {Name} создал задачу #{task.Id}: {description}");
            return task;
        }

        public void GiveTask(Task task, Executor executor)
        {
            task.Executor = executor;
            task.Status = TaskStatus.Assigned;
            Console.WriteLine($"Задача #{task.Id} назначена исполнителю {executor.Name}");
        }

        public void StartProject(Project project)
        {
            project.Status = ProjectStatus.Execution;
            Console.WriteLine($"Проект '{project.Description}' переведен в статус 'Исполнение'");
        }

        public void DeleteTask(Task task)
        {
            task.Project.Tasks.Remove(task);
            Console.WriteLine($"Задача #{task.Id} удалена из проекта");
            task.Project.TryClose();
        }

        public void ApproveReport(Task task)
        {
            if (task.Report != null)
            {
                task.Report.Status = ReportStatus.Approved;
            }
            task.Status = TaskStatus.Completed;
            Console.WriteLine($"Тимлид утвердил отчет по задаче #{task.Id}. Задача выполнена.");
            task.Project.TryClose();
        }

        public void ReturnReport(Task task, string comment)
        {
            if (task.Report != null)
            {
                task.Report.Status = ReportStatus.Refined;
            }
            task.Status = TaskStatus.Work;
            Console.WriteLine($"Отчет по задаче #{task.Id} отправлен на доработку. Причина: {comment}");
        }
    }
}
