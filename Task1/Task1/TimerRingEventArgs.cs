using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Determination of the type that stores information,
    /// which is transmitted to recipients of event notifications.
    /// </summary>
    public class TimerRingEventArgs
    {
        public DateTime DateRing { get; }
        public string AnyMessage { get; }

        public TimerRingEventArgs(string timerDuration, DateTime dateRing)
        {
            AnyMessage = timerDuration;
            DateRing = dateRing;
        }
    }
}
