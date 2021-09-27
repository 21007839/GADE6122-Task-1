using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Obstacle : Tile
    {
        public Obstacle(int x, int y) : base(x, y, GameEngine.GetObstacleSymbol)
        {
            
        }
    }
}
