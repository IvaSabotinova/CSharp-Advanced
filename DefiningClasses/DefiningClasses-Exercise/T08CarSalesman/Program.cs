using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numOfEngines = int.Parse(Console.ReadLine());

            List<Engine> allEngines = new List<Engine>();

            for (int i = 0; i < numOfEngines; i++)
            {
                string[] inputEngines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currEngineModel = inputEngines[0];
                int currEnginePower = int.Parse(inputEngines[1]);

                Engine currEngine = new Engine(currEngineModel, currEnginePower);

                if (inputEngines.Length == 3)
                {
                    string displacementOrEfficiency = inputEngines[2];
                    if (int.TryParse(displacementOrEfficiency, out int displacement))
                    {
                        currEngine = new Engine(currEngineModel, currEnginePower, displacement);
                    }
                    else
                    {
                        currEngine = new Engine(currEngineModel, currEnginePower, displacementOrEfficiency);
                    }
                    
                }
                else if (inputEngines.Length == 4)
                {
                    int currDisplacement = int.Parse(inputEngines[2]);
                    string currEfficiency = inputEngines[3];
                    currEngine = new Engine(currEngineModel, currEnginePower, currDisplacement, currEfficiency);

                }
                allEngines.Add(currEngine);
            }

            List<Car> allCars = new List<Car>();

            int numOfCar = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCar; i++)
            {
                string[] inputCars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCarModel = inputCars[0];
                string currCarEngineModel = inputCars[1];

                Engine currEngine = allEngines.Where(x => x.EngineModel == currCarEngineModel).FirstOrDefault();

                Car currCar = new Car(currCarModel, currEngine);

                if (inputCars.Length == 3)
                {
                    string weightOrColor = inputCars[2];
                    if (int.TryParse(weightOrColor, out int weight))
                    {
                        currCar = new Car(currCarModel, currEngine, weight);
                    }
                    else
                    {
                        currCar = new Car(currCarModel, currEngine, weightOrColor);
                    }

                }
                else if (inputCars.Length == 4)
                {
                    int currCarWeight = int.Parse(inputCars[2]);
                    string currCarColor = inputCars[3];
                    currCar = new Car(currCarModel, currEngine, currCarWeight, currCarColor);
                }
                allCars.Add(currCar);
            }

            foreach (Car car in allCars)
            {
                Console.WriteLine(car.ToString());

            }
        }
    }
}
