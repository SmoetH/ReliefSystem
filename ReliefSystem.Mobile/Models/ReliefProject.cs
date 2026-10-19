namespace ReliefSystem.Mobile.Models
{
    public class ReliefProject // Make sure 'public' is here
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal TargetBudget { get; set; }
        public decimal Raised { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}