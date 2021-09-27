using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Hero : Character
    {
        protected static int heroMaxHP = 10;
        public static int GetHeroMaxHP { get { return heroMaxHP; } set { heroMaxHP = value; } }

        protected static int heroHP = heroMaxHP;
        public static int GetHeroHP { get { return heroHP; } set { heroHP = value; } }

        protected static int heroDamage = 2;
        public static int GetHeroDamage { get { return heroDamage; } set { heroDamage = value; } }

        protected static char heroSymbol = 'H';
        public static char GetHeroSymbol { get { return heroSymbol; } set { heroSymbol = value; } }

        public Hero(int inX, int inY) : base(inX, inY, heroSymbol)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    if (vision[0].GetSymbol != ' ')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol != ' ')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Left:
                    if (vision[3].GetSymbol != ' ')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol != ' ')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                default:
                    return MovementEnum.None;
            }
        }

        public override string ToString()
        {
            if (heroHP == heroMaxHP)
            {
                return "Player Stats:\n" +
                   "HP: " + heroMaxHP + "\n" +
                   "Damage: " + heroDamage + "\n" +
                   "[" + x + ", " + y + "]";
            }
            else
            {
                return "Player Stats:\n" +
                   "HP: " + heroHP + "\n" +
                   "Damage: " + heroDamage + "\n" +
                   "[" + x + ", " + y + "]";
            }
        }
    }
}
