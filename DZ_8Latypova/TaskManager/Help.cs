namespace DZ_8Latypova
{
    internal static class Help
    {
        internal static string GetStatusName(TaskStatus status)
        {
            return status switch
            {
                TaskStatus.Assigned => "Назначена",
                TaskStatus.Work => "В работе",
                TaskStatus.Check => "На проверке",
                TaskStatus.Completed => "Выполнена",
                _ => "Неизвестно"
            };
        }
    }
}
