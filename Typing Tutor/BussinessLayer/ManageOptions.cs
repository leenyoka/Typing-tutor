using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class ManageOptions
    {
        string moName;
        string moValue;

        //Constructor
        public ManageOptions(string id, string n)
        {
            moName = id;
            moValue = n;
        }
        public ManageOptions()
        {
            
        }
        
        //properties
        public string MoName
        {
            get { return moName; }
            set { moName = value; }
        }
        
        public string MoValue
        {
            get { return moValue; }
            set { moValue = value; }
        }
    }
}
