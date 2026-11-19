
namespace DZ_8Latypova
{
    internal class Executor : Emploee
    {
        public Executor(string name) : base(name, Post.Executor) { }

        public void TakeTask(Task task)
        {
            task.Status = TaskStatus.Work;
            Console.WriteLine($"Исполнитель {Name} взял задачу #{task.Id} в работу");
        }

        public void DelegateTask(Task task, Executor newExecutor)
        {
            task.Executor = newExecutor;
            task.Status = TaskStatus.Assigned;
            Console.WriteLine($"{Name} делегировал задачу #{task.Id} сотруднику {newExecutor.Name}");
        }

        public void RejectTask(Task task)
        {
            Console.WriteLine($"{Name} отклонил задачу #{task.Id}");
            task.Executor = null;
        }

        public void CreateReport(Task task, string text)
        {
            task.Report = new Report(text, this);
            task.Status = TaskStatus.Check;
            Console.WriteLine($"{Name} отправил отчет по задаче #{task.Id} на проверку тимлиду");
        }

        public void RewriteReport(Task task, string newText)
        {
            if (task.Report != null)
            {
                task.Report.Description = newText;
                task.Report.CompletionDate = DateTime.Now;
                task.Report.Status = ReportStatus.Checked;
            }
            task.Status = TaskStatus.Check;
            Console.WriteLine($"{Name} доработал и повторно отправил отчет по задаче #{task.Id}");
        }
    }
}
