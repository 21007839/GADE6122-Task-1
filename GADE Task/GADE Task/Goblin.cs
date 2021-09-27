using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Goblin : Enemy
    {

        public Goblin(int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetGoblinSymbol)
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
