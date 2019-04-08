using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        public class Human
        {
            public string name;
            //The { get; set; } format creates accessor methods for the field specified
            //This is done to allow flexibility
            public int health { get; set; }
            static public int strength { get; set; }
            public int intelligence { get; set; }
            public int dexterity { get; set; }
            public Human(string person)
            {
                name = person;
                strength = 3;
                intelligence = 3;
                dexterity = 3;
                health = 100;
            }
            public Human(string person, int str, int intel, int dex, int hp)
            {
                name = person;
                strength = str;
                intelligence = intel;
                dexterity = dex;
                health = hp;
            }
            static public void attack(Human enemy)
            {
                
                if(enemy == null)
                {
                    Console.WriteLine("Failed Attack");
                }
                else
                {
                    enemy.health -= strength * 5;
                }
            }
        }
        public class Wizard : Human{
            public Wizard(string person) : base(person) {
                health = 50;
                intelligence = 25;
            }
            public Wizard Heal(){
                health += 10 * intelligence;
                return this;
            }         
            public Wizard FireBall(Human target){
                Random rand = new Random();                                                
                target.health-= rand.Next(20, 51);                                                
                return this;
            }
        }
        public class Ninja : Human {
            public Ninja(string person) : base(person) {
                dexterity = 175;                
            }
            public Ninja Steal(Human enemy) {
                Ninja.attack(enemy);
                health += 10;
                Console.WriteLine();
                return this;
            }
            public Ninja GetAway(){
                health -= 15;
                return this;                
            }                        
        }
        public class Samurai : Human {
            public Samurai(string person) : base(person){
                health = 200;
            }
            public Samurai Death_Blow(Human target){
                if(target.health<50){
                    target.health = 0;
                }
                return this;
            }
            public Samurai Meditate() {
                health = 200;
                return this;
            }
        }
        static void Main(string[] args)
        {
            Samurai tomSam = new Samurai("Tom");
            Ninja GenjiNinja = new Ninja("Genji");
            Console.WriteLine($"{GenjiNinja.name} has {GenjiNinja.health} health");
            GenjiNinja.Steal(tomSam);
            Console.WriteLine($"{GenjiNinja.name} has {GenjiNinja.health} health after Steal!");
            Console.WriteLine($"Samurai got hit and now health is {tomSam.health}");
        }
    }
}
