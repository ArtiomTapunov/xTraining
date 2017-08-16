using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Exercises
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Repeat count is required")]
        public int RepeatCount { get; set; }

        [Required(ErrorMessage = "Set count is required")]
        public int SetCount { get; set; }

        [Required(ErrorMessage = "Muscle Group is required")]
        public string MuscleGroup { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Program title is required")]
        public string ProgramTitle { get; set; }

        public static List<Exercises> MaleInitializePragram ()
        {
            var exercises = new List<Exercises>
            {
                new Exercises { Title = "Pull-Ups", RepeatCount = 12, SetCount = 3, MuscleGroup = "Back", ProgramTitle = "Your Program" },
                new Exercises { Title = "Push-Ups", RepeatCount = 20, SetCount = 3, MuscleGroup = "Chest", ProgramTitle = "Your Program" },
                new Exercises { Title = "Parallel bar push-ups", RepeatCount = 10, SetCount = 3, MuscleGroup = "Chest", ProgramTitle = "Your Program" },
                new Exercises { Title = "Squats", RepeatCount = 10, SetCount = 3, MuscleGroup = "Legs", ProgramTitle = "Your Program" },
                new Exercises { Title = "Reverse butterfly", RepeatCount = 15, SetCount = 3, MuscleGroup = "Back", ProgramTitle = "Your Program" },
                new Exercises { Title = "Barbell biceps", RepeatCount = 10, SetCount = 3, MuscleGroup = "Arms", ProgramTitle = "Your Program" },
                new Exercises { Title = "dumbbell triceps", RepeatCount = 10, SetCount = 3, MuscleGroup = "Arms", ProgramTitle = "Your Program" },
                new Exercises { Title = "dumbbell shoulders", RepeatCount = 10, SetCount = 3, MuscleGroup = "Shoulders", ProgramTitle = "Your Program" },
            };

            return exercises;
        }

        public static List<Exercises> FemaleInitializePragram()
        {
            var exercises = new List<Exercises>
            {
                new Exercises { Title = "Pull-Ups", RepeatCount = 20, SetCount = 3, MuscleGroup = "Back", ProgramTitle = "Your Program" },
                new Exercises { Title = "Push-Ups", RepeatCount = 25, SetCount = 3, MuscleGroup = "Chest", ProgramTitle = "Your Program" },
                new Exercises { Title = "Parallel bar push-ups", RepeatCount = 10, SetCount = 3, MuscleGroup = "Chest", ProgramTitle = "Your Program" },
                new Exercises { Title = "Squats", RepeatCount = 15, SetCount = 3, MuscleGroup = "Legs", ProgramTitle = "Your Program" },
                new Exercises { Title = "Reverse butterfly", RepeatCount = 20, SetCount = 3, MuscleGroup = "Back", ProgramTitle = "Your Program" },
                new Exercises { Title = "Barbell biceps", RepeatCount = 15, SetCount = 3, MuscleGroup = "Arms", ProgramTitle = "Your Program" },
                new Exercises { Title = "dumbbell triceps", RepeatCount = 15, SetCount = 3, MuscleGroup = "Arms", ProgramTitle = "Your Program" },
                new Exercises { Title = "dumbbell shoulders", RepeatCount = 15, SetCount = 3, MuscleGroup = "Shoulders", ProgramTitle = "Your Program" },
            };

            return exercises;
        }

    }
}