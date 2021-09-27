using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class GameEngine
    {
        private Map gameMap;
        public Map GetGameMap { get { return gameMap; } set { gameMap = value; } }

        private static char heroSymbol { get; } = 'H';
        private static char emptySymbol { get; } = 'E';
        private static char goblinSymbol { get; } = 'G';
        private static char obstacleSymbol { get; } = 'O';

        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies)
        {
            gameMap = new Map(minWidth, maxWidth, minHeight, maxHeight, numEnemies);
        }

        public void MovePlayer(Character.MovementEnum direction)
        {
            gameMap.GetHero.Move(gameMap.GetHero.ReturnMove(direction));


        }

        override
        public string ToString()
        {
            string st = "";
            Tile[,] fetchedMap = gameMap.GetMap;

            for (int i = 0; i < gameMap.GetHeight; i++)
            {
                for (int j = 0; j < gameMap.GetWidth; j++)
                {
                    st += fetchedMap[i, j] + " ";
                }
                st += "\n";
            }
            return st;
        }
    }
}
