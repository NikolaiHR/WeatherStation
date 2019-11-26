using System;

namespace ModelLib
{
    public class Forecast
    {
        private double _temp;
        private double _pressure;
        private double _humidity;

        public double Temp
        {
            get => _temp;
            set => _temp = value;
        }

        public double Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }

        public double Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }

        public Forecast()
        {
            
        }

        public Forecast(double temp, double pressure, double humidity)
        {
            _temp = temp;
            _pressure = pressure;
            _humidity = humidity;
        }

        public override string ToString()
        {
            return $"{nameof(Temp)}: {Temp}, {nameof(Pressure)}: {Pressure}, {nameof(Humidity)}: {Humidity}";
        }
    }
}
