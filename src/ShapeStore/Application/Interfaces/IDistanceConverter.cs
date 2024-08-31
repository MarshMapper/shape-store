namespace ShapeStore.Application.Interfaces
{
    public enum DistanceUnit
    {
        Meter,
        Kilometer,
        Mile
    }
    public interface IDistanceConverter
    {
        DistanceUnit FromString(string unit);
        double Convert(double value, DistanceUnit from, DistanceUnit to);
    }
}
