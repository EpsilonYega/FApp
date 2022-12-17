using FApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FApp.BL.Controller
{
    public class DadabaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using(var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
                
                //Type type = item.GetType();

                //if (type == typeof(User))
                //{
                //    db.Users.Add(item as User);
                //}
                //else if(type == typeof(Gender))
                //{
                //    db.Genders.Add(item as Gender);
                //}
                
                //switch (type.ToString())
                //{
                //    case "User":
                //        db.Users.Add(item as User);
                //        break;
                //    case "Gender":
                //        db.Genders.Add(item as Gender);
                //        break;
                //    case "Food":
                //        db.ListOfFood.Add(item as Food);
                //        break;
                //    case "Exercise":
                //        db.Exercises.Add(item as Exercise);
                //        break;
                //    case "Eating":
                //        db.Eatings.Add(item as Eating);
                //        break;
                //    case "Activity":
                //        db.Activities.Add(item as Activity);
                //        break;
                //    default:
                //        throw new NotImplementedException("Wrong data format!");
                //        break;
                //}
            }
        }
    }
}
