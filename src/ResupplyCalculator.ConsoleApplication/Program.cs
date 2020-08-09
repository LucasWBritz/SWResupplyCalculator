using ResupplyCalculator.Enums;
using ResupplyCalculator.Helpers;
using System;
using System.Linq;

namespace ResupplyCalculator.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ResupplyCalculatorService service = new ResupplyCalculatorService();
            Console.WriteLine("Downloading starships data from https://swapi.dev/api/starships. Please wait");
            
            service.LoadShips().Wait();
            Console.Clear();            
            bool exit = false;
                        
            // We will start reading the distance and ensure that the value inputed is a valid integer. 
            do
            {
                Console.WriteLine("Welcome to the starship resupply calculator app.");
                Console.WriteLine("To start, please inform the distance in MGLT:");
                Console.Write(":> ");
                var input = Console.ReadLine();

                if (input.ConvertToValidInteger(out long distance))
                {
                    bool exitOrderBy = true;
                    // We will ask for the ordenation. Will keep running the loop until the user inserts a valid option.
                    do
                    {
                        Console.WriteLine($"Great! We will compute the distance for each of the {service.Ships.Count} starships.");
                        Console.WriteLine("Would you like to get the results ordered by:");
                        Console.WriteLine(" 1 - Name ");
                        Console.WriteLine(" 2 - Number of Stops");
                        Console.Write(":> ");
                        var optInput = Console.ReadLine();

                        if(optInput.ConvertToValidInteger(out long optOrdenation))
                        {
                            Ordenation order = (Ordenation)optOrdenation;
                            if(Enum.IsDefined(typeof(Ordenation), order))
                            {
                                var results = service.CalculateResupplyStops(distance, order);

                                int maxNameLenght = results.Max(x => x.SpaceshipName.Length);
                                string header = "Name".PadRight(maxNameLenght, ' ') + "|| Total number of stops";
                                Console.WriteLine("".PadRight(header.Length, '_'));
                                Console.WriteLine(header);
                                foreach (var ship in results)
                                {
                                    Console.WriteLine($"{ship.SpaceshipName.PadRight(maxNameLenght, '.')}:> {(ship.NumberOfStops.HasValue ? ship.NumberOfStops.ToString() : "unknown")}");                                    
                                }
                                Console.WriteLine("".PadRight(header.Length, '_'));
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Please inform a valid option.");
                                Console.ReadKey();
                                Console.Clear();

                                exitOrderBy = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please inform a valid option.");
                            Console.ReadKey();
                            Console.Clear();

                            exitOrderBy = false;
                        }
                    } while (!exitOrderBy);                    
                }
                else
                {
                    Console.WriteLine("Please insert a valid distance.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (!exit);
        }        
    }
}
