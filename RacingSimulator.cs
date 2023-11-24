using System;

public enum RaceType
{
    GroundOnly,
    AirOnly,
    All
}


public class RacingSimulator
{   
    private int participantsCount;
    private string[] selectedParticipants;

    public enum RaceType
    {
        GroundOnly,
        AirOnly,
        All
    }
    
    public void RunSimulation()
    {
        GroundVehicle stupa = GroundVehicle.BootsOfTravel();
        GroundVehicle carriage = GroundVehicle.PumpkinCarriage();
        GroundVehicle chickenLegsHut = GroundVehicle.ChickenLegsHut();
        GroundVehicle centaur = GroundVehicle.Centaur();
        AirVehicle airship = AirVehicle.FlyingShip();
        AirVehicle babaYaga = AirVehicle.BabaYaga(0);
        AirVehicle broom = AirVehicle.Broom();
        AirVehicle carpet = AirVehicle.Carpet();

        DisplayVehicleInfo(stupa);
        DisplayVehicleInfo(carriage);
        DisplayVehicleInfo(chickenLegsHut);
        DisplayVehicleInfo(centaur);
        DisplayVehicleInfo(airship);
        DisplayVehicleInfo(babaYaga);
        DisplayVehicleInfo(broom);
        DisplayVehicleInfo(carpet);

        Console.WriteLine("\nСоздаем гонку:");
        Race race = CreateRace();
        if (race != null)
        {
            race.RunRace();
        }
    }

    private void DisplayVehicleInfo(Vehicle vehicle)
    {
        vehicle.DisplayInfo();
    }

    private Race CreateRace()
    {
        RaceType raceType;
        participantsCount = 0;

        do
        {
            Console.WriteLine("Выберите тип гонки:");
            Console.WriteLine("1. Наземная");
            Console.WriteLine("2. Воздушная");
            Console.WriteLine("3. Все");

            int raceTypeChoice;
            if (!int.TryParse(Console.ReadLine(), out raceTypeChoice))
            {
                Console.WriteLine("Неверный выбор типа гонки.");
                continue;
            }

            switch (raceTypeChoice)
            {
                case 1:
                    raceType = RaceType.GroundOnly;
                    break;
                case 2:
                    raceType = RaceType.AirOnly;
                    break;
                case 3:
                    raceType = RaceType.All;
                    break;
                default:
                    Console.WriteLine("Неверный выбор типа гонки. Введите число от 1 до 3.");
                    continue;
            }
            break;

        } while (true);

        Console.Write("Введите дистанцию гонки: ");
        double distance = double.Parse(Console.ReadLine());

        Race race = new Race(distance, raceType);

        Console.WriteLine("Выберите участников гонки:");
        Console.WriteLine("1. Сапоги-скороходы");
        Console.WriteLine("2. Карета-тыква");
        Console.WriteLine("3. Избушка на курьих ножках");
        Console.WriteLine("4. Кентавр");
        Console.WriteLine("5. Летучий корабль");
        Console.WriteLine("6. Ступа Бабы Яги");
        Console.WriteLine("7. Метла");
        Console.WriteLine("8. Ковер-самолет");

        do
        {
            Console.Write("Введите номера участников через запятую: ");
            selectedParticipants = Console.ReadLine().Split(',');

            participantsCount = selectedParticipants.Length;

            bool hasError = false;

            foreach (var selectedParticipant in selectedParticipants)
            {
                int participantNumber;
                if (!int.TryParse(selectedParticipant.Trim(), out participantNumber))
                {
                    Console.WriteLine($"Неверный номер участника: {selectedParticipant}");
                    hasError = true;
                    break;
                }

                if (!IsParticipantValidForRace(raceType, participantNumber))
                {
                    hasError = true;
                    break;
                }

                AddParticipantToRace(race, participantNumber);
            }

            if (!hasError && race.Participants.Any())
            {
                break;
            }
            else if (hasError)
            {
                Console.WriteLine("Повторите ввод участников.");
            }
            else
            {
                Console.WriteLine("Гонка не может начаться без участников.");
            }

        } while (true);

        return race;
    }

    private bool IsParticipantValidForRace(RaceType raceType, int participantNumber)
    {
        if (participantNumber < 1 || participantNumber > 8)
        {
            Console.WriteLine($"Неверный номер участника: {participantNumber}");
            return false;
        }

        if ((raceType == RaceType.GroundOnly) && (participantNumber == 5 || participantNumber == 6 || participantNumber == 7 || participantNumber == 8))
        {
            Console.WriteLine("Ошибка: Воздушные транспортные средства не разрешены на наземной гонке.");
            return false;
        }

        if ((raceType == RaceType.AirOnly) && (participantNumber == 1 || participantNumber == 2 || participantNumber == 3 || participantNumber == 4))
        {
            Console.WriteLine("Ошибка: Наземные транспортные средства не разрешены на воздушной гонке.");
            return false;
        }

        return true;
    }


    private void AddParticipantToRace(Race race, int participantNumber)
    {
        if (participantNumber < 1 || participantNumber > 8)
        {
            Console.WriteLine($"Неверный номер участника: {participantNumber}");
            return;
        }

        switch (participantNumber)
        {
            case 1:
                race.AddParticipant(GroundVehicle.BootsOfTravel());
                break;
            case 2:
                race.AddParticipant(GroundVehicle.PumpkinCarriage());
                break;
            case 3:
                race.AddParticipant(GroundVehicle.ChickenLegsHut());
                break;
            case 4:
                race.AddParticipant(GroundVehicle.Centaur());
                break;
            case 5:
                int participantsCount = selectedParticipants.Length;
                race.AddParticipant(AirVehicle.BabaYaga(participantsCount));
                break;
            case 6:
                race.AddParticipant(AirVehicle.FlyingShip());
                break;
            case 7:
                race.AddParticipant(AirVehicle.Broom());
                break;
            case 8:
                race.AddParticipant(AirVehicle.Carpet());
                break;
            default:
                Console.WriteLine($"Неверный номер участника: {participantNumber}");
                break;
        }
    }
}