using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x, y, GameEngine.GetEmptySymbol)
        {
            
        }
    }
}
