using ShapeStore.Application.Interfaces;

namespace ShapeStore.Application.Services
{
    // Distance converter service
    public class DistanceConverter : IDistanceConverter
    {
        public const double MetersInKilometer = 1000;
        public const double MetersInMile = 1609.34;
        public const double KilometersInMile = 1.60934;

        public DistanceConverter()
        {
        }
        public DistanceUnit FromString(string unit)
        {
            return unit.ToLower() switch
            {
                "m" => DistanceUnit.Meter,
                "km" => DistanceUnit.Kilometer,
                "mi" => DistanceUnit.Mile,
                _ => DistanceUnit.Meter
            };
        }
        // Convert the value from one unit to another
        public double Convert(double value, DistanceUnit from, DistanceUnit to)
        {
            // Convert the value from one unit to another
            return from switch
            {
                DistanceUnit.Meter => (to) switch
                {
                    DistanceUnit.Meter => value,
                    DistanceUnit.Kilometer => value / MetersInKilometer,
                    DistanceUnit.Mile => value / MetersInMile,
                    _ => value
                },
                DistanceUnit.Kilometer => (to) switch
                {
                    DistanceUnit.Meter => value * MetersInKilometer,
                    DistanceUnit.Kilometer => value,
                    DistanceUnit.Mile => value / KilometersInMile,
                    _ => value
                },

                DistanceUnit.Mile => (to) switch
                {
                    DistanceUnit.Meter => value * MetersInMile,
                    DistanceUnit.Kilometer => value * KilometersInMile,
                    DistanceUnit.Mile => value,
                    _ => value
                },
                _ => value
            };
        }
    }
}
