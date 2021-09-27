using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public class Hero : Character
    {

        public Hero(int inX, int inY) : base(inX, inY, GameEngine.GetHeroSymbol)
        {
            HP = 10;
            maxHP = 10;
            damage = 2;
        }

        public override void Attack(Character target)
        {
            if (CheckRange(target))
            {
                int oldHP = target.GetHP;
                int newHP = target.GetHP - this.damage;
                target.GetHP = newHP;

                if (target.IsDead())
                {
                    Game.ge.GetGameMap.GetMap[target.GetY, target.GetX] = new EmptyTile(target.GetY, target.GetX);

                    MessageBox.Show("Enemy defeated!\n"
                                  + "Damage dealt: " + oldHP + " -> " + newHP);
                }
                else
                {
                    MessageBox.Show("Enemy hit!\n"
                                  + "Damage dealt: " + oldHP + " -> " + newHP);
                }
            }
            else
            {
                MessageBox.Show("Enemy out of range!\nHit was unsuccessful.");
            }
        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    if (vision[0].GetSymbol == ' ')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol == ' ')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Left:
                    if (vision[2].GetSymbol == ' ')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol == ' ')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                default:
                    return MovementEnum.None;
            }
        }

        public override string ToString()
        {
            if (HP == maxHP)
            {
                return "Player Stats:\n" +
                   "HP: " + maxHP + "\n" +
                   "Damage: " + damage + "\n" +
                   "[" + x + ", " + y + "]";
            }
            else
            {
                return "Player Stats:\n" +
                   "HP: " + HP + "\n" +
                   "Damage: " + damage + "\n" +
                   "[" + x + ", " + y + "]";
            }
        }
    }
}
