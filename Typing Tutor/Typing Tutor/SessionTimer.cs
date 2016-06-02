using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class SessionTimer
    {
        DateTime startSession;
        DateTime stopSession;

        public SessionTimer()
        {

        }

        //Properties
        public DateTime StartSession
        {
            get { return startSession; }
            set { startSession = value; }
        }
        

        public DateTime StopSession
        {
            get { return stopSession; }
            set { stopSession = value; }
        }

        //returns the seconds 
        public string GetDuration()
        {
            int seconds = 0;
            TimeSpan duration = StopSession - StartSession;
            seconds = duration.Seconds;
            if (duration.Minutes > 0)
            {
                
                seconds += (duration.Minutes * 60);
            }

            return seconds.ToString();

        }

        public void Start()
        {
            StartSession = DateTime.Now;
        }
        public void Stop()
        {
             StopSession  = DateTime.Now;
        }
    }
}
