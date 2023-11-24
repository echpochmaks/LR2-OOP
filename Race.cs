using System;
using System.Collections.Generic;
using System.Linq;

public class Race
{
    private List<Vehicle> participants;

    // Добавлено свойство Participants
    public List<Vehicle> Participants
    {
        get { return participants; }
    }

    public double Distance { get; private set; }
    public RacingSimulator.RaceType Type { get; private set; }

    public Race(double distance, RacingSimulator.RaceType type)
    {
        Distance = distance;
        Type = type;
        participants = new List<Vehicle>();
    }

    public void AddParticipant(Vehicle vehicle)
    {
        participants.Add(vehicle);
    }

    public void RunRace()
    {
        Console.WriteLine($"Гонка на дистанции {Distance} началась!");
        Console.WriteLine("Участвуют следующие ТС:");

        foreach (var participant in participants)
        {
            Console.WriteLine($"- {participant.Name}");
        }

        Console.WriteLine("\nРезультаты гонки:");

        foreach (var participant in participants)
        {
            double time = CalculateTime(participant);
            Console.WriteLine($"{participant.Name}: Время - {time:F2}");
        }

        Vehicle winner = FindWinner();
        Console.WriteLine($"\n{winner.Name} - Победитель гонки!");
    }

    private double CalculateTime(Vehicle vehicle)
    {
        return Distance / vehicle.CalculateSpeed(Distance);
    }

    private Vehicle FindWinner()
    {
        return participants.OrderBy(p => CalculateTime(p)).First();
    }
}
