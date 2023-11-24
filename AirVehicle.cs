public class AirVehicle : Vehicle
{
    public double Speed { get; set; }
    public Func<double, double> AccelerationFormula { get; set; }
    public int ParticipantsCount { get; set; }

    public double Acceleration => AccelerationFormula?.Invoke(ParticipantsCount) ?? 0;

    public AirVehicle(string name, double speed, Func<double, double> accelerationFormula, int participantsCount)
        : base(name)
    {
        Speed = speed;
        AccelerationFormula = accelerationFormula;
        ParticipantsCount = participantsCount;
    }

    public static AirVehicle BabaYaga(int participantsCount)
    {
        return new AirVehicle("Ступа Бабы Яги", 10, _ => participantsCount * 1.5 , participantsCount);
    }


    public static AirVehicle Broom()
    {
        return new AirVehicle("Метла", 1, distance => Math.Sqrt(distance), 0);
    }

    public static AirVehicle FlyingShip()
    {
        return new AirVehicle("Летучий корабль", 10, distance => distance * 0.03, 0);
    }

    public static AirVehicle Carpet()
    {
        return new AirVehicle("Ковер-самолет", 10, distance => Math.Log(distance + 1, 2) * 2, 0);
    }

    public double CalculateTotalSpeed(int distance)
    {
        return Speed + AccelerationFormula(distance);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Воздушное ТС: {Name}, Начальная скорость: {Speed}, Ускорение: {AccelerationFormula}");
    }

    public override double CalculateSpeed(double distance)
    {
        return Speed + AccelerationFormula(distance);
    }
}