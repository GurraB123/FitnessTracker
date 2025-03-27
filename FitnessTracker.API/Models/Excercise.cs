namespace FitnessTracker.API.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IsCustom { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}