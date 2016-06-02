using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessLayer;

namespace Typing_Tutor
{
    public class TypingSpeed
    {
        int numberOfCharacters;
        int numberOfErrors;
        int secondsElapsed;
        bool wpm = true;

        public bool Wpm
        {
            get { return wpm; }
            set { wpm = value; }
        }

        //properties
        public int NumberOfCharacters
        {
            get { return numberOfCharacters; }
            set { numberOfCharacters = value; }
        }

        public int SecondsElapsed
        {
            get { return secondsElapsed; }
            set { secondsElapsed = value; }
        }

        public int NumberOfErrors
        {
            get { return numberOfErrors; }
            set { numberOfErrors = value; }
        }

        //Constrcutor
        public TypingSpeed(int charactors, int seconds, int errors, bool wpm)
        {
            numberOfCharacters = charactors;
            secondsElapsed = seconds;
            numberOfErrors = errors;
            this.wpm = wpm;
        }

        public TypingSpeed()
        {

        }


        //Returns the speed in words per minute
        public int GetWordsPerMinute()
        {
            int speed = 0;

            try
            {
                int words = NumberOfCharacters / 5;

                int adjustedWPM = (words - NumberOfErrors) * (60 / SecondsElapsed);

                if (adjustedWPM > 0)
                {
                    speed = adjustedWPM;
                }

            }
            catch
            {
                //devide by zero
            }

            return speed;
        }

        public int GetTypingSpeed()
        {
            if (Wpm)
            {
                return GetWordsPerMinute();
            }
            else
            {
                return GetCharactersPerMinute();
            }
        }

        //returns the speed in characters per minute
        public int GetCharactersPerMinute()
        {
            //int adjustedCPM = (NumberOfCharacters - NumberOfErrors) * (60 / SecondsElapsed);

            //return adjustedCPM;

            return GetWordsPerMinute() * 5;
        }
        //Returns the error rate
        public int GetErrorRate()
        {
            int errorRate = 0;
            //calculate error rate

            return errorRate;
        }

        public int CalculateAccuracy(int totalStrokes, int ErrorsMade)
        {
            int tempAcc = 0;

            if (ErrorsMade > 0)
            {
                //tempAcc = (totalStrokes / ErrorsMade) * 10;
                int tempAcc2 = (ErrorsMade * 100) / totalStrokes;
                tempAcc = 100 - tempAcc2;
            }
            else
            {
                tempAcc = 100;
            }

            return tempAcc;

        }

        public int GetSpeed(List<PressWatcher> testInfor)
        {
            int speed = 0;
            double totaltime = 0;
            int strokes = 0;
            int errors = 0;

            foreach (PressWatcher watch in testInfor)
            {
                totaltime += watch.ReactionTime;
                strokes++;
                if (watch.Missed1)
                {
                    errors++;
                }
            }

            TypingSpeed tt = new TypingSpeed(strokes, int.Parse((Math.Round(totaltime)).ToString()), errors, wp());

            speed = tt.GetTypingSpeed();
            return speed;
        }
        BussinessLayer.DataAccess da = new DataAccess();

        public bool wp()
        {
            try
            {
                if (da.GetAnOption("Speed").MoValue == "wpm")
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch
            {
                
            }
            return false;
        }


        //Returns the accuracy
        //public int GetAccuracy()
        //{
        //    if (NumberOfErrors != 0)
        //    {

        //        double number = (NumberOfErrors / NumberOfCharacters * 100);
        //        //double number = (NumberOfErrors * 100 / NumberOfCharacters);
        //        return int.Parse(number.ToString());
        //    }
        //    else
        //    {
        //        return 100;
        //    }

            
        //}
    }
}
