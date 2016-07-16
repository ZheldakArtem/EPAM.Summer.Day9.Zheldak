using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// The class describes an person
    /// </summary>
    public class Person
    {
        private int _age;
        public string Name { get; }
        public string LastName { get; }

        public int Age
        {
            get { return _age; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Negative age");
                _age = value;
            }
        }

        public Person(int age, string name = "Anonim", string lastName = "Anonim")
        {
            if (name == null || lastName == null)
                throw new ArgumentException();
            Age = age;
            Name = name;
            LastName = lastName;
        }

        public void Register(Timer ring)
        {
            ring.TimerRing += RingTimer;
        }

        ///<summary>
        /// Timer calls this method to notify
        ///Person about end of time
        /// </summary>
        private void RingTimer(object sender, TimerRingEventArgs e)
        {
            Console.WriteLine("{0}!!! Now is {1}, you should {2}", Name, e.DateRing, e.AnyMessage);
        }

        public void UnRegister(Timer ring)
        {
            ring.TimerRing -= RingTimer;
        }
    }
}
