using System;
using System.Text;
using Crestron.SimplSharp;


namespace SPlusPeriodicTimer
{
    public class PeriodicTimer
    {
        public delegate void PeriodicTimerCallbackHandler();
        public PeriodicTimerCallbackHandler PeriodicTimerCallback { get; set; }
        
        private CTimer PT = null;
        private long Period;

        /// <summary>
        /// SIMPL+ can only execute the default constructor.
        /// </summary>
        public PeriodicTimer()
        {
        }
   
        /// <summary>
        /// Initializes the periodic timer.
        /// </summary>
        /// <param name="period">Timer period in seconds.</param>
        public void Initialize(ushort period)
        {
            Period = period * 1000; // convert seconds to milliseconds
            PT = new CTimer(OnTimerExpired, Period);
            PT.Stop(); 
        }
        
        /// <summary>
        /// Starts the periodic timer.
        /// </summary>
        public void Start()
        {
            PT.Reset(Period, Period);
        }

        /// <summary>
        /// Stops the periodic timer.
        /// </summary>
        public void Stop()
        {
            PT.Stop();
        }

        /// <summary>
        /// Calls the Simpl+ delegate function PeriodicEvent()
        /// </summary>
        /// <param name="o"></param>
        public void OnTimerExpired(object sender)
        {
            PeriodicTimerCallback();
        }
    }
}
