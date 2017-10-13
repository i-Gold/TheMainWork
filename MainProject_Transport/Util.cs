using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace Util
{
    class FileWork
    {
        private const string fileName = "file.txt";

        public void writeAllToFile(List<Transport> list)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            foreach(Transport t in list)
            {
                sw.WriteLine(t.infoToWrite());
                Console.WriteLine(t.infoToWrite());
            }
            sw.Close();
        }

        public List<Transport> readAllFromFile()
        {
            List<Transport> result = new List<Transport>();

            string[] fromFile = File.ReadAllLines(fileName);

            foreach (string s in fromFile)
            {
                string[] items = s.Split('\t');

                switch (items[1])
                {
                    case "Car":
                    {
                        getCarObject(items);
                        break;
                    }
                }
            }

            return result;
        }

        private Car getCarObject(string[] items)
        {
            Car car = new Car();

            car.Manufactor = items[2];
            car.Speed = int.Parse(items[3]);
            car.Weight = double.Parse(items[4]);
            car.Height = double.Parse(items[5]);
            car.Engine = getEngine(items);
            car.Amount = int.Parse(items[10]);
            car.Transmission = items[11];
            car.Body = items[12];

            return car;
        }

        private Engine getEngine(string[] items)
        {
            Engine engine = null;

            switch (items[6])
            {
                case "PetrolEngine":
                {
                    engine = getPetrolEngine(items);
                    break;
                }
            }

            return engine;
        }

        private PetrolEngine getPetrolEngine(string[] items)
        {
            PetrolEngine petrolEngine = new PetrolEngine();
            petrolEngine.Power = double.Parse(items[7]);
            petrolEngine.Manufactor = items[8];
            petrolEngine.Capacity = int.Parse(items[9]);
            
            return petrolEngine;
        }
    }

    public static class PrintWork
    {
        public static void printAll(List<Transport> list)
        {
            foreach(Transport t in list)
            {
                Console.WriteLine(t.getInformation());
            }
        }

        public static void printByCategory(List<Transport> list, string category)
        {
            foreach (Transport t in list)
            {
                if (category.Trim().Equals(t.GetType().Name))
                {
                    Console.WriteLine(t.getInformation());
                }
            }
        }
    }

    public static class SortWork
    {
        public static void sortByModel(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Manufactor.CompareTo(l2.Manufactor));
        }

        public static void sortBySpeed(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.Speed.CompareTo(l2.Speed));
        }

        public static void sortByCategory(List<Transport> list)
        {
            list.Sort((l1, l2) => l1.GetType().Name.CompareTo(l2.GetType().Name));
        }
    }

    public class SalesWork
    {
        public void sellItem(Transport transport, int amount)
        {
            int currentAmount = transport.Amount;
            if(amount < 0 || amount > currentAmount)
            {
                throw new ArithmeticException();
            }

            transport.Amount -= amount;
        }

        public void buyItem(Transport transport, int amount)
        {
            transport.Amount += amount;
        }
    }

    public class Menu
    {
        public void use()
        {
            SalesWork sw = new SalesWork();
            FileWork fw = new FileWork();
            List<Transport> worklist = new List<Transport>();
            bool flag = true;
            bool readFromFileFlag = false;
            string choise;
            Console.WriteLine("Welcome to our system!!!");

            do
            {
                printMenu();
                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        {
                            readFromFileItem(ref readFromFileFlag, worklist, fw);                           
                            break;
                        }
                    case "2":
                        {
                            printAllInformationItem(worklist);
                            break;
                        }
                    case "3.1":
                        {
                            SortWork.sortByModel(worklist);
                            PrintWork.printAll(worklist);
                            break;
                        }
                    case "6":
                        {
                            worklist.Add(addNewItem());
                            break;
                        }
                }

            } while (flag);  
        }

        private void printMenu()
        {
            Console.WriteLine("Make choise:");
            Console.WriteLine("1. Read all from file");
            Console.WriteLine("2. Print all information");
            Console.WriteLine("3. Sorting");
            Console.WriteLine("3.1 \t Sorting by model");
            Console.WriteLine("3.2 \t Sorting by speed");
            Console.WriteLine("3.3 \t Sorting by category");
            Console.WriteLine("4. Sell item");
            Console.WriteLine("5. Buy item");
            Console.WriteLine("6. Add item");
            Console.WriteLine("0. Exit");
        }

        private void readFromFileItem(ref bool readFromFileFlag, List<Transport> worklist, FileWork fw)
        {
            if (!readFromFileFlag)
            {
                worklist.AddRange(fw.readAllFromFile());
                readFromFileFlag = true;
                Console.WriteLine("Database loaded");
            }
            else
            {
                Console.WriteLine("Database is up to date");
            }
        }

        private void printAllInformationItem(List<Transport> worklist)
        {
            if (worklist.Count == 0)
            {
                Console.WriteLine("List is empty. Maybe you haven't load database. You can do it with Menu");
            }
            else
            {
                PrintWork.printAll(worklist);
            }
        }

        private Transport addNewItem()
        {
            Console.WriteLine("Choose your transport:");
            Console.WriteLine("1. Car");

            Transport transport = null;
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    {
                        transport = addCar();
                        break;
                    }
            }

            return transport;
        }

        private Car addCar()
        {
            Car car = new Car();
            Console.WriteLine("Enter speed: ");
            car.Speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter transmission: ");
            car.Transmission = Console.ReadLine();
            car.Engine = new Disel();

            return car;
        }
    }
}
