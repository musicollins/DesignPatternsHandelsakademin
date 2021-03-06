using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            IMediaPlayer player = new MP3Format();
            IMediaPlayer player2 = new WAVFormat();
            player.play("Enter Sandman");
            player2.play("Sad But True");

            IMediaPlayer player3 = new FormatAdapter_IOC(new MKVFormat());
            IMediaPlayer player4 = new FormatAdapter_IOC(new AVIFormat());

            player3.play("The Shining");
            */
        }


    }
    public interface IMediaPlayer
    {
        void play(string name);
    }
    public class MP3Format : IMediaPlayer
    {
        public void play(string name)
        {
            Console.WriteLine($"MP3 Format playing => {name}.mp3");
        }
    }
    public class WAVFormat : IMediaPlayer
    {
        public void play(string name)
        {
            Console.WriteLine($"WAV Format playing => {name}.wav");
        }
    }
    public interface IUnsupportedFormat
    {
        void playVideo(string name);
    }
    public class MKVFormat : IUnsupportedFormat
    {
        public void playVideo(string name)
        {
            Console.WriteLine($"MKV Format playing => {name}.mkv");
        }
    }
    public class AVIFormat : IUnsupportedFormat
    {
        public void playVideo(string name)
        {
            Console.WriteLine($"AVI Format playing => {name}.avi");
        }
    }
    //Does not invert control. Instantiates dependency in constructor
    public class MKVFormatAdapter : IMediaPlayer
    {
        private MKVFormat mkvFormat;
        public MKVFormatAdapter()
        {
            mkvFormat = new MKVFormat();
        }
        public void play(string name)
        {
            mkvFormat.playVideo(name);
        }
    }
    public class MKVFormatAdapter_IOC : IMediaPlayer
    {
        private MKVFormat mkvFormat;
        public MKVFormatAdapter_IOC(MKVFormat mkvFormat)
        {
            this.mkvFormat = mkvFormat;
        }
        public void play(string name)
        {
            mkvFormat.playVideo(name);
        }
    }
    public class FormatAdapter_IOC : IMediaPlayer
    {
        private IUnsupportedFormat format;
        public FormatAdapter_IOC(IUnsupportedFormat format)
        {
            this.format = format;
        }
        public void play(string name)
        {
            format.playVideo(name);
        }
    }
}
