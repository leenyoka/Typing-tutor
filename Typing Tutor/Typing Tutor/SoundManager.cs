using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;

namespace Typing_Tutor
{
    class SoundManager
    {
        SoundPlayer erorrSound;
        MySoundPlayer[] numberSounds = new MySoundPlayer[10];
        MySoundPlayer[] charactorSounds = new MySoundPlayer[26];
        List<MySoundPlayer> voices = new List<MySoundPlayer>();
        List<MySoundPlayer> symbols = new List<MySoundPlayer>();
        MySoundPlayer[] sentence = new MySoundPlayer[6];//six is the initial size(old) 4
        int sleepDuration = 458;

        string[] myCharactors = new string[26]{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
            "m", "n", "o","p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};


        QwertyEnglish mykeyboardhelp = new QwertyEnglish();

        public QwertyEnglish Mykeyboardhelp
        {
            get { return mykeyboardhelp; }
            set { mykeyboardhelp = value; }
        }


        #region Constructor
        public SoundManager(string ErrorFile)
        {
            var errorFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ErrorFile);
            erorrSound = new SoundPlayer(errorFilePath);
            //erorrSound.Play();
            initailizeMyNumbers();
            intializeMyCharactors();
            initailizedMyVoices();
            initailizeMySymbols();

            //Play("w");
        }

        public void PlayError()
        {
            erorrSound.Play();
            //initailizeMyNumbers();
            //intializeMyCharactors();
            //initailizedMyVoices();
            
        }
        #endregion Constructor

        #region Methods

        public void initailizeMyNumbers()
        {
            string path = GetFullFilePath("Sound\\Keys\\");
            for (int m = 0; m <= 9; m++)
            {
                numberSounds[m] = new MySoundPlayer();
                numberSounds[m].Charactor = m.ToString();
                numberSounds[m].FilePath = path + m + ".wav";
            }
        }
        public void intializeMyCharactors()
        {
            string part = GetFullFilePath("Sound\\Keys\\");
            for (int m = 0; m < 26; m++)
            {
                charactorSounds[m] = new MySoundPlayer();
                charactorSounds[m].Charactor = myCharactors[m];
                charactorSounds[m].FilePath = part + myCharactors[m] + ".wav";

                //charactorSounds[m].StreamChanged += stopped;
               
            }
        }
        public void initailizedMyVoices()
        {
            string part = GetFullFilePath("Sound\\Keys\\");

            voices.Add(new MySoundPlayer("press", part + "press.wav"));
            voices.Add(new MySoundPlayer("with Your", part + "withyour.wav"));
            voices.Add(new MySoundPlayer("finger", part + "finger.wav"));
            voices.Add(new MySoundPlayer("right", part + "right.wav"));
            voices.Add(new MySoundPlayer("left", part + "left.wav"));
            voices.Add(new MySoundPlayer("pinkie", part + "pinkie.wav"));
            voices.Add(new MySoundPlayer("ring", part + "ring.wav"));
            voices.Add(new MySoundPlayer("middle", part + "middle.wav"));
            voices.Add(new MySoundPlayer("index", part + "index.wav"));
            voices.Add(new MySoundPlayer("thumb", part + "thumb.wav"));
        }
        public void initailizeMySymbols()
        {
            string part = GetFullFilePath("Sound\\Keys\\");

            symbols.Add(new MySoundPlayer("!", part + "exclamation.wav"));
            symbols.Add(new MySoundPlayer("@", part + "at.wav"));
            symbols.Add(new MySoundPlayer("#", part + "hash.wav"));
            symbols.Add(new MySoundPlayer("$", part + "dollar.wav"));
            symbols.Add(new MySoundPlayer("%", part + "percent.wav"));
            symbols.Add(new MySoundPlayer("^", part + "caret.wav"));
            symbols.Add(new MySoundPlayer("(", part + "openparenthesis.wav"));
            symbols.Add(new MySoundPlayer(")", part + "closeparenthesis.wav"));
            symbols.Add(new MySoundPlayer("-", part + "dash.wav"));
            symbols.Add(new MySoundPlayer("_", part + "underscore.wav"));
            symbols.Add(new MySoundPlayer("+", part + "plus.wav"));
            symbols.Add(new MySoundPlayer("=", part + "equals.wav"));
            symbols.Add(new MySoundPlayer("{", part + "openbrace.wav"));
            symbols.Add(new MySoundPlayer("}", part + "closebrace.wav"));
            symbols.Add(new MySoundPlayer("[", part + "openbracket.wav"));
            symbols.Add(new MySoundPlayer("]", part + "closebracket.wav"));
            symbols.Add(new MySoundPlayer("*", part + "asterisk.wav"));
            symbols.Add(new MySoundPlayer("|", part + "pipe.wav"));
            symbols.Add(new MySoundPlayer("\\", part + "backslash.wav"));
            symbols.Add(new MySoundPlayer("/", part + "forwardslash.wav"));
            symbols.Add(new MySoundPlayer(":", part + "colon.wav"));
            symbols.Add(new MySoundPlayer(";", part + "semicolon.wav"));
            symbols.Add(new MySoundPlayer("\"", part + "quote.wav"));
            symbols.Add(new MySoundPlayer("'", part + "singlequote.wav"));
            symbols.Add(new MySoundPlayer("<", part + "lessthan.wav"));
            symbols.Add(new MySoundPlayer(">", part + "greaterthan.wav"));
            symbols.Add(new MySoundPlayer(",", part + "comma.wav"));
            symbols.Add(new MySoundPlayer(".", part + "period.wav"));
            symbols.Add(new MySoundPlayer("?", part + "question.wav"));
            symbols.Add(new MySoundPlayer(" ", part + "space.wav"));
            //symbols.Add(new MySoundPlayer("", part + "space.wav"));
            


        }

