using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public abstract class Character : Tile
    {
        protected int HP;
        public int GetHP { get { return HP; } set { HP = value; } }

        protected int maxHP;
        public int GetMaxHP { get { return maxHP; } set { maxHP = value; } }

        protected int damage;
        public int GetDamage { get { return damage; } set { damage = value; } }

        protected Tile[] vision = new Tile[4];
        public Tile[] GetVision { get { return vision; } set { vision = value; } }

        public enum MovementEnum { None, Up, Down, Left, Right}

        public Character(int inX, int inY, char inSymbol) : base(inX, inY, inSymbol)
        {

        }

        public virtual void Attack(Character target) {}

        public bool IsDead()
        {
            if (HP == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Character target)
        {
            double distanceX = Math.Abs(this.GetX - target.GetX);
            double distanceY = Math.Abs(this.GetY - target.GetY);

            int distance = Convert.ToInt32(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));

            return distance;
        }

        public void Move(MovementEnum move)
        {
            if (move != MovementEnum.None)
            {

                Map tempMap = Game.ge.GetGameMap;

                int heroX = tempMap.GetHero.GetX;
                int heroY = tempMap.GetHero.GetY;

                int destX = heroX;
                int destY = heroY;

                switch (move)
                {
                    case MovementEnum.Up:
                        destY--;
                        break;

                    case MovementEnum.Down:
                        destY++;
                        break;

                    case MovementEnum.Left:
                        destX--;
                        break;

                    case MovementEnum.Right:
                        destX++;
                        break;

                    default:
                        break;
                }

                tempMap.GetMap[destY, destX] = tempMap.GetMap[heroY, heroX];
                tempMap.GetMap[destY, destX].GetX = destX;
                tempMap.GetMap[destY, destX].GetY = destY;

                tempMap.GetMap[heroY, heroX] = new EmptyTile(heroY, heroX);
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum move);

        override
        public abstract string ToString();
    }
}
