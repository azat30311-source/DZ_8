
namespace DZ_8Latypova
{
    internal class Report
    {
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public Emploee Executor { get; }
        public ReportStatus Status { get; set; }

        public Report(string description, Emploee executor)
        {
            Description = description;
            CompletionDate = DateTime.Now;
            Executor = executor;
            Status = ReportStatus.Checked;
        }
    }
}
