using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> list = new();

            int heroCount = int.Parse(Console.ReadLine());

            while (list.Count < heroCount)
            {
                string HeroName = Console.ReadLine();
                string HeroType = Console.ReadLine();

                switch (HeroType)
                {
                    case "Druid":
                        list.Add(new Druid(HeroName));
                        break;
                    case "Paladin":
                        list.Add(new Paladin(HeroName));
                        break;
                    case "Rogue":
                        list.Add(new Rogue(HeroName));
                        break;
                    case "Warrior":
                        list.Add(new Warrior(HeroName));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            foreach (var hero in list)
            {
                Console.WriteLine($"{hero.CastAbility()}");
            }

            int result = list.Sum(h => h.Power);
            int bossPower = int.Parse(Console.ReadLine());

            Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}