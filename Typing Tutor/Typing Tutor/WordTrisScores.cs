using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    class WordTrisScores
    {
        int errors;

        public int Errors
        {
            get { return errors; }
            set { errors = value; }
        }
        int strokes;

        public int Strokes
        {
            get { return strokes; }
            set { strokes = value; }
        }
        int completedWords;

        public int CompletedWords
        {
            get { return completedWords; }
            set { completedWords = value; }
        }
        int speed;

        int missedwords;

        public int Missedwords
        {
            get { return missedwords; }
            set { missedwords = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        int incorrectSubmitions;

        public int IncorrectSubmitions
        {
            get { return incorrectSubmitions; }
            set { incorrectSubmitions = value; }
        }

        int points = 0;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }



        int scoreDecrease = 10;

        public int ScoreDecrease
        {
            get { return scoreDecrease; }
            set { scoreDecrease = value; }
        }

        int scoreIncrease = 3;//use it when a correct work is submitted

        public int ScoreIncrease
        {
            get { return scoreIncrease; }
            set { scoreIncrease = value; }
        }






        public WordTrisScores()
        {
            errors = 0;
            strokes = 0;
            completedWords = 0;
            speed = 0;
            incorrectSubmitions = 0;
            points = 0;
            //reset all the fields
        }
    }
}
