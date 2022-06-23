using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class PopcornPopper
    {
        public void on()
        {
            Console.WriteLine("The popcornpopper is on.");
        }

        public void off()
        {
            Console.WriteLine("The popcornpopper is off.");
        }

        public void pop()
        {
            Console.WriteLine("The popcornpopper is making popcorn");
        }
    }

    public class Amplifier
    {
        public void on()
        {
            Console.WriteLine("The amplifaer is on for each device.");
        }

        public void off()
        {
            Console.WriteLine("The amplifaer is off.");
        }

        public void setVolume()
        {
            Console.WriteLine("The volume has been set.");
        }
    }

    public class Tuner
    {
        public void on()
        {
            Console.WriteLine("The tuner is on.");
        }

        public void off()
        {
            Console.WriteLine("The tuner is off.");
        }

        public void setAm()
        {
            Console.WriteLine("AM has been set.");
        }

        public void setFm()
        {
            Console.WriteLine("FM has been set.");
        }

        public void setFrequency()
        {
            Console.WriteLine("Frequency has been set.");
        }

    }

    public class SdPlayer
    {
        public void on()
        {
            Console.WriteLine("The SDplayer is on.");
        }

        public void off()
        {
            Console.WriteLine("The SDplayer is off.");
        }

        public void play()
        {
            Console.WriteLine("Music is playing.");
        }

        public void pause()
        {
            Console.WriteLine("Music stopped");
        }
    }

    public class Projector
    {
        public void on()
        {
            Console.WriteLine("The projector is on.");
        }

        public void off()
        {
            Console.WriteLine("The projector is off.");
        }
    }

    public class DvdPlayer
    {
        public void on()
        {
            Console.WriteLine("The DvDPlayer is on.");
        }

        public void off()
        {
            Console.WriteLine("The DvDPlayer is off.");
        }

        public void play()
        {
            Console.WriteLine("Something is playing");
        }

        public void pause()
        {
            Console.WriteLine("Something stopped");
        }

        public void setDvD()
        {
            Console.WriteLine("The DvD has been set");
        }

        public void ejectDvD()
        {
            Console.WriteLine("The DvD has been eject");
        }
    }

    public class HomeTheaterFacade
    {
        DvdPlayer dvd;
        SdPlayer sd;
        Projector proj;
        PopcornPopper popmachine;
        Amplifier ampl;
        Tuner tuner;

        public HomeTheaterFacade(DvdPlayer dvd, SdPlayer sd, Projector proj, PopcornPopper popmachine, Amplifier ampl, Tuner tuner)
        {
            this.dvd = dvd;
            this.sd = sd;
            this.proj = proj;
            this.popmachine = popmachine;
            this.ampl = ampl;
            this.tuner = tuner;
        }

        public void watchMovie()
        {
            ampl.on();
            dvd.on();
            proj.on();
            dvd.setDvD();
            ampl.setVolume();
            popmachine.on();
            popmachine.pop();
            popmachine.off();
            dvd.play();
        }

        public void endMovie()
        {
            dvd.ejectDvD();
            dvd.off();
            ampl.off();
            proj.off();
        }

        public void listenToSd()
        {
            ampl.on();
            sd.on();
            ampl.setVolume();
            sd.play();
        }

        public void endSd()
        {
            sd.off();
            ampl.off();
        }

        public void listenToRadio()
        {
            ampl.on();
            tuner.on();
            ampl.setVolume();
            tuner.setFm();
            tuner.setFrequency();
        }

        public void endRadio()
        {
            tuner.off();
            ampl.off();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            DvdPlayer dvd = new DvdPlayer();
            SdPlayer sd = new SdPlayer();
            Projector proj = new Projector();
            PopcornPopper popmachine = new PopcornPopper();
            Amplifier ampl = new Amplifier();
            Tuner tuner = new Tuner();
            HomeTheaterFacade facade = new HomeTheaterFacade(dvd, sd, proj, popmachine, ampl, tuner);
            facade.watchMovie();
            facade.endMovie();
            Console.ReadLine();
        }
    }
}