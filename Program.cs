using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lesson13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] mercedes = new string[10, 6];
            string[,] bmw = new string[10, 6];
            string[,] audi = new string[10, 6];
            ShowGeneralMenu(bmw, mercedes, audi);

        }      
        public static void ShowGeneralMenu(string[,] bmw, string[,] mrs, string[,] audi)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1. BMW | 2. Mercedes | 3. Audi | 4. Exit");
                int option = int.Parse(Console.ReadLine());

                if (option < 1 || option > 4)
                {
                    Console.WriteLine("You select wrog option");
                    return;
                }

                switch (option)
                {
                    case 1:
                        SelectCar(bmw);
                        break;
                    case 2:
                        SelectCar(mrs);
                        break;
                    case 3:
                        SelectCar(audi);
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
        }

        public static void SelectCar(string[,] car)
        {

            bool flag = true;

            while (flag)
            {

                Console.Write(
                    "Press 1: Add car " +
                    "| Press 2: Get cars list " +
                    "| Press 3: Update list " +
                    "| Press 4: Delete car " +
                    "| Press 5: Get car by ID " +
                    "| Press 6: Exit");
                Console.WriteLine();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Choose mark");
                        string mark = Console.ReadLine();
                        Console.WriteLine("Choose model");
                        string model = Console.ReadLine();
                        Console.WriteLine("Choose year");
                        string year = Console.ReadLine();
                        Console.WriteLine("Choose color");
                        string color = Console.ReadLine();
                        Console.WriteLine("Choose price");
                        string price = Console.ReadLine();
                        AddCar(mark, model, year, color, price, car);
                        break;
                    case 2:
                        GetCar(car);
                        break;
                    case 3:
                        Console.WriteLine("Choose model");
                        string model1 = Console.ReadLine();
                        Console.WriteLine("Choose year");
                        string year1 = Console.ReadLine();
                        Console.WriteLine("Choose color");
                        string color1 = Console.ReadLine();
                        Console.WriteLine("Choose price");
                        string price1 = Console.ReadLine();
                        UpdateCar(model1, year1, color1, price1, car);
                        break;
                    case 4:
                        Console.Write("Please input id: ");
                        string deleteID = Console.ReadLine();
                        DeleteCarByID(car, deleteID);
                        break;
                    case 5:
                        Console.Write("Please input id: ");
                        string id = Console.ReadLine();
                        GetCarByID(car, id);
                        break;
                    case 6:
                        flag = false;
                        break;

                }
            }
        }

        public static string[,] AddCar(string mark, string model, string year, string color, string price, string[,] car)
        {
            string id = Guid.NewGuid().ToString();

            for (int i = 0; i < car.GetLength(0); i++)
            {
                if (car[i, 0] == null)
                {
                    car[i, 0] = id;
                    car[i, 1] = mark;
                    car[i, 2] = model;
                    car[i, 3] = year;
                    car[i, 4] = color;
                    car[i, 5] = price;
                    return car;
                }
            }
            return car;
        }

        public static string[,] UpdateCar(string model, string year, string color, string price, string[,] car)
        {
            for (int i = 0; i < car.GetLength(0); i++)
            {
                if (car[i, 0] == null)
                {
                    car[i, 2] = model;
                    car[i, 3] = year;
                    car[i, 4] = color;
                    car[i, 5] = price;
                    return car;
                }
            }
            return car;
        }


        public static void GetCar(string[,] car)
        {
            for (int i = 0; i < car.GetLength(0); i++)
            {
                if (car[i, 0] != null)
                {
                    for (int j = 0; j < car.GetLength(1); j++)
                    {
                        Console.Write(car[i, j] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        public static void GetCarByID(string[,] car, string id)
        {
            for (int i = 0; i < car.GetLength(0); i++)
            {
                if (car[i, 0] == id)
                {
                    for (int j = 0; j < car.GetLength(1); j++)
                    {
                        Console.Write(car[i, j] + " ");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You choose wrong ID number, list is empty");
                    Console.WriteLine();
                    break;
                }
                break;
            }
        }

        public static string[,] DeleteCarByID(string[,] car, string id)
        {
            for (int i = 0; i < car.GetLength(0); i++)
            {
                if (car[i, 0] == id)
                {
                    car[i, 0] = null;
                    car[i, 1] = null;
                    car[i, 2] = null;
                    car[i, 3] = null;
                    car[i, 4] = null;
                    car[i, 5] = null;
                    return car;
                } 
            }
            return car;
        } 

    }
}
