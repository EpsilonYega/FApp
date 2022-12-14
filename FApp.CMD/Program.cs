using FApp.BL.Controller;
using FApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace FApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InputData();
        }
        private void InputData()
        {
            //Поменять кодировку при свапе языка (как минимум для Китайского)
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FApp.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            //Console.WriteLine(Languages.Messages_ru_ru.Hello); 
            //Console.Write(Languages.Messages_ru_ru.EnterName);

            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterTheGender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");
                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine(resourceManager.GetString("WaitingForAction", culture));
            Console.WriteLine(resourceManager.GetString("EnterEating", culture));
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var food = EnterEating();
                eatingController.Add(food.Food, food.Weight);

                foreach (var item in eatingController.Eating.DictionaryOfFood)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();
        }
        private (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта:");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prot, fats, carbs);
            return (Food: product, Weight: weight);
        }
        private double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
        }
        private DateTime ParseDateTime()
        {
            while (true)
            {
                Console.Write("Введите дату рождения (dd:MM:yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }
        }
    }
}
