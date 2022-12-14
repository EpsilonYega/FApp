using System;

namespace FApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 грамм продукты.
        /// </summary>
        public double Calories { get; }
        public Food(string name) : this(name, 0, 0, 0, 0) {}
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //Null?
            Name=name;
            Calories = calories / 100.0;
            Proteins = calories / 100.0;
            Fats = proteins / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            
            //double CaloriesOneGramm = Calories / 100.0;
            //double ProteinsOneGramm = Proteins / 100.0;
            //double FatsOneGramm = Fats / 100.0;
            //double CarbohydratesOneGramm = Carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
