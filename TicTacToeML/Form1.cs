using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeML.Classes;

namespace TicTacToeML
{
    public partial class Form1 : Form
    {
        private string[,] _Board;
        public string Turn;
        private TTT _ttt;

        public Form1()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ttt = new TTT();
            InitializeBoard();
            //Random rand = new Random();
            //if (rand.Next(1) == 0)
            //    Start
        }

        private void InitializeBoard()
        {
            _Board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            //initialize button texts to blank
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
            Turn = "X"; // always User
        }

        private void BoardClick(object sender, EventArgs e)
        {
            int order = int.Parse(((Button)sender).Tag.ToString()) - 100;
            _Board[order % 3, order / 3] = Turn;
            ((Button)sender).Text = Turn;
            if (!_ttt.checkwin(_Board))
                NextPlayer();
            else Application.Exit();
        }

        private void NextPlayer()
        {
            if (Turn=="X")
            {
                Turn = "O";
                MachineTurn();
            }
            else
            {
                Turn = "X";
            }
        }

        private void MachineTurn()
        {

        }
    }
}
