using System;
using System.Collections.Generic;


namespace SDEV248Midterm
{
    public abstract class Character
    {
        private List<string> attackTypes = new List<string>{ "MELEE", "BLOCK", "RANGED" };
        public int maxHP { protected set; get; }
        public int hp { protected set; get; }
        public int melee { protected set; get; }
        public int block { protected set; get; }
        public int ranged { protected set; get; }
        public bool alive { protected set; get; }
        protected List<Item> inventory;

        public Character()
        {
            //instantiate base character stats
            hp = 0;
            melee = 0;
            block = 0;
            ranged = 0;
            inventory = new List<Item>();
        }

        /// <summary>
        /// <para>Rolls a random number 1-10</para>
        /// <para>checks if the character won the rock/paper/scissors matchup</para>
        /// <para>    if they did, add the proper bonus</para>
        /// <para>returns int value of the attack</para>
        /// </summary>
        /// <param name="attackType">Should be "MELEE", "BLOCK" or "RANGED"</param>
        /// <param name="wonRPS"></param>
        /// <returns>int hit</returns>
        public int Attack(string attackType, bool wonRPS)
        {
            //if the attack doesn't exist, return 0
            if (!attackTypes.Contains(attackType.ToUpper()))
            {
                return 0;
            }

            //roll 1-10
            Random roll = new Random();
            int hit = roll.Next(1, 10);

            //if character won the RPS, add bonus
            if (wonRPS)
            {
                switch (attackType.ToUpper())
                {
                    case " MELEE":
                        hit += melee;
                        break;
                    case "BLOCK":
                        hit += block;
                        break;
                    case "RANGED":
                        hit += ranged;
                        break;
                    default:
                        Console.WriteLine("how did you get to this option?");
                        break;
                }
            }

            //return hit value
            return hit;
        }

        /// <summary>
        /// <para>Adjusts the character's HP</para>
        /// <para>If damage is negative, will heal the character</para>
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            hp -= damage;
        }
    }
}
