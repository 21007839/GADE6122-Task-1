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

        GameEngine ge = new GameEngine(StartScreen.minWidth, StartScreen.maxWidth,
                                           StartScreen.minHeight, StartScreen.maxHeight,
                                           StartScreen.numEnemies);

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            lblMap.Text = "" + ge;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Up);
            lblMap.Text = "" + ge;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Down);
            lblMap.Text = "" + ge;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Left);
            lblMap.Text = "" + ge;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ge.MovePlayer(Character.MovementEnum.Right);
            lblMap.Text = "" + ge;
        }
    }
}
