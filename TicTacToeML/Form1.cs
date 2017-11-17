using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private int gamecounter;
        private int win, lose, draw;
        private bool GameOn, Gameoff;

        public Form1()
        {
            GameOn = true;
            InitializeComponent();
            groupBox1.Enabled = false;
            _ttt = new TTT();
            _Mach = new Brain();
            lblNum.Text = "";
            lblKno.Text = "";
            gamecounter = 0;
            win = 0;
            lose = 0;
            draw = -1;
            Gameoff = false;
        }

        public void GameLoop()
        {
            while (GameOn)
            {
                if ((boardCounter == 0) || ((_ttt.checkwin(_Board))))
                {
                    GameDone();
                    //if (gamecounter % 500 == 0)
                    if ((_Mach.Count()+1)%4000 == 0)
                    {
                        _Mach.UpdateMemory();
                    }
                    if (gamecounter%100000 == 0)
                    {
                        _Mach.UpdateMemory();
                    }
                    if (true)
                    {
                        GameOn = false;
                        break;
                    }
                    InitializeBoard();
                    if (Gameoff == true)
                    {
                        GameOn = false;
                        break;
                    }
                }
                NextPlayer();
                groupBox1.Visible = false;//SPEED
                if (gamecounter % 500 == 0)//SPEED
                    Refresh();
                ActiveControl = null;
                boardCounter--;
                //if ((win / (gamecounter * 1.00) * 100) > 70) GameOn = false;
                //if ((draw / (gamecounter * 1.00) * 100) > 70) GameOn = false;
                
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            InitializeBoard();
            NextPlayer();
            
        }

        private void InitializeBoard()
        {
            Logger.Log("MAIN", "New game. Initializing parameters----------------------------");
            groupBox1.Enabled = true;
            contiueToolStripMenuItem.Enabled = true;
            _Board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            _Mach.PlayList = new List<int[]>(); // TODO
            //initialize button texts to blank
            lblKno.Text = _Mach.Count().ToString();
            gamecounter++;
            lblNum.Text = gamecounter.ToString();
            lblwin.Text = string.Format("{0:N2}", win / (gamecounter * 1.00) * 100);
            lblLos.Text = string.Format("{0:N2}", lose / (gamecounter * 1.00) * 100);
            lblDraw.Text = string.Format("{0:N2}", draw / (gamecounter * 1.00) * 100);
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
        }

        private void BoardClick(object sender, EventArgs e)
        {
            Refresh();
            ActiveControl = null;
            Turn = "X";
            int order = int.Parse(((Button)sender).Tag.ToString()) - 100;
            _Board[order % 3, order / 3] = Turn;
            ((Button)sender).Text = Turn;
            ((Button)sender).Enabled = false;
            boardCounter--;
            if ((boardCounter == 0) || ((_ttt.checkwin(_Board))))
                GameDone();
            else NextPlayer();
        }

        private void NextPlayer()
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
                if (GameOn)
                    randomPLay();
            }
        }

        Button sender;
        private void randomPLay()
        {
            Random RandA = new Random();
            int A = RandA.Next(9);
            Thread newThread = new Thread(delegate ()
            {
                while (_Board[A / 3, A % 3] != "")
                    A = RandA.Next(9);
            });
            newThread.Start();
            int B = A % 3;
            A = A / 3;
            _Board[A, B] = Turn;
            sender = new Button();
            #region [ switch button select ]
            switch (A)
            {
                case 0:
                    {
                        switch (B)
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
                        switch (B)
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
                        switch (B)
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
        }

        private void MachineTurn()
        {
            int[] loc = _Mach.play(_Board);
            _Board[loc[0], loc[1]] = Turn;
            sender = new Button();
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
        }

        private void contiueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boardCounter = 0;
            GameOn = true;
            GameLoop();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gameoff = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GameDone()
        {
            Logger.Log("MAIN-GameDone", "--Game done--");
            Logger.SetForColGreen();
            if (boardCounter == 0)
            {
                Logger.Log("MAIN-GameDone", "game Draw");
                draw++;
                _Mach.Learn('D');
            }
            else if (Turn == "O")
            {

                Logger.Log("MAIN-GameDone", "Machine Won");
                win++;
                _Mach.Learn('W');
            }
            else if (Turn == "X")
            {
                //nothign happens
                Logger.Log("MAIN-GameDone", "Machine Lost");
                lose++;
                //_Mach.Learn('L');
            }
            Logger.Reset();
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
