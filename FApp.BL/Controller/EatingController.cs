using FApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User user;
        public List<Food> ListOfFood { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Поле пользователя не может быть пустым!",nameof(user));
            ListOfFood = GetAllFood();  
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = ListOfFood.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                ListOfFood.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Eating;
            //return Load<Eating>() ?? new List<Eating>();
        }
        private List<Food> GetAllFood()
        {
            return Load<Food>();
        } 
        private void Save()
        {
            Save();
        }
    }
}
