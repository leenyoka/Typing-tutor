using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Typing_Tutor
{
    public class TextFileToString
    {
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        //constructor
        public TextFileToString(string fn)
        {
            fileName = fn;
        }

        //methods

        //reads the file into a string and returns the string
        public string ReadToString()
        {
            try
            {
                StreamReader sr = new StreamReader(FileName);
                string read = "";
                //while (sr.Read() != -1)
                //{
                //    read += sr.ReadLine();
                //}

                do
                {
                    read += sr.ReadLine();
                }
                while(sr.Peek() != -1);

                sr.Close();

                return read;
            }
            catch
            {
                throw new ApplicationException();
            }
        }
    }
}
