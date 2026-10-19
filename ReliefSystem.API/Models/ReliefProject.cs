namespace ReliefSystem.API.Models
{
    public class ReliefProject
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal TargetBudget { get; set; }
        public decimal CurrentRaised { get; set; }
        public string Status { get; set; } = "Active";
    }
}