        public void stopped(object sender, EventArgs e)
        {
            //planning to call it when...
        }



        #region Set file path
        public void SetAFilePathforAChar(string mychar, string path)
        {
            foreach (MySoundPlayer mysoundp in charactorSounds)
            {
                if (mychar.ToString() == mysoundp.Charactor)
                {
                    mysoundp.FilePath = path;
                    break;
                }
            }
        }
        public void SetAFilePathforANumber(string mychar, string path)
        {
            foreach (MySoundPlayer mysoundp in numberSounds)
            {
                if (mychar.ToString() == mysoundp.Charactor)
                {
                    mysoundp.FilePath = path;
                    break;
                }
            }
        }
        #endregion Set file path

        #region Add
        public void AddToVoices(string voicename, string path)
        {
            voices.Add(new MySoundPlayer(voicename, path));
        }
        public void AddToSymbols(string symbolname, string path)
        {
            symbols.Add(new MySoundPlayer(symbolname, path));
        }
        #endregion Add

        #region Play
        //plays the charactor or the number passed
        public bool playSound(string Charactor)
        {
            if (itsANumber(Charactor))
            {
                foreach (MySoundPlayer mysound in numberSounds)
                {
                    if (mysound.Charactor == Charactor)
                    {
                        mysound.Play();
                        return true;
                    }
                }
            }
            else
            {
                foreach (MySoundPlayer mysound in charactorSounds)
                {
                    if (mysound.Charactor.ToLower() == Charactor.ToLower())
                    {
                        mysound.Play();
                        return true;
                    }
                }
            }
            return false;

        }
        public bool playVoice(string voiceName)
        {
            foreach (MySoundPlayer mysound in voices)
            {
                if (voiceName.ToLower() == mysound.Charactor.ToLower())
                {
                    mysound.Play();
                    return true;
                }
            }
            return false;
        }
        public bool playSymbol(string symbolname)
        {
            foreach (MySoundPlayer mysound in symbols)
            {
                if (mysound.Charactor == symbolname.ToLower())
                {
                    mysound.Play();
                    return true;
                }
            }
            return false;
            
        }

        #endregion Play

        public bool itsANumber(string charactor)
        {
           
            int number;

            try
            {
                number = int.Parse(charactor);
                return true;
            }
            catch
            {
                return false;
            }
            

        }

        public string GetFullFilePath(string filename)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            return path;
        }

        

