public abstract class Vehicle
{
    public string Name { get; private set; }

    public Vehicle(string name)
    {
        Name = name;
    }

    public abstract void DisplayInfo();

    public abstract double CalculateSpeed(double distance); 
}
