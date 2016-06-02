
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class TestDifficultKeys
    {
        string testID;
        string keyname;

        //constructor
        public TestDifficultKeys(string testid, string key)
        {
            testID = testid;
            keyname = key;
        }

        //Properties
        public string TestID
        {
            get { return testID; }
            set { testID = value; }
        }
        

        public string Keyname
        {
            get { return keyname; }
            set { keyname = value; }
        }


    }
}