        //adds the pieces that make a sound
        //decides which hand and which finger
        public void PrepareToPlay1(string mychar)
        {
            
            
            //sentence[0] = getvoice("press");
            //one, charactor
            sentence[0] = GetCharactorSound(mychar);

            sentence[1] = getvoice("with Your");
            //three,  hand
           // sentence[2] = getvoice(Mykeyboardhelp.GetHand(mychar));//get hand 
            //four, finger
            sentence[3] = getvoice(Mykeyboardhelp.GetFinger(mychar));//getfinger

            //sentence[5] = getvoice("finger");


            
        }

        public void PrepareToPlay(string mychar, string prevkey)
        {


            sentence[0] = getvoice("press");
            //one, charactor
            sentence[1] = GetCharactorSound(mychar);

            sentence[2] = getvoice("with Your");
            //three,  hand
            sentence[3] = getvoice(Mykeyboardhelp.GetHand(mychar, prevkey));//get hand 
            //four, finger
            sentence[4] = getvoice(Mykeyboardhelp.GetFinger(mychar));//getfinger

            sentence[5] = getvoice("finger");



        }

        public void PrepareToPlayNum(string mychar)// not working
        {
            sentence[0] = getvoice("press");
            //one, charactor
            sentence[1] = GetCharactorSound(mychar);

            sentence[2] = getvoice("with Your");
            //three,  hand
            sentence[3] = getvoice("right");//get hand 
            //four, finger
            sentence[4] = getvoice(Mykeyboardhelp.GetNumFinger(mychar));//getfinger

            sentence[5] = getvoice("finger");
        }
        
        public MySoundPlayer getvoice(string voicename)
        {
            MySoundPlayer mycurrentsound = new MySoundPlayer();
            foreach (MySoundPlayer mysound in voices)
            {
                if (mysound.Charactor == voicename)
                {
                    mycurrentsound = mysound;
                    break;
                }
            }
            return mycurrentsound;
        }

        public MySoundPlayer getSymbol(string symbol)
        {
            MySoundPlayer mycurrentsymbol = new MySoundPlayer();

            foreach (MySoundPlayer mysound in symbols)
            {
                if (mysound.Charactor == symbol)
                {
                    mycurrentsymbol = mysound;
                    break;
                }

            }
            return mycurrentsymbol;
        }

        //returns the sound for the passed charactor
        public MySoundPlayer GetCharactorSound(string Charactor)
        {
            bool found = false;
            MySoundPlayer sound = new MySoundPlayer();
            if (itsANumber(Charactor))
            {
                foreach (MySoundPlayer mysound in numberSounds)
                {
                    if (mysound.Charactor == Charactor)
                    {
                        //mysound.Play();
                        sound = mysound;
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (MySoundPlayer mysound in charactorSounds)
                {
                    if (mysound.Charactor.ToLower() == Charactor.ToLower())
                    {
                        //mysound.Play();
                        sound = mysound;
                        found = true;
                        break;
                    }
                }
            }

            if(!(found))
            {
                sound = getSymbol(Charactor);
            }
            return sound;

        }


        //The method i will call from my interface
        //Plays the full sentence with hand and finger instructions
        public void Play(string Mykey, string prevkey)
        {
           

            PrepareToPlay(Mykey, prevkey);


            for (int m = 0; m < sentence.Length ; m++)
            {
                sentence[m].SoundLocation = sentence[m].FilePath;
                sentence[m].Play();

                
                Thread.Sleep(sleepDuration);

            }
            
        }
        public void PlayNum(string Mykey)
        {
            

            PrepareToPlayNum(Mykey);


            for (int m = 0; m < sentence.Length; m++)
            {
                sentence[m].SoundLocation = sentence[m].FilePath;
                sentence[m].Play();


                Thread.Sleep(sleepDuration);

            }

        }


        //plays on the passed charactor
        public void play(string mykey)
        {
            //PrepareToPlay(mykey);
            sentence[1].SoundLocation = sentence[1].FilePath;
            sentence[1].Play();
        }
        //event EventHandler myhandler;

        //returns true after a couple of seconds
        public bool wait()
        {
            DateTime start = new DateTime();
            start = DateTime.Now;
            DateTime end = new DateTime();
            TimeSpan a = new TimeSpan(0, 0, 0, 0, 1700);
            

            while (a.Milliseconds < 1700)
            {
                end = DateTime.Now;
                a = end - start;
                if (a.Milliseconds > 1700)
                {
                    return true;
                }
            }


            return true;

        }

               #endregion Methods

    }
}
