using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Typing_Tutor
{
    public class GameSounds
    {
        string errorSound = "Sound\\bubble\\error.wav";

        public string ErrorSound
        {
            get { return errorSound; }
            set { errorSound = value; }
        }
        string hitSound = "Sound\\bubble\\hit.wav";

        public string HitSound
        {
            get { return hitSound; }
            set { hitSound = value; }
        }
        string intorSound = "Sound\\bubble\\intro.wav";

        public string IntorSound
        {
            get { return intorSound; }
            set { intorSound = value; }
        }

        string dropSound = "Sound\\bubble\\drop.wav";

        string bombSound = "Sound\\bubble\\bomb.wav";

        SoundPlayer myplayer = new SoundPlayer();

        public GameSounds()
        {
        }
        public void playError()
        {
            play(errorSound);
        }
        public void playDrop()
        {
            play(dropSound);
        }
        public void playHit()
        {
            play(hitSound);
        }
        public void playIntro()
        {
            play(intorSound);
        }
        public void playbomb()
        {
            play(bombSound);
        }
        void play(string filename)
        {
            var file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            myplayer.SoundLocation = file;
            myplayer.Play();
        }
    }
}
