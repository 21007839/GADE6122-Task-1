using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Goblin : Enemy
    {
        private static int enemyMaxHP = 10;

        private static int enemyDamage = 1;

        private static char enemySymbol = 'G';

        public Goblin(int inX, int inY) : base(inX, inY, enemyMaxHP, enemyMaxHP, enemyDamage, enemySymbol)
        {
            
        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            int direction = rnd.Next(1, 5);

            switch (direction)
            {
                case 1:
                    return MovementEnum.Up;

                case 2:
                    return MovementEnum.Down;

                case 3:
                    return MovementEnum.Left;

                case 4:
                    return MovementEnum.Right;

                default:
                    return MovementEnum.None;
            }
        }
    }
}
