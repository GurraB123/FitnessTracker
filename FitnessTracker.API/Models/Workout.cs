using System;
using System.Collections.Generic;

namespace FitnessTracker.API.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<WorkoutEntry> Entries { get; set; }
    }

    public class WorkoutEntry
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}