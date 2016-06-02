using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer
{
    public class DifficultKeys
    {
        string keyname;
        string testid;

        public string Testid
        {
            get { return testid; }
            set { testid = value; }
        }

        public string Keyname
        {
            get { return keyname; }
            set { keyname = value; }
        }

        public DifficultKeys(string key)
        {
            keyname = key;
        }
        public DifficultKeys(string key, string testID)
        {
            keyname = key;
            testid = testID;

        }

    }
}
