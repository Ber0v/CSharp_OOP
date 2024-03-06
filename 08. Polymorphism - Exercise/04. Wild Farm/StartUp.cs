using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.BaseClasses;
using WildFarm.FoodTypes;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "End")
                    break;

                Animal animal = CreateAnimal(tokens);

                animals.Add(animal);

                Console.WriteLine(animal.AskForFood());

                string[] foodInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Food food = CreateFood(foodInfo);

                animal.Feed(food);
            }

            foreach (Animal animal in animals)
                Console.WriteLine(animal);
        }

        private static Animal CreateAnimal(string[] tokens)
        {
            string animalType = tokens[0];
            string animalName = tokens[1];

            double animalWeight = double.Parse(tokens[2]);

            string livingRegion = null;
            string breed = null;

            double wingSize = 0;

            Animal animal = null;

            if (animalType == "Cat" || animalType == "Tiger")
            {
                livingRegion = tokens[3];
                breed = tokens[4];

                if (animalType == "Cat")
                    animal = new Cat(animalName, animalWeight, livingRegion, breed);

                else if (animalType == "Tiger")
                    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
            }

            else if (animalType == "Owl" || animalType == "Hen")
            {
                wingSize = double.Parse(tokens[3]);

                if (animalType == "Owl")
                    animal = new Owl(animalName, animalWeight, wingSize);

                else if (animalType == "Hen")
                    animal = new Hen(animalName, animalWeight, wingSize);
            }

            else if (animalType == "Mouse" || animalType == "Dog")
            {
                livingRegion = tokens[3];

                if (animalType == "Mouse")
                    animal = new Mouse(animalName, animalWeight, livingRegion);

                else
                    animal = new Dog(animalName, animalWeight, livingRegion);
            }

            return animal;
        }

        private static Food CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];

            int foodQuantity = int.Parse(foodInfo[1]);

            Food food = null;

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;

                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;

                case "Meat":
                    food = new Meat(foodQuantity);
                    break;

                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
            }

            return food;
        }
    }
}
