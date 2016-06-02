using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class fingerDetails
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string hand;

        public string Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        double seconds;

        public double Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        int erorrCount;

        public int ErorrCount
        {
            get { return erorrCount; }
            set { erorrCount = value; }
        }

        int keyCount;

        public int KeyCount
        {
            get { return keyCount; }
            set { keyCount = value; }
        }

        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        int accuracy;

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public fingerDetails(string name, string hand)
        {
            this.name = name;
            this.hand = hand;
        }
    }
}
