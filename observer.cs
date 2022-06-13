using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    interface Observer
    {
        void update(float temp, float humidity, float pressuare);
    }
    interface DisplayElement
    {
        void display();
    }
    interface Subject
    {
        void addObserver(Observer o);
        void removeObserver(Observer o);
        void notifyObservers();

    }

    class WeatherData : Subject
    {
        List<Observer> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void addObserver(Observer o)
        {
            observers.Add(o);
        }
        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(o);
            }
        }//????
        public void notifyObservers()
        {
            for (int i = 0; i < observers.Count(); ++i)
            {
                Observer observer = observers[i];
                observer.update(temperature, humidity, pressure);
            }
        }

        public void measurementsChanged()
        {
            notifyObservers();
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }

    class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private float pressure;
        private Subject weatherData;

        public CurrentConditionsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.addObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees and " + humidity +
                "% humidity and " + pressure + " pressure");
        }
    }

    class StatisticsDisplay : Observer, DisplayElement
    {
        private float temperature;
        Subject weatherData;

        public StatisticsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.addObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature);
        }

    }

    class ForecastDisplay: Observer, DisplayElement
    {
        private float humidity;
        Subject weatherData;

        public ForecastDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.addObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine("humidity: " + humidity);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentDisplay = 
                new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = 
                new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = 
                new ForecastDisplay(weatherData);
            weatherData.setMeasurements(80, 62, 30); 
            weatherData.setMeasurements(40, 13, 93);
            Console.Read();
        }
    }
}
