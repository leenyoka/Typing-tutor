using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class myStateTris
    {
        private string previousRow;
        private string currentRow;
        private string nextRow;
        private int currentindex = 0;

        private string[] allRows = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i",
                            "j", "k", "l", ""};

        #region Properties

        public string CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }


        public string NextRow
        {
            get { return nextRow; }
            set { nextRow = value; }
        }
        #endregion Properties


        public myStateTris()
        {
            currentindex = 1;
            currentRow = "Rowa";
            nextRow = "Rowb";
            previousRow = "";
        }

        public bool Move()
        {
            currentindex++;

            if (currentindex >= 0 && currentindex <= 12)
            {
                previousRow = "Row" + allRows[currentindex - 1];


                currentRow = "Row" + allRows[currentindex];

                //try
                //{
                nextRow = "Row" + allRows[currentindex + 1];
                //}
                //catch
                //{
                //    //there is no next row
                //    nextRow = "Rowb";
                //}
            }

            if (currentindex > allRows.Length)
            {
                return false;
            }
            return true;

        }

        public string getCurrentRow()
        {
            return currentRow;
        }



        public string getPreviousRow()
        {
            return previousRow;
        }

        public string RowToMoveTo()
        {
            if (Move())
            {
                return currentRow;
            }
            else
            {
                throw new ApplicationException();
            }
        }

        public int getCurrentIndex()
        {
            return currentindex;
        }
        public int getNextIndex()
        {
            return currentindex + 1;
        }


    }
}
