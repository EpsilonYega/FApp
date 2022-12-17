﻿using FApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Имя пользователя не может быть пустым!",nameof(user));
            Exercises = GetAllExersizes();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Exercise> GetAllExersizes()
        {
            return Load<Exercise>() ?? new List<Exercise>();   
        }
        private void Save()
        {
            Save();
        }
    }
}
