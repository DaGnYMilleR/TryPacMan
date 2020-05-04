using System;
using System.Media;

namespace Game
{
    class Audio
    {
        private SoundPlayer player = new SoundPlayer();
        private bool soundOn;
        public Audio()
        {
            player.Stream = Image.audio1;
        }
        public void Play()
        {
            if (!soundOn)
                PlaySound();
            soundOn = !soundOn;

        }
        private static void PlaySound()
        {
            Task.Run(() => {
                player.Play();
            });
        }
    }
}
