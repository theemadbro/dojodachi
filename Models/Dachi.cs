using System;
using System.Collections.Generic;
namespace dojodachi
{
    public class Dachi
    {
        public int fullness {get;set;}
        public int happiness {get;set;}
        public int meals {get;set;}
        public int energy {get;set;}
        public Dachi()
        {
            this.fullness = 20;
            this.happiness = 20;
            this.meals = 3;
            this.energy = 50;
        }
        public string feed()
        {
            if (this.meals >= 1)
            {
                this.meals--;
                Random rand = new Random();
                if (rand.Next(0,4)<1)
                {
                    return "Your DojoDachi didn't like that!";
                }
                int amt = rand.Next(5,11);
                this.fullness += amt;
                return $"You fed your DojoDachi! Meal -1, Fullness +{amt}";
            }
            else
            {
                return "You don't have any food!";            
            }
        }
        public string play()
        {
            if (this.energy <=0)
            {
                return "Your DojoDachi is too tired to play!";
            }
            this.energy -= 5;
            this.fullness -= 3;
            Random rand = new Random();
            if (rand.Next(0,4)<1)
            {
                return "Your DojoDachi didn't have any fun playing! Energy -5";
            }
            int amt = rand.Next(5,11);
            this.happiness += amt;
            return $"You played a game with your DojoDachi! Energy -5, Happiness +{amt}";
        }
        public string work()
        {
            if (this.energy <=0)
            {
                return "Your DojoDachi is too tired to work!";
            }
            this.energy -= 5;
            this.happiness -= 3;
            Random rand = new Random();
            int amt = rand.Next(1,4);
            this.meals += amt;
            return $"You worked with your DojoDachi! Energy -5, Happiness -5, Meals +{amt}";
        }
        
        public string sleep()
        {
            this.fullness -= 5;
            this.happiness -= 5;
            this.energy += 15;
            return "Nice sleep! Fullness -5, Happiness -5, Energy +15";
        }

        public void reset()
        {
            this.fullness = 20;
            this.happiness = 20;
            this.meals = 3;
            this.energy = 50;
        }
    }
    
}