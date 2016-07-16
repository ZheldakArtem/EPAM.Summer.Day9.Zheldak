using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// The class describes an animal
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public Animal(Timer timer,string name = "Tuzik", string breed = "Dog")
        {
            Name = name;
            Breed = breed;
            RegisterTimer(timer);
        }

        private void RegisterTimer(Timer timer)
        {
            timer.TimerRing += (obj,e) => Console.WriteLine("{0} Go to eat Animal",e.AnyMessage);
        }
       

    }
}
