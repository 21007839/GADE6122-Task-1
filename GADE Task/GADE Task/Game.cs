using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public partial class Game : Form
    {

        public static GameEngine ge;

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            ge = new GameEngine(StartScreen.minWidth, StartScreen.maxWidth,
                                           StartScreen.minHeight, StartScreen.maxHeight,
                                           StartScreen.numEnemies);

            int length = ge.GetGameMap.GetEnemies.Length;
            for (int i = 0; i < length; i++)
            {
                cmbTarget.Items.Add(ge.GetGameMap.GetEnemies[i]);
            }

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Up);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Down);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Left);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Right);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            ge.GetGameMap.GetHero.Attack(ge.GetGameMap.GetEnemies[cmbTarget.SelectedIndex]);

            lblMap.Text = "" + ge;
            lblPlayerStats.Text = "" + ge.GetGameMap.GetHero;
        }
    }
}
