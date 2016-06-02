using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class helpmetest
    {
        private string[] abc = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i",
                            "j", "k", "l"};


        private int count = 0;

        int currentIndex = 0;

        public helpmetest()
        {

        }
        public void resetMe()
        {
            count = 0;
            currentIndex = 0;
        }



        public string nextv()
        {
            // will never return the value at index zero
            //if (count == 0)
            //{
            //    count++;
            //    return abc[0];

            //}

            try
            {
                count++;

                return abc[count];
            }
            catch
            {
                //out of range
                throw new ApplicationException();
            }
            ////return cu;
        }

        public int getCurrentIndex()
        {
            return currentIndex;
        }

        public int getNextIndex()
        {
            //return it only if its smoller than 7
            return currentIndex + 1;
        }

        public void setCurrentIndex(string a)
        {
            //the index of the row in the array
            if (a == "l")
            {
                //index 0
                currentIndex = 0;
            }
            else if (a == "k")
            {
                //index 1
                currentIndex = 1;
            }
            else if (a == "j")
            {
                //index 2
                currentIndex = 2;
            }
            else if (a == "i")
            {
                //index 3
                currentIndex = 3;
            }
            else if (a == "h")
            {
                //index 4
                currentIndex = 4;
            }
            else if (a == "g")
            {
                //index 5
                currentIndex = 5;
            }
            else if (a == "f")
            {
                //index 6
                currentIndex = 6;
            }
        }

        public int getMyIndex(string a)
        {
            //the index of the row in the array
            if (a == "l")
            {
                //index 0
                return 0;
            }
            else if (a == "k")
            {
                //index 1
                return 1;
            }
            else if (a == "j")
            {
                //index 2
                return 2;
            }
            else if (a == "i")
            {
                //index 3
                return 3;
            }
            else if (a == "h")
            {
                //index 4
                return 4;
            }
            else if (a == "g")
            {
                //index 5
                return 5;
            }
            else if (a == "f")
            {
                //index 6
                return 6;
            }
            else
            {
                return 8;
            }
        }

        public string previousv()
        {
            try
            {


                return abc[count - 1];
            }
            catch
            {
                //out of range
                //throw new ApplicationException();
            }
            return "l";
        }

        public char getkey()
        {
            try
            {
                char nextchar = char.Parse(nextv());
                setCurrentIndex(nextchar.ToString());
                return nextchar;
            }
            catch
            {
                throw new ApplicationException();
            }
        }
    }
}
