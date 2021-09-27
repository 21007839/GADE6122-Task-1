using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Map
    {
        private Tile[,] map;
        public Tile[,] GetMap { get { return map; } set { map = value; } }

        private Hero hero;
        public Hero GetHero { get { return hero; } set { hero = value; } }

        private Enemy[] enemies;
        public Enemy[] GetEnemies { get { return enemies; } set { enemies = value; } }

        private int count = 0;

        private int width;
        public int GetWidth { get { return width; } set { width = value; } }

        private int height;
        public int GetHeight { get { return height; } set { height = value; } }

        private Random rnd;
        public Random GetRnd { get { return rnd; } set { rnd = value; } }

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies)
        {
            rnd = new Random();

            width = rnd.Next(minWidth, maxWidth + 1);
            height = rnd.Next(minHeight, maxHeight + 1);

            map = new Tile[height, width];

            enemies = new Enemy[numEnemies];

            //Tile temp = Create(Tile.TileType.Hero);
            //map[hero.GetY, hero.GetX] = temp;

            for (int i = 0; i < numEnemies; i++)
            {
                //temp = Create(Tile.TileType.Enemy);
                //map[enemies[i].GetY, enemies[i].GetX] = temp;
            }

            UpdateVision();
        }

        public void UpdateVision()
        {
            /*Tile[] currentVision = new Tile[4];
            int currentX = hero.GetX;
            int currentY = hero.GetY;

            currentVision[0] = map[currentY - 1, currentX];
            currentVision[1] = map[currentY + 1, currentX];
            currentVision[2] = map[currentY, currentX - 1];
            currentVision[3] = map[currentY, currentX + 1];

            hero.GetVision = currentVision;

            for (int i = 0; i < enemies.Length; i++)
            {
                currentX = enemies[i].GetX;
                currentY = enemies[i].GetY;

                currentVision[0] = map[currentY - 1, currentX];
                currentVision[1] = map[currentY + 1, currentX];
                currentVision[2] = map[currentY, currentX - 1];
                currentVision[3] = map[currentY, currentX + 1];

                enemies[i].GetVision = currentVision;
            }*/
        }

        private Tile Create(Tile.TileType type)
        {
            int posX = rnd.Next(1, width);

            int posY = rnd.Next(1, height);

            if (type.Equals("Hero"))
            {
                hero = new Hero(posX, posY);
                return hero;
            }
            else if (type.Equals("Enemy"))
            {
                enemies[count] = new Goblin(posX, posY);
                count++;
                return enemies[count - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
