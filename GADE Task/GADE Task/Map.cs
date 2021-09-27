using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = new EmptyTile(i, j);
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height- 1)
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            map[i, j] = new Obstacle(i, j);
                        }
                    }
                }
            }

            Tile temp = Create(Tile.TileType.Hero);
            map[hero.GetY, hero.GetX] = temp;

            for (int i = 0; i < numEnemies; i++)
            {
                temp = Create(Tile.TileType.Enemy);
                map[enemies[i].GetY, enemies[i].GetX] = temp;
            }

            UpdateVision();
        }

        public void UpdateVision()
        {
            Tile[] currentHeroVision = new Tile[4];

            int currentHeroX = hero.GetX;
            int currentHeroY = hero.GetY;

            currentHeroVision[0] = map[currentHeroY - 1, currentHeroX];
            currentHeroVision[1] = map[currentHeroY + 1, currentHeroX];
            currentHeroVision[2] = map[currentHeroY, currentHeroX - 1];
            currentHeroVision[3] = map[currentHeroY, currentHeroX + 1];

            hero.GetVision = currentHeroVision;

            Tile[] currentEnemyVision = new Tile[4];

            int currentEnemyX;
            int currentEnemyY;

            for (int i = 0; i < enemies.Length; i++)
            {
                currentEnemyX = enemies[i].GetX;
                currentEnemyY = enemies[i].GetY;

                currentEnemyVision[0] = map[currentEnemyY - 1, currentEnemyX];
                currentEnemyVision[1] = map[currentEnemyY + 1, currentEnemyX];
                currentEnemyVision[2] = map[currentEnemyY, currentEnemyX - 1];
                currentEnemyVision[3] = map[currentEnemyY, currentEnemyX + 1];

                enemies[i].GetVision = currentEnemyVision;
            }
        }

        private Tile Create(Tile.TileType type)
        {
            int posX;
            int posY;

            bool found = false;

            if (("" + type).Equals("Hero"))
            {
                posX = rnd.Next(1, width - 1);
                posY = rnd.Next(1, height - 1);

                hero = new Hero(posX, posY);

                return hero;
            }
            else if (("" + type).Equals("Enemy"))
            {

                do
                {
                    posX = rnd.Next(1, width - 1);
                    posY = rnd.Next(1, height - 1);

                    if (map[posY, posX].GetSymbol == ' ')
                    {
                        enemies[count] = new Goblin(posX, posY, 10, 1);
                        count++;
                        found = true;
                    }
                }
                while (!found);

                return enemies[count - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
