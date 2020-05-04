using System;
using System.Media;
using System.Threading.Tasks;

namespace Game
{
    class Audio
    {
        private static SoundPlayer player = new SoundPlayer(@"Images\audio1.wav");
        private static bool soundOn = true;
        public void Play()
        {
            if (soundOn)
                PlaySound();
            

        }
        private static void PlaySound()
        {
            Task.Run(() => {
                player.Play();
                soundOn = !soundOn;
            });
        }
    }
}
