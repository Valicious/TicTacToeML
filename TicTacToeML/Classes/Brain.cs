using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace TicTacToeML.Classes
{
    class Brain
    {
        private const double Kbase = 19683.00000000000;//total possible board layouts
        public double KnowledgeCompleteness { get; set; }
        private List<string[][,]> boardLayout;
        private int MemoryStockPos;

        public List<int[]> PlayList { get; set; }

        public int Count()
        {
            return boardLayout.Count;
        }

        public Brain()
        {
            Logger.Log("Brain", "Stage 0 : Initiating knowledge loading");
            string CS = ConfigurationManager.ConnectionStrings["dbBrain_Conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(CS);
            string sql = "SELECT COUNT(*) FROM [Knowledge]";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                KnowledgeCompleteness = double.Parse(Reader[0].ToString()) / Kbase;
                Logger.Log("Brain", string.Format("Stage 1 : KnowledgeCompleteness {0:N10}", KnowledgeCompleteness));
            }
            connection.Close();
            sql = "SELECT * FROM [Knowledge]";
            connection.Open();
            command = new SqlCommand(sql, connection);
            Reader = command.ExecuteReader();
            Logger.Log("Brain", "Stage 2 : Reading Knowledge");
            boardLayout = new List<string[][,]>();
            MemoryStockPos = 0;
            while (Reader.Read())
            {
                string[,] blayout = con1to2((Reader[1]).ToString().Split(','));
                string[,] bpins = con1to2((Reader[2]).ToString().Split(','));
                string[][,] ArrRead = { blayout, bpins };
                boardLayout.Add(ArrRead);
                MemoryStockPos++;
                Logger.Log("Brain", string.Format("Stage 2.{0} : {1} \t {2}", boardLayout.Count, con2to1(blayout), con2to1(bpins)));
            }
            Logger.Log("Brain", "Stage 3 : Done. Knowledge Imported Successfuly");
            PlayList = new List<int[]>();
        }

        public void UpdateMemory()
        {
            //update
            Logger.Log("Brain-Memory", "Stage 1 : Updating Memory");
            int counter = MemoryStockPos;
            while (MemoryStockPos > 0)
            {
                Logger.Log("Brain-Memory", string.Format("Stage 1 : Updating Memory. {0} left", MemoryStockPos));
                string blayout = con2to1(boardLayout[0][0]);
                string bpins = con2to1(boardLayout[0][1]);
                string CS = ConfigurationManager.ConnectionStrings["dbBrain_Conn"].ConnectionString;
                SqlConnection connection = new SqlConnection(CS);
                string sql = "UPDATE [Knowledge] SET [Pins] = '" + bpins + "' WHERE [Layout] = '" + blayout + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.ExecuteReader();
                connection.Close();
                MemoryStockPos--;
                boardLayout.RemoveAt(0);
            }
            //store

            while (boardLayout.Count > 0)
            {
                Logger.Log("Brain-Memory", string.Format("Stage 2 : Inserting new Memories. {0} left", boardLayout.Count));
                string blayout = con2to1(boardLayout[0][0]);
                string bpins = con2to1(boardLayout[0][1]);
                string CS = ConfigurationManager.ConnectionStrings["dbBrain_Conn"].ConnectionString;
                SqlConnection connection = new SqlConnection(CS);
                string sql = "INSERT INTO [Knowledge] ([IDstate], [Layout], [Pins]) VALUES (" + counter + " ,N'" + blayout + "' ,N'" + bpins + "')";
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.ExecuteReader();
                connection.Close();
                boardLayout.RemoveAt(0);
                counter++;
            }
            //string[] blayout = con2to1();
            //string[] bpins = con2to1();
        }

        public int[] play(string[,] board)
        {
            string[][,] Thought;

            //int pos = boardLayout.FindIndex(u => (string[,])u[0] == (board)); //NEEDS TO BE FIXED!!
            int pos = -1;
            int counter = 0;
            for (int i = 0; i < boardLayout.Count; i++)
            {
                counter = 0;
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        if (boardLayout[i][0][a, b].Equals(board[a, b]))
                        {
                            counter++;
                        }
                        else break;
                    }
                 }
                if (counter == 9)
                {
                    pos = i;
                    break;
                }
            }
            object newe = boardLayout;


            if (pos == -1)
            {
                string[,] bpins = new string[3, 3];
                string[,] newboard = new string[3, 3]; // deep clonging makes me sad
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        if (board[a, b] == "") bpins[a, b] = "1";
                        else bpins[a, b] = "0";
                        newboard[a, b] = (string)board[a, b].Clone();
                    }
                }
                string[][,] ArrRead = { newboard, bpins };
                boardLayout.Add(ArrRead);
                pos = boardLayout.Count() - 1;
                Thought = ArrRead;
                KnowledgeCompleteness += 1 / Kbase;
                Logger.Log("Brain-game", string.Format("Knowledge Aquired! {0:N10}", KnowledgeCompleteness));
            }
            else
                Thought = boardLayout.ElementAt(pos);
            Logger.Log("Brain-game", "Board Selected");
            Random RandA = new Random();
            int A = RandA.Next(9);
            int lc = 120;
            while (Thought[1][A / 3, A % 3] == "0")
            {
                A = RandA.Next(9);
                lc--;
                if (lc == 0)
                {//Add refresh counter
                    Logger.SetBackBlue();
                    Logger.Log("Brain-game", "                                    Reseting Node");
                   // Logger.Reset();
                    for (int a = 0; a < 3; a++)
                    {
                        for (int b = 0; b < 3; b++)
                        {
                            if (Thought[0][a, b] == "") Thought[1][a, b] = "1";
                            else Thought[1][a, b] = "0";
                        }
                    }
                    lc = 81;
                }
            }
            Logger.Log("Brain-game", "                                   " + lc.ToString());
            int B = A % 3;
            A = A / 3;
            int[] obj = { pos, A, B };
            PlayList.Add(obj);
            Thought[1][A, B] = (int.Parse(Thought[1][A, B]) - 1).ToString();
            boardLayout[pos] = Thought;
            Logger.Log("Brain-game", "Pin Selected");
            return new int[] { A, B };
        }

        public void Learn(char score)
        {
            switch (score)
            {
                case 'W':
                    {
                        while (PlayList.Count > 0)
                        {
                            int[] cur = PlayList[0];
                            boardLayout[cur[0]][1][cur[1], cur[2]] = (int.Parse(boardLayout[cur[0]][1][cur[1], cur[2]]) + 3).ToString();
                            PlayList.RemoveAt(0);
                        }
                        Logger.Log("Brain-GameDone", "Machine awarded +3");
                        break;
                    }
                case 'D':
                    {
                        while (PlayList.Count > 0)
                        {
                            int[] cur = PlayList[0];
                            boardLayout[cur[0]][1][cur[1], cur[2]] = (int.Parse(boardLayout[cur[0]][1][cur[1], cur[2]]) + 1).ToString();
                            PlayList.RemoveAt(0);
                        }
                        Logger.Log("Brain-GameDone", "Machine awarded +1");
                        break;
                    }
            }
        }

        #region [ utils ]
        private string[,] con1to2(string[] input)
        {
            int order = 0;
            string[,] output = new string[3, 3];
            foreach (string s in input)
            {
                output[order / 3, order % 3] = input[order];
                order++;
            }
            return output;
        }

        private string con2to1(string[,] input)
        {
            string output = "";
            foreach (string a in input)
                output += a + ',';
            return output.Remove(output.Length - 1, 1); ;
        }
        #endregion
    }
}
