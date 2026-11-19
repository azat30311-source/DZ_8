
namespace DZ_8Latypova
{
    internal class Program
    {
        private static void Main()
        {
            Customer customer = new Customer("Иван Иванов", Post.Customer);
            TeamLeader leader = new TeamLeader("Анна Смирнова", Post.TeamLeader);

            List<Executor> team = new List<Executor>
            {
                new Executor("Алексей"),
                new Executor("Мария"),
                new Executor("Дмитрий"),
                new Executor("Ольга"),
                new Executor("Сергей"),
                new Executor("Елена"),
                new Executor("Никита"),
                new Executor("Татьяна"),
                new Executor("Павел"),
                new Executor("Юлия")
            };

            Project project = customer.CreateProject("Автоматизация складов", DateTime.Now.AddMonths(4));
            leader.TakeProject(project);

            List<Task> tasks = new List<Task>
            {
                leader.CreateTask(project, "Анализ требований", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Проектирование архитектуры", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Разработка базы данных", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Создание API", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Интерфейс пользователя", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Настройка авторизации", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Интеграция сканеров", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Модульное тестирование", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Подготовка документации", DateTime.Now.AddMonths(1)),
                leader.CreateTask(project, "Развертывание системы", DateTime.Now.AddMonths(1))
            };

            leader.StartProject(project);

            // Назначаем задачи 10 разработчикам
            for (int i = 0; i < team.Count; i++)
            {
                leader.GiveTask(tasks[i], team[i]);
            }

            // Симуляция работы команды
            team[0].DelegateTask(tasks[0], team[1]); // Алексей делегирует Марии
            team[2].RejectTask(tasks[2]);           // Сергей отклоняет задачу
            leader.GiveTask(tasks[2], team[2]);      // Тимлид переназначает её обратно

            foreach (var task in project.Tasks)
            {
                if (task.Executor != null)
                {
                    task.Executor.TakeTask(task);
                    task.Executor.CreateReport(task, $"Отчет по задаче: {task.Description}");
                    leader.ApproveReport(task);
                }
            }
        }
    }
}
