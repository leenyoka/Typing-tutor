using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class WordWatcher
    {
        private string[] currentWord;//can get this
        private string userWord;
        private int startingIndex;
        private int stoppingIndex;

        private string currentRow;//can get this

        private int currentIndex;



        #region Properties

        public string[] CurrentWord
        {
            get { return currentWord; }
            set { currentWord = value; }
        }



        public string UserWord
        {
            get { return userWord; }
            set { userWord = value; }
        }



        public int StartingIndex
        {
            get { return startingIndex; }
            set { startingIndex = value; }
        }



        public int StoppingIndex
        {
            get { return stoppingIndex; }
            set { stoppingIndex = value; }
        }



        public string CurrentRow
        {
            get { return currentRow; }
            set { currentRow = value; }
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }



        #endregion Properties


        public WordWatcher()
        {
            userWord = "";
            currentRow = "Rowa";
            userWord = "";

        }


        #region Methods

        public bool setCurrentWord(string[] word)
        {
            CurrentWord = word;
            setStartingIndex(word);
            setStoppingINdex(word);
            currentIndex = startingIndex;
            return true;


        }
        public void setStartingIndex(string[] word)
        {
            int a = GetStartIndex(word);
            StartingIndex = a;
        }
        public void setStoppingINdex(string[] word)
        {
            int a = GetStoppingIndex(StartingIndex, word);
            StoppingIndex = a;
        }

        public int GetStartIndex(string[] word, int a)
        {
            int zii = word.Length;

            if (zii == 3 || zii == 4)
            {
                return 7;
            }
            else if (zii == 5 || zii == 6)
            {
                return 6;
            }
            else if (zii == 7 || zii == 8)
            {
                return 5;
            }
            else if (zii == 9 || zii == 10)
            {
                return 4;
            }
            else if (zii == 11 || zii == 12)
            {
                return 3;
            }
            else if (zii == 13)
            {
                return 2;
            }
            else if (zii == 14 || zii == 15)
            {
                return 1;
            }
            else
            {
                return 8;//at the middle
            }
        }

        public int GetStartIndex(string[] word)
        {
            for (int m = 0; m < word.Length; m++)
            {
                if (word[m] != " " && word[m] != "")
                {
                    return m;
                }
            }
            return 1;
        }


        public int GetStoppingIndex(int startingIndex, string[] word)
        {

            return (startingIndex + getwordlegnth(word));
        }

        public int getwordlegnth(string[] word)
        {
            int count = 0;

            for (int m = 0; m < word.Length; m++)
            {
                if (word[m] != " " && word[m] != "")
                {
                    count++;
                }
            }

            return count;
        }

        public void addtoUserword(string mychar)
        {
            userWord += mychar;
        }

        public string getWordAtCurrentIndex()
        {
            return currentWord[currentIndex];
        }


        #endregion Methods



    }
}
