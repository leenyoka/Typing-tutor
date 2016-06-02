using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class NumKeys
    {
        string[] index = new string[] {"1" , "4", "7" };

        string[] middle = new string[] { "2", "5", "8", "/" };

        string[] ring = new string[] { ".", "3", "6", "9", "*" };

        string[] pinkie = new string[] { "+", " -" };

        string[] thumb = new string[] { "0" };




        public bool IsInArray(string tempstring, string[] arr)
        {
            bool yes = false;

            foreach (string a in arr)
            {
                if (a == tempstring)
                {
                    yes = true;
                    break;
                }
            }
            return yes;

        }

        public string GetFinger(string a)
        {
            string finger = "";

            if(IsInArray(a, index))
            {
                return "index";
            }
            else if (IsInArray(a, middle))
            {
                return "middle";
            }
            else if (IsInArray(a, ring))
            {
                return "ring";
            }
            else if (IsInArray(a, pinkie))
            {
                return "pinkie";
            }
            else if (IsInArray(a, thumb))
            {
                return "thumb";
            }
            else
            {
                return finger;
            }
        }

        public bool RightKeyPressed(string key, string compare)
        {
            

            string pressedkey = key.Substring(6, 1);

            if (compare == pressedkey)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public NumKeys()
        {
        }

    }
}
