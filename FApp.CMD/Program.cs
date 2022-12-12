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
            program.InputText();
        }
        private void InputText()
        {
            Console.WriteLine("Добро пожаловать!");
            Console.Write("Введите имя пользователя:");
            string name = InputName();
            Console.Write("Введите пол пользователя:");
            string gender = InputGender();
            Console.Write("Введите дату рождения пользователя:");
            DateTime birthDate = InputDate();
            Console.Write("Введите вес пользователя:");
            double weight = InputWeight();
            Console.Write("Введите рост пользователя:");
            double height = InputHeight();
            var userController = new UserController(name, gender, birthDate, weight, height);
            SaveController(userController);
        }
        private string InputName()
        {
            var name = Console.ReadLine();
            return name;
        }
        private string InputGender()
        {
            var gender = Console.ReadLine();
            return gender;
        }
        private DateTime InputDate()
        {
            DateTime.TryParse(Console.ReadLine(), out var birthDate);
            return birthDate;
        }
        private double InputWeight()
        {
            double.TryParse(Console.ReadLine(), out var weight);
            return weight;
        }
        private double InputHeight()
        {
            double.TryParse(Console.ReadLine(), out var height);
            return height;
        }
        private void SaveController(UserController userController)
        {
            userController.Save();
        }
    }
}
