using System;
using System.Collections.Generic;
using System.Linq;

namespace FApp.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public Dictionary<Food, double> DictionaryOfFood { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }  
        public Eating() { }
        public Eating(User user)
        {
            User = user?? throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            Moment = DateTime.UtcNow;
            DictionaryOfFood = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = DictionaryOfFood.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                DictionaryOfFood.Add(food, weight);
            }
            else
            {
                DictionaryOfFood[product] += weight;
            }
        }
    }
}
