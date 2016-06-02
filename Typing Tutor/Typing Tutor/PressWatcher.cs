using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class PressWatcher
    {
        string keyname;
        string previouskey;

        public string Previouskey
        {
            get { return previouskey; }
            set { previouskey = value; }
        }
        TimeSpan duration = new TimeSpan(0, 0, 0, 0, 0);
        DateTime start;
        DateTime end;

        TimeSpan pauseDuration;
        DateTime puaseStart;
        DateTime puaseEnd;
        bool puased = false;

        string hand;

        
        string finger;

        
        double reactionTime;
        bool missed = false;

        public bool Missed1
        {
            get { return missed; }
            set { missed = value; }
        }

        
        QwertyEnglish qwt = new QwertyEnglish();



        #region Properties


        public string Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        public string Finger
        {
            get { return finger; }
            set { finger = value; }
        }

        public double ReactionTime
        {
            get { return reactionTime; }
            set { reactionTime = value; }
        }

        public string Keyname
        {
            get { return keyname; }
            set { keyname = value; }
        }
        

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        #endregion Properties

        #region Constructor

        //public PressWatcher(string key)
        //{
        //    this.keyname = key;
        //    this.start = Now();

        //    this.hand = qwt.GetHand(key);
        //    this.finger = qwt.GetFinger(key);
        //}

        public PressWatcher(string key, string previous)
        {
            this.keyname = key;
            this.start = Now();

            this.hand = qwt.GetHand(key, previous);
            this.finger = qwt.GetFinger(key);
            this.Previouskey = previous;
        }
        #endregion Constructor



        #region Methods


        public DateTime Now()
        {
            return DateTime.Now;
        }

        public void EndWatch()
        {
            this.end = Now();
            this.duration += end - start;
            this.ReactionTime = ConvertMillisecondsToSeconds(double.Parse(Duration.TotalMilliseconds.ToString()));
        }
        public void pause()
        {
            puaseStart = DateTime.Now;
            puased = true;
        }
        public void resume()
        {
            puaseEnd = DateTime.Now;

            this.pauseDuration = this.puaseEnd - this.puaseStart;

            this.duration -= this.pauseDuration;
            puased = false;
        }
        


        public static double ConvertMillisecondsToSeconds(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
        }
        public void Missed()
        {
            this.missed = true;
        }

        #endregion Methods

    }
}
