using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
   public sealed class Timer
    {
       
        private readonly int _timeToRing;
        /// <summary>
        /// Defining Member-events
        /// </summary>
        public event EventHandler<TimerRingEventArgs> TimerRing;

        public Timer(int timeToCall=1000)
        {
            _timeToRing = timeToCall*1000;
        }
        /// <summary>
        /// Determining the method responsible for notifying the registered objects of the event
        /// </summary>
        public void OnTimerRing(object sender,TimerRingEventArgs e)
        {
            TimerRing?.Invoke(sender, e);
        }
        /// <summary>
        /// Determining the method that broadcasts the input information to the desired event
        /// </summary>
        public void SimulateTimeRing(string message)
        {
            Thread.Sleep(_timeToRing);
            OnTimerRing(this, new TimerRingEventArgs(message,DateTime.Now));
        }
    }
}
