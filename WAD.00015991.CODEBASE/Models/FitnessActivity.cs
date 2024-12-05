namespace WAD._00015991.CODEBASE.Models
// 00015991
{
    public class FitnessActivity
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty; // Name of the activity
        public string Type { get; set; } = string.Empty; // Type of activity (e.g., Running, Cycling)
        public int Duration { get; set; } // Duration in minutes
        public DateTime Date { get; set; } // Date of the activity
    }
}
// 00015991