using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace assignment4
{

    public class ClockEventArgs : EventArgs
    {
        public DateTime CurrentTime { get; }

        public ClockEventArgs(DateTime currentTime)
        {
            CurrentTime = currentTime;
        }
    }

    

    public class Clock
    {

        //定义委托
        public delegate void ClockEventHandler(object sender, ClockEventArgs e);
        
        //Tick事件
        public event ClockEventHandler Tick;

        //Alarm事件
        public event ClockEventHandler Alarm;

        private System.Timers.Timer timer;
        private DateTime alarmTime;

        public Clock(int interval, DateTime alarmTime)
        {
            this.alarmTime = alarmTime;

            timer = new System.Timers.Timer(interval);

            timer.Elapsed += OnTick;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Tick?.Invoke(this, new ClockEventArgs(DateTime.Now));

            if (DateTime.Now >= alarmTime)
            {
                Alarm?.Invoke(this, new ClockEventArgs(DateTime.Now));
                Stop();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateTime alarmTime = DateTime.Now.AddSeconds(10);

            Clock clock = new Clock(1000, alarmTime);

            clock.Tick += (sender, e) => Console.WriteLine($"Tick: {e.CurrentTime.ToLongTimeString()}");
            clock.Alarm += (sender, e) => Console.WriteLine($"Alarm: {e.CurrentTime.ToLongTimeString()} - Time to wake up!");

            clock.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
