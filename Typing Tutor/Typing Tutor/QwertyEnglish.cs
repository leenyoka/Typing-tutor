using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typing_Tutor
{
    public class QwertyEnglish
    {
        #region keys
        //Right hand keys
        //Right index finger keys
        string[] rightIndex = new string[10] { "7", "y", "u", "j", "h", "m", "n", "&",  "^", "6" };

        //Right middle finger keys
        string[] rightMiddle = new string[6] { "8", "*", "i", "k", ",", "<" };

        //Right ring finger keys
        string[] rightRing = new string[6] {"9", "(", "o", "l", ".", ">" };

        //Right pinkie finger keys
        string[] rightPinkie = new string[21]{")", "0", "_", "-", "+", "=", "p", "[", "{", "}", "]",
           ":", ";", "\"","'", "\\", "|", "?", "/", "Shift", "BackSpace"};

        string[] rightPinkie1 = new string[21]{")", "0", "_", "-", "+", "=", "p", "[", "{", "}", "]",
           ":", ";", "\"","'", "\\", "|", "?", "/", "shiftright", "backspace"};   


        //Left hand keys
        //Left index finger keys
        string[] leftIndex = new string[10] {"$", "4", "%", "5", "t", "r", "g", "f", "v", "b"};

        //Left middle finger keys
        string[] leftMiddle = new string[5] { "3", "#", "e", "d", "c" };

        //Left ring finger keys
        string[] leftRing = new string[5] { "2", "@", "w", "s", "x" };

        //Left pinkie finger keys
        string[] leftPinkie = new string[11] { "q", "a", "z", "Tab", "Capslock", "Shift", "1", "lock", "`", "~", "!" };

        string[] leftPinkie1 = new string[7] { "q", "a", "z" , "1", "`", "!", "shiftleft"};
        #endregion keys

        #region Num Keys

        string[] numPinkie = new string[2] { "-", "+" };

        string[] numMiddle = new string[4] { "2", "5", "8", "/" };

        string[] numRing = new string[5] { "3", "6", "9", "*" , "."};

        string[] numIndex = new string[3] {"1", "4", "7" };

        string[] numThumb = new string[1] { "0" };

        #endregion Num keys

        #region Rows

        string[] thirdrow = new string[] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[",
            "{", "]", "}"};

        string [] homerow =new string[] { "a", "s", "d", "f", "g", "h", "i", "j", "k", "l", ";", ":", 
        "\"", "'"};

        string[] firstrow = new string[] {"z", "x", "c", "v", "b", "n", "m", ",", ".",
            "?", "/",};


        #endregion Rows

        #region Left keys
        string[] leftkeys = new string[] { "q", "w", "e", "r", "t", "a", "s", "d", "f"
            , "g", "z", "x", "c", "v", "b", "1", "!", "2", "@", "#", "3", "4", "$", "%", "5",
            "^", "6"};
        #endregion Left Keys

        #region Right Keys
        string[] rightkeys = new string[]{"y", "u", "u", "i", "o", "p", "j", "k", "l", ";", "'",
            "\"", "[", "{", "}", "]", "7", "*", "&", "8", "(", "9", ")", "0", "-", "_", "=", "+",
            "n", "m", ",", ".", "<", "<", "?", "/"};
        #endregion Right keys


        //constructor
        public QwertyEnglish()
        {

        }

        //methods
        #region Get Key instructions

        public string GetInstructions(string Key)//Checks what finger is used for the key
        {
            string key = Key.ToLower();
            string instructions = string.Empty;

            
            //right hand
            if (keyIsIn(key, rightIndex))
            {
                instructions = "Right Index Finger";
            }
            else if (keyIsIn(key, rightMiddle))
            {
                instructions = "Right Middle Finger";
            }
            else if (keyIsIn(key, rightRing))
            {
                instructions = "Right Ring Finger";
            }
            else if (keyIsIn(key, rightPinkie))
            {
                instructions = "Right Pinkie";
            }
            //left hand
            else if (keyIsIn(key, leftIndex))
            {
                instructions = "Left Index Finger";
            }
            else if (keyIsIn(key, leftMiddle))
            {
                instructions = "Left Middle Finger";
            }
            else if (keyIsIn(key, leftRing))
            {
                instructions = "Left Ring Finger";
            }
            else if (keyIsIn(key, leftPinkie))
            {
                instructions = "Left Pinkie";
            }
            else if ((string)key == " ")
            {
                instructions = "thumb";
            }
            else
            {
                instructions = "No instructions for the key";
            }

            return instructions;
        }

        public string GetInstructions2(string Key)
        {
            string key = Key.ToLower();
            string instructions = string.Empty;

            //Checks what finger is used for the key
            //right hand
            if (keyIsIn(key, rightIndex))
            {
                instructions = "rightIndex";
            }
            else if (keyIsIn(key, rightMiddle))
            {
                instructions = "rightMiddle";
            }
            else if (keyIsIn(key, rightRing))
            {
                instructions = "rightRing";
            }
            else if (keyIsIn(key, rightPinkie))
            {
                instructions = "rightPinkie";
            }
            //left hand
            else if (keyIsIn(key, leftIndex))
            {
                instructions = "leftIndex";
            }
            else if (keyIsIn(key, leftMiddle))
            {
                instructions = "leftMiddle";
            }
            else if (keyIsIn(key, leftRing))
            {
                instructions = "leftRing";
            }
            else if (keyIsIn(key, leftPinkie))
            {
                instructions = "leftPinkie";
            }
            else if ((string)key == " ")
            {
                instructions = "space";
            }
            else
            {
                instructions = "No instructions for the key";
            }

            return instructions;
        }

        #endregion Get Key instructions

        #region KeyIsIn
        //check if a key is in the array
        public bool keyIsIn(string key, string[] array)
        {
            bool isIn = false;

            foreach (string value in array)
            {
                if (key == value)
                {
                    isIn = true;
                    break;
                }
            }
            return isIn;
        }
        #endregion KeyIsIn

        public string thisSpacethumb(string lastPress)
        {

            if (!keyIsIn(lastPress, rightkeys))
            {
                return "right";
            }
            else
            {
                return "left";
            }

            #region Wrong

            //if (!((keyIsIn(lastPress, rightIndex)) && (keyIsIn(lastPress, rightMiddle)) &&
            //    (keyIsIn(lastPress, rightRing)) && (keyIsIn(lastPress, rightPinkie))))
            //{
            //    lastpressusedright = false;
            //}

            //if (lastpressusedleft)
            //{
            //    return "right";
            //}
            //if (lastpressusedright)
            //{
            //    return "left";
            //}
            //return " ";
            #endregion wrong
        }

        public string GetFinger(string Key)
        {
            string key = Key.ToLower();
            string instructions = string.Empty;

            //Checks what finger is used for the key
            //right hand
            if (keyIsIn(key, rightIndex))
            {
                instructions = "index";
            }
            else if (keyIsIn(key, rightMiddle))
            {
                instructions = "middle";
            }
            else if (keyIsIn(key, rightRing))
            {
                instructions = "ring";
            }
            else if (keyIsIn(key, rightPinkie))
            {
                instructions = "pinkie";
            }
            //left hand
            else if (keyIsIn(key, leftIndex))
            {
                instructions = "index";
            }
            else if (keyIsIn(key, leftMiddle))
            {
                instructions = "middle";
            }
            else if (keyIsIn(key, leftRing))
            {
                instructions = "ring";
            }
            else if (keyIsIn(key, leftPinkie))
            {
                instructions = "pinkie";
            }
            else if ((string)key == " ")
            {
                instructions = "thumb";
            }
            else
            {
                instructions = "thumb";
            }

            return instructions;
        }

        public string GetHand(string Key, string prevkey)
        {
            string key = Key.ToLower();
            string instructions = string.Empty;

            //Checks what finger is used for the key
            //right hand
            if (keyIsIn(key, rightIndex))
            {
                instructions = "right";
            }
            else if (keyIsIn(key, rightMiddle))
            {
                instructions = "right";
            }
            else if (keyIsIn(key, rightRing))
            {
                instructions = "right";
            }
            else if (keyIsIn(key, rightPinkie))
            {
                instructions = "right";
            }
            //left hand
            else if (keyIsIn(key, leftIndex))
            {
                instructions = "left";
            }
            else if (keyIsIn(key, leftMiddle))
            {
                instructions = "left";
            }
            else if (keyIsIn(key, leftRing))
            {
                instructions = "left";
            }
            else if (keyIsIn(key, leftPinkie))
            {
                instructions = "left";
            }
            else if ((string)key == " ")
            {
                //instructions = "left";

                //return "left";

               return thisSpacethumb(prevkey);

                //still have to think about this one
            }
            else
            {
                instructions = "right";
            }

            return instructions;
        }

        

        public string GetNumFinger(string key)
        {
            if (keyIsIn(key.ToLower(), numPinkie))
            {
                return "pinkie";
            }
            else if (keyIsIn(key.ToLower(), numRing))
            {
                return "ring";
            }
            else if (keyIsIn(key.ToLower(), numMiddle))
            {
                return "middle";
            }
            else if (keyIsIn(key.ToLower(), numIndex))
            {
                return "index";
            }
            else if (keyIsIn(key.ToLower(), numThumb))
            {
                return "thumb";
            }
            return "";
        }

        public string getrow(string mychar)
        {
            if(keyIsIn(mychar, homerow))
            {
                return "Home Row";
            
            }
            else if(keyIsIn(mychar, firstrow))
            {
                return "First Row";
            }
            else if (keyIsIn(mychar, thirdrow))
            {
                return "Third Row";
            }
            else
            {
                return "Fourth Row";
            }

            


        }
        public string getthumb(string prevkey)
        {
            if (keyIsIn(prevkey, leftkeys))
            {
                return "right";
            }
            else
            {
                return "left";
            }
        }


        public string[] getKeys(string finger, string hand)
        {
            if (hand.ToLower() == "right")
            {
                return getRightHandFingerkeys(finger);
            }
            else
            {
                return getLeftHandFinerkey(finger);
            }
        }
        public string[] getRightHandFingerkeys(string finger)
        {
            if (finger.ToLower() == "pinkie")
            {
                return rightPinkie1;
            }
            else if (finger.ToLower() == "ring")
            {
                return rightRing;
            }
            else if (finger.ToLower() == "middle")
            {
                return rightMiddle;
            }
            else if (finger.ToLower() == "index")
            {
                return rightIndex;
            }
            else
            {
                //thumb
                return new string[1] { " " };
            }
        }

        public string[] getLeftHandFinerkey(string finger)
        {
            if (finger.ToLower() == "pinkie")
            {
                return leftPinkie;
            }
            else if (finger.ToLower() == "ring")
            {
                return leftRing;
            }
            else if (finger.ToLower() == "middle")
            {
                return leftMiddle;
            }
            else if (finger.ToLower() == "index")
            {
                return leftIndex;
            }
            else
            {
                return new string[1] { " " };
                //thumb
            }
        }

    }
}
