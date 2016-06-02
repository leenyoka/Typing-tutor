using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class MyKeybaord
    {
        string[] thirdrow = new string[] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[",
            "{", "]", "}"};

        string[] homerow = new string[] { "a", "s", "d", "f", "g", "h", "i", "j", "k", "l", ";", ":", 
        "\"", "'"};

        string[] firstrow = new string[] {"z", "x", "c", "v", "b", "n", "m", ",", ".",
            "?", "/",};

        List<string> strongRows = new List<string>();

        public MyKeybaord()
        {

        }

        public List<string> getStrongRows(List<string> dif)
        {
            List<string> myRows = new List<string>();

            if(RowIsStrong(thirdrow, dif))
            {
                myRows.Add("Third Row");

            }

            if(RowIsStrong(homerow, dif))
            {
                myRows.Add("Home Row");

            }

            if(RowIsStrong(firstrow, dif))
            {
                myRows.Add("First Row");
            }

            return myRows;
        }

        public bool RowIsStrong(string[] row, List<string> dif)
        {
            foreach(string mystring in dif)
            {
                if(keyIsIn(mystring.ToLower(), row))
                {
                    return false;
                }
            }
            return true;
        }

        public bool keyIsIn(string key, string[] array)
        {
            bool isIn = false;

            foreach (string value in array)
            {
                if (key == value)
                {
                    isIn = true;
                    break;
                }
            }
            return isIn;
        }

    }
}
