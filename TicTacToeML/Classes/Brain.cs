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

        public ArrayList PlayList { get; set; }

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
            while (Reader.Read())
            {
                string[,] blayout = con1to2((Reader[1]).ToString().Split(','));
                string[,] bpins = con1to2((Reader[2]).ToString().Split(','));
                string[][,] ArrRead = { blayout, bpins };
                boardLayout.Add(ArrRead);
                //Logger.Log("Brain", string.Format("Stage 2.{0} : {1} {2}",boardLayout.Count, blayout., ArrRead[1].ToString()));
            }
            Logger.Log("Brain", "Stage 3 : Done. Knowledge Imported Successfuly");
        }


        public int[] play(string[,] board)
        {
            string[][,] Thought;

            int pos = boardLayout.FindIndex(u => (string[,])u[0] == (board)); //NEEDS TO BE FIXED!!
            if (pos == -1)
            {
                string[,] bpins = new string[3, 3];
                string[,] newboard = new string[3, 3]; // deep clonging makes me sad
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        if (board[a, b] == "") bpins[a, b] = "3";
                        else bpins[a, b] = "0";
                        newboard[a, b] = (string)board[a, b].Clone();
                    }
                }
                string[][,] ArrRead = { newboard, bpins };
                boardLayout.Add(ArrRead);
                pos = boardLayout.Count();
                Thought = ArrRead;
                KnowledgeCompleteness += 1 / Kbase;
                Logger.Log("Brain-game", string.Format("Knowledge Aquired! {0:N10}", KnowledgeCompleteness));
            }
            else
                Thought = boardLayout.ElementAt(pos);
            Logger.Log("Brain-game", "Board Selected");
            Random RandA = new Random();
            Random RandB = new Random();
            int A = RandA.Next(3);
            int B = RandB.Next(3);
            while (Thought[1][A, B] == "0")
            {
                RandA = new Random();
                RandB = new Random();
                A = RandA.Next(3);
                B = RandB.Next(3);
            }
            object[] obj = { pos, A, B };
            PlayList.Add(obj);
            Thought[1][A, B] = (int.Parse(Thought[1][A, B]) - 1).ToString();
           
            Logger.Log("Brain-game", "Pin Selected");
            return new int[]{A,B};
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
        #endregion
    }
}
