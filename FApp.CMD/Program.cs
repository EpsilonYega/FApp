using FApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Добро пожаловать!");
            Console.Write("Введите имя пользователя:");

            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол:");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");
                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            
            Console.WriteLine(userController.CurrentUser);
            
            Console.ReadLine();
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
                    Console.WriteLine($"Неверный формат {name}!");
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
