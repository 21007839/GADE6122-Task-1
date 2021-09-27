using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public abstract class Enemy : Character
    {
        protected Random rnd = new Random();
        public Random GetRnd { get { return GetRnd; } set { GetRnd = value; } }

        protected string enemyClass;

        public Enemy(int inX, int inY, int inHP, int inMaxHP, int inDamage, char inSymbol) : base(inX, inY, inSymbol)
        {
            HP = inHP;
            maxHP = inMaxHP;
            damage = inDamage;
            symbol = inSymbol;
        }

        public override string ToString()
        {
            return enemyClass + " at [" + GetX + ", " + GetY + "] (" + damage + ")";
        }
    }
}
