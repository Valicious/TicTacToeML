using System;
using System.Collections;
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
        private Brain _Mach;
        private int boardCounter;

        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            _ttt = new TTT();
            _Mach = new Brain();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log("MAIN","New game. Initializing parameters----------------------------");
            groupBox1.Enabled = true;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            _Board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            _Mach.PlayList = new List<int[]>(); // TODO
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
            a1.Enabled = true;
            a2.Enabled = true;
            a3.Enabled = true;
            b1.Enabled = true;
            b2.Enabled = true;
            b3.Enabled = true;
            c1.Enabled = true;
            c2.Enabled = true;
            c3.Enabled = true;
            boardCounter = 9;
            Random randP = new Random();
            if (randP.Next(2) == 0)
                Turn = "X"; // always User
            else Turn = "O";
            NextPlayer();
        }

        private void BoardClick(object sender, EventArgs e)
        {
            int order = int.Parse(((Button)sender).Tag.ToString()) - 100;
            _Board[order % 3, order / 3] = Turn;
            ((Button)sender).Text = Turn;
            ((Button)sender).Enabled = false;
            if (!_ttt.checkwin(_Board))
                NextPlayer();
            else GameDone();
            boardCounter--;
        }

        private void NextPlayer()
        {
            if (boardCounter == 0)
                GameDone();
            else
            {
                if (Turn == "X")
                {
                    Logger.Log("MAIN-game", "--Machine turn--");
                    Turn = "O";
                    MachineTurn();
                }
                else
                {
                    Logger.Log("MAIN-game", "--Player turn--");
                    Turn = "X";
                }
            }
        }

        private void MachineTurn()
        {
            int[] loc = _Mach.play(_Board);
            _Board[loc[0], loc[1]] = Turn;
            Button sender = new Button();
            #region [ switch button select ]
            switch (loc[0])
            {
                case 0:
                    {
                        switch (loc[1])
                        {
                            case 0:
                                {
                                    sender = a1;
                                    break;
                                }
                            case 1:
                                {
                                    sender = a2;
                                    break;
                                }
                            case 2:
                                {
                                    sender = a3;
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        switch (loc[1])
                        {
                            case 0:
                                {
                                    sender = b1;
                                    break;
                                }
                            case 1:
                                {
                                    sender = b2;
                                    break;
                                }
                            case 2:
                                {
                                    sender = b3;
                                    break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch (loc[1])
                        {
                            case 0:
                                {
                                    sender = c1;
                                    break;
                                }
                            case 1:
                                {
                                    sender = c2;
                                    break;
                                }
                            case 2:
                                {
                                    sender = c3;
                                    break;
                                }
                        }
                        break;
                    }
            };
            #endregion
            sender.Text = Turn;
            sender.Enabled = false;
            Refresh();
            this.ActiveControl = null;
            if (!_ttt.checkwin(_Board))
                NextPlayer();
            else GameDone();
            boardCounter--;
        }

        private void GameDone()
        {
            Logger.Log("MAIN-GameDone", "--Game done--");
            if (boardCounter == 0)
            {
                Logger.Log("MAIN-GameDone", "game Draw");
                _Mach.Learn('D');
            }
            else if (Turn == "O")
            {
                Logger.Log("MAIN-GameDone", "Machine Won");
                _Mach.Learn('W');
            }
            else if (Turn == "X")
            {
                //nothign happens
                Logger.Log("MAIN-GameDone", "Machine Lost");
                //_Mach.Learn('L');
            }
            
            groupBox1.Enabled = false;
            /*D := Draw
             *W := Won
             *L := Lost
             * */
        }

        private void updateMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update Memory", "Do you want to save the aquired knowledge?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dialogResult = MessageBox.Show("Update Memory", "Are you really sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _Mach.UpdateMemory();
                }
            }
        }
    }
}
