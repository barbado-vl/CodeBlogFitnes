﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {

        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivity();
        }

       

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if(act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        
        private List<Activity> GetAllActivity()
        {
            return Load<Activity>() ?? new List<Activity>();
        }
                
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        public void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
 