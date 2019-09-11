using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Hospital
    {
        public static void Main()
        {
            var hospitalInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            var roomsInfo = new Dictionary<string, Dictionary<int, List<string>>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }

                string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string department = inputTokens[0];
                string doctor = inputTokens[1] + " " + inputTokens[2];
                string patient = inputTokens[3];

                // spread inputTokens into the dictionaries
                if (hospitalInfo.ContainsKey(department))
                {
                    if (hospitalInfo[department].ContainsKey(doctor))
                    {
                        hospitalInfo[department][doctor].Add(patient);
                    }
                    else
                    {
                        hospitalInfo[department].Add(doctor, new List<string>() { patient });
                    }

                    int roomNumber = roomsInfo[department].Keys.Last();
                    if (roomsInfo[department][roomNumber].Count == 3)
                    {
                        roomNumber++;
                        roomsInfo[department].Add(roomNumber, new List<string>() { patient });
                    }
                    else
                    {
                        roomsInfo[department][roomNumber].Add(patient);
                    }
                }
                else
                {
                    hospitalInfo.Add(department, new Dictionary<string, List<string>>()
                    {
                        { doctor, new List<string>() { patient } }
                    });

                    roomsInfo.Add(department, new Dictionary<int, List<string>>()
                    {
                        {1, new List<string>() { patient } }
                    });
                }
            }

            // Read commands for printing
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string department = string.Empty;
                string doctor = string.Empty;
                int roomNumber;
                if (commandTokens.Length == 1)
                {
                    department = commandTokens[0];
                    foreach (var room in roomsInfo[department])
                    {
                        foreach (var patient in room.Value)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else
                {
                    if (int.TryParse(commandTokens[1], out roomNumber))
                    {
                        department = commandTokens[0];
                        roomsInfo[department][roomNumber]
                            .OrderBy(p => p)
                            .ToList()
                            .ForEach(p => Console.WriteLine(p));
                    }
                    else
                    {
                        doctor = command;
                        var doctorsPatients = new List<string>();
                        foreach (var dept in hospitalInfo.Keys)
                        {
                            if (hospitalInfo[dept].ContainsKey(doctor))
                            {
                                doctorsPatients.AddRange(hospitalInfo[dept][doctor]);
                            }
                        }

                        doctorsPatients
                            .OrderBy(p => p)
                            .ToList()
                            .ForEach(p => Console.WriteLine(p));
                    }
                }
            }
        }
    }
}
