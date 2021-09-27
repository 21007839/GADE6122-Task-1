using System;
using System.Collections.Generic;
using System.Text;

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

        public virtual void Attack(Character target)
        {
            
        }

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

        /*public virtual bool CheckRange(Character target)
        {

        }*/

        /*private int DistanceTo(Character target)
        {

        }*/

        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    y--;
                    break;

                case MovementEnum.Down:
                    y++;
                    break;

                case MovementEnum.Left:
                    x--;
                    break;

                case MovementEnum.Right:
                    x++;
                    break;
                    
                default:
                    break;
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum move);

        override
        public abstract string ToString();
    }
}
