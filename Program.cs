using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine(); // 🔥 Захват чувствительных данных с консоли
            Console.WriteLine("Your password is: " + password); // 🔥 Вывод пароля в консоль
        }
    }
}
