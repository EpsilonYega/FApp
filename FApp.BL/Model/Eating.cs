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
        public DateTime Moment { get; }
        public Dictionary<Food, double> DictionaryOfFood { get; }
        public User User { get; }
        public Eating(User user)
        {
            User = user?? throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            Moment = DateTime.Now;
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
