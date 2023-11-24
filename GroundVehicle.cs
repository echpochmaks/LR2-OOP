using System;

public class GroundVehicle : Vehicle
{
    public double Speed { get; set; }
    public double TimeUntilRest { get; set; }
    public double StopDuration { get; set; }

    public GroundVehicle(string name, double speed, double restTime, double stopDuration)
        : base(name)
    {
        Speed = speed;
        TimeUntilRest = restTime;
        StopDuration = stopDuration;
    }

    public static GroundVehicle BootsOfTravel()
    {
        return new GroundVehicle("Сапоги-скороходы", 15, 15, 10);
    }

    public static GroundVehicle PumpkinCarriage()
    {
        return new GroundVehicle("Карета-Тыква", 5, 150, 5);
    }

    public static GroundVehicle ChickenLegsHut()
    {
        return new GroundVehicle("Избушка на курьих ножках", 10, 25, 7);
    }

    public static GroundVehicle Centaur()
    {
        return new GroundVehicle("Кентавр", 5, 40, 8);
    }

    public override double CalculateSpeed(double distance)
{
    // Расчет количества остановок
    int numStops = (int)(distance / (Speed * TimeUntilRest));

    // Проверка, совпадает ли последняя остановка с пунктом назначения
    if (distance % (Speed * TimeUntilRest) == 0)
    {
        // Если совпадает, уменьшаем количество остановок
        numStops--;
    }

    // Расчет общего времени движения
    double totalTime = numStops * StopDuration + distance / Speed;

    return distance / totalTime;
}



    public override void DisplayInfo()
    {
        Console.WriteLine($"Наземное ТС: {Name}, Скорость: {Speed}, Время движения: {TimeUntilRest}, Время остановки: {StopDuration}");
    }
}
