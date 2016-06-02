using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class Mode
    {
        string modeID;
        string modename;

        //Constructor
        public Mode(string id, string n)
        {
            modeID = id;
            modename = n;
        }
        //Properties
        public string ModeID
        {
            get { return modeID; }
            set { modeID = value; }
        }
        

        public string Name
        {
            get { return modename; }
            set { modename = value; }
        }

    }
}
