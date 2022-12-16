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
        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("en-us");
        private static ResourceManager resourceManager = new ResourceManager("FApp.CMD.Languages.Messages", typeof(Program).Assembly);
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InputData();
        }
        private void InputData()
        {
            //Поменять кодировку при свапе языка (как минимум для Китайского)
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            //Console.WriteLine(Languages.Messages_ru_ru.Hello); 
            //Console.Write(Languages.Messages_ru_ru.EnterName);

            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterTheGender", culture));
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime(resourceManager.GetString("DateOfBirth", culture));
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");
                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            while (true)
            {
                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine(resourceManager.GetString("WaitingForAction", culture));
                Console.WriteLine(resourceManager.GetString("EnterEating", culture));
                Console.WriteLine(resourceManager.GetString("EnterActivity", culture));
                Console.WriteLine(resourceManager.GetString("EnterQuit", culture));
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.Add(food.Food, food.Weight);

                        foreach (var item in eatingController.Eating.DictionaryOfFood)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity}: {item.Start.ToShortTimeString()} - {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine(resourceManager.GetString("EnterExerciseName", culture));
            var name = Console.ReadLine();
            var energy = ParseDouble(resourceManager.GetString("EnergyLossPerMinute", culture)); 
             var begin = ParseDateTime(resourceManager.GetString("TheBeginningOfExercise", culture));
            var end = ParseDateTime(resourceManager.GetString("TheEndOfExercise", culture));
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private (Food Food, double Weight) EnterEating()
        {
            Console.Write(resourceManager.GetString("EnterProductName", culture));
            var food = Console.ReadLine();

            var calories = ParseDouble(resourceManager.GetString("Calories", culture));
            var prot = ParseDouble(resourceManager.GetString("Proteins", culture));
            var fats = ParseDouble(resourceManager.GetString("Fats", culture));
            var carbs = ParseDouble(resourceManager.GetString("Carbohydrates", culture));

            var weight = ParseDouble(resourceManager.GetString("WeightOfMeal", culture));
            var product = new Food(food, calories, prot, fats, carbs);
            return (Food: product, Weight: weight);
        }
        private double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"{resourceManager.GetString("Enter", culture)} {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"{resourceManager.GetString("InvalidFieldFormat", culture)} {name}!");
                }
            }
        }
        private DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"{resourceManager.GetString("Enter", culture)} {value} (dd:MM:yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"{resourceManager.GetString("InvalidFieldFormat", culture)} {value}!");
                }
            }
            return birthDate;
        }
    }
}
