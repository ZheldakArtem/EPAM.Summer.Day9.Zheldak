using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1;
namespace Task1.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer =new Timer(2);
            var personArtem = new Person(15, "Artem", "Pupkin");
            var personDima = new Person(16, "Dima", "Vasin");
            var animal = new Animal(timer, "Sharik");

            personDima.Register(timer);
            personArtem.Register(timer);
            timer.SimulateTimeRing("Wake up");
            personArtem.UnRegister(timer);

            timer.SimulateTimeRing("Wake up");
            Console.ReadKey();
        }
    }
}
