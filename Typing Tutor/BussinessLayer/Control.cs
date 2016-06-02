using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class Control
    {
        string controlname;
        string controlvalue;

        //constructors
        public Control(string contrl, string conVal)
        {
            controlname = contrl;
            controlvalue = conVal;
        }
        public Control()
        {
            
        }

        //Properties

        public string ControlName
        {
            get { return controlname; }
            set { controlname = value; }
        }
        

        public string ControlValue
        {
            get { return controlvalue; }
            set { controlvalue = value; }
        }


    }
}
