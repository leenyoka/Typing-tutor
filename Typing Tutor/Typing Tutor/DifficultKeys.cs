using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class DifficultKeys
    {
        string missedKeys = "";
        string difficultKeys = "";
        
        
        //Properties

        public string DifficultKeys1
        {
            get { return difficultKeys; }
            set { difficultKeys = value; }
        }

        

        
        public string MissedKeys
        {
            get { return missedKeys; }
            set { missedKeys = value; }
        }
        
        //constructor
        public DifficultKeys()
        {
        }

        //methods
        public void AddToMissedKeys(string missedKey)
        {
            MissedKeys += missedKey;
        }
        public string GetDifficultKeys()
        {
            string a = GetDistinctKeys();

            foreach (char mychar in a)
            {
                int counts = 0;
                foreach (char myother in missedKeys)
                {
                    if (mychar.ToString().ToLower() == myother.ToString().ToLower())
                    {
                        counts++;
                    }
                }

                if (counts >= 3)
                {
                    //still need to decide how many times a person has to miss a key for it
                    //to be concidered a difficult key
                    //add to dif keys
                    DifficultKeys1 += mychar.ToString().ToUpper() + " ";
                }

            }
            return DifficultKeys1;
            
        }

        public string GetDistinctKeys()
        {
            string a = "";
            foreach (char mychar in missedKeys)
            {
                if (charIsNotIN(mychar, a))
                {
                    a += mychar.ToString().ToUpper();
                }
            }
            return a;
        }
        public bool charIsNotIN(char a, string b)
        {
            bool yes = true;

            foreach (char mychar in b)
            {
                if (mychar.ToString().ToLower() == a.ToString().ToLower())
                {
                    yes = false;
                }
            }

            return yes;
        }


        #region First Try
        //string[] arr = new string[0];
        //string[] dif = new string[0];

        ////constructor
        //public DifficultKeys()
        //{
        //}

        ////methods

        //public bool IsInErrors(string a, string[] arr)
        //{
        //    bool yes = false;
        //    foreach (string value in arr)
        //    {
        //        if (value == a)
        //        {
        //            return true;
        //        }
        //    }

        //    return yes;
        //}

        //public void AddToErrors(string a)
        //{
        //    int newSize = arr.Length + 1;
        //    Array.Resize<string>(ref arr, newSize);

        //    arr[arr.Length - 1] = a;

        //}
        //public void AddToArr(string a, string []arr)
        //{
        //    int newSize = arr.Length + 1;
        //    Array.Resize<string>(ref arr, newSize);

        //    arr[arr.Length - 1] = a;

        //}

        //public string GetDifficultKeys()
        //{
        //    string tempdif = "";
        //    string [] arr = new string[0];

        //    string[] dif1 = GetDistinct();

        //    foreach (string value in dif1)
        //    {
        //        if (IsAdifficultKey(value))
        //        {
        //            AddToArr(value, arr);
        //            //tempdif += value + " ";
        //            //adds it even if its already in the diff keys
        //        }
        //    }
        //    arr.Distinct<string>();

        //    tempdif = arrayTostrong(arr);

        //    return tempdif;
        //}
        //public string arrayTostrong(string[] a)
        //{
        //    string temp = "";

        //    foreach (string value in a)
        //    {
        //        temp += value + " ";
        //    }
        //    return temp;

        //}

        //public bool IsAdifficultKey(string a)
        //{
        //    bool yes = false;
        //    int tempcount = 0;

        //    foreach (string value in arr)
        //    {
        //        if (a == value)
        //        {
        //            tempcount++;
        //        }
        //    }

        //    if (tempcount >= 3)
        //    {
        //        //still have to decide how many times does a person have to miss
        //        //a key for it to be concidered a difficult key for them
        //        yes = true;
        //    }

        //    return yes;

        //}

        //public string[] GetDistinct()
        //{
        //    string[] a = arr;

        //    a.Distinct<string>();

        //    return a;
        //}

        #endregion First Try

    }
}
