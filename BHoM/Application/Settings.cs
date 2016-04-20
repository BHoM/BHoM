using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Application
{
    public enum LengthUnit
    {
        Millimetre,
        Centimetre,
        Metre,
        Kilometre,
        Inch, 
        Foot,
        Yard
    }

    public enum TimeUnit
    {
        Millisecond,
        Second,
        Minute,
        Hour
    }

    public enum TemperatureUnit
    {
        Celsius,
        Kelvin,
        Fahrenheit 
    }

    public class ApplicationSettings
    {
        public double Tolerance { get; set; }
        public LengthUnit Length { get; set; }
        public TimeUnit Time { get; set; }
        public TemperatureUnit Temperature { get; set; }
    }
}
