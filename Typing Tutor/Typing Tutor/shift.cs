using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class shift
    {
        string[] leftShift = new string[] { "y", "h", "n", "m", "j", "u", "i", "o", "p", "k", "l" };

        string[] rightShift = new string[] { "q", "w", "e", "r", "t", "a", "d", "s", "f", "g", "x", "z", "c", "v", "b" };



        public shift()
        {
        }

        public bool isIn(string a, string[] b)
        {
            bool yes = false;
            foreach (string value in b)
            {
                if (value == a)
                {
                    yes = true;
                }
            }

            return yes;
        }

        public bool Leftshift(string a)
        {
            bool yes = false;

            foreach (string value in leftShift)
            {
                if (value == a.ToLower())
                {
                    yes = true;
                }
            }
            return yes;
        }
        public bool Rightshift(string a)
        {
            bool yes = false;

            foreach (string value in rightShift)
            {
                if (value == a.ToLower())
                {
                    yes = true;
                }
            }
            return yes;
        }
    }
}
