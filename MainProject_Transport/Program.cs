using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Util;

namespace MainProject_Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.use();

            Console.ReadLine();
        }
    }
}
