using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WpfApp1_RozwiazywanieQuizu.Model
{
    class Quiz
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=D:\quizKW2.db;Version=3");
        public List<string> LoadQuizes()
        {
            List<string> quizes = new List<string>();
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            SQLiteDataReader reader;

            command.CommandText = "SELECT ID, name FROM quizzes ORDER BY ID";
            reader = command.ExecuteReader();

            string quizNumber = "0";
            while (reader.Read())
            {


                string id = ((long)reader["ID"]).ToString();
                string name = Base64Decode(((string)reader["name"]).ToString());


                quizNumber = id;

                if (!quizes.Contains(id))
                {
                    quizes.Add(quizNumber+". "+name);
                }
            }
            
            command.Dispose();
            conn.Close();
            return quizes;
        }

        public List<List<string>> LoadAllQuestions(int quizID)
        {
            List<List<string>> questionsWithIDs = new List<List<string>>();
            List<string> questions = new List<string>();
            List<string> questionIDs = new List<string>();
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            SQLiteDataReader reader;
            command.CommandText = "SELECT ID, question FROM pytania ORDER BY ID";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                string id = ((long)reader["ID"]).ToString();

                

                string question = Base64Decode((string)reader["question"]);

                int idInt = Convert.ToInt32((long)reader["ID"]);
                Console.WriteLine(idInt);
                Console.WriteLine(quizID);
                Console.WriteLine(quizID);
                Console.WriteLine(quizID);
                Console.WriteLine(quizID);
                if (idInt == quizID)
                {
                    questionIDs.Add(id);
                    questions.Add(question);
                }
            }
            command.Dispose();
            conn.Close();
            questionsWithIDs.Add(questionIDs);
            questionsWithIDs.Add(questions);
            return questionsWithIDs;
        }

        public List<List<object>> LoadAnswers(int quizID, int questionID)
        {
            List<List<object>> answersWithIDs = new List<List<object>>();
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(conn);
            SQLiteDataReader reader;

            command.CommandText = "SELECT ID, answer1, answer2,answer3, answer4, answers FROM pytania ORDER BY ID";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                //ZLICZANIE ILE JEST ODPOWIEDZI DLA ID =1 I DAWANIE TEGO JAKO ILOŚĆ


                int id = Convert.ToInt32((long)reader["ID"]);
                List<object> answers = new List<object>();

                if (id == quizID)
                {
                    string answer = Base64Decode((string)reader["answer1"]);
                    string answer2 = Base64Decode((string)reader["answer2"]);
                    string answer3 = Base64Decode((string)reader["answer3"]);
                    string answer4 = Base64Decode((string)reader["answer4"]);
                    string answersCount = reader["answers"].ToString();

                    answers.Add(id);
                    answers.Add(answer);
                    answers.Add(answer2);
                    answers.Add(answer3);
                    answers.Add(answer4);
                    answers.Add(answersCount);
                    answersWithIDs.Add(answers);
                }

                
            }
            command.Dispose();
            conn.Close();
            return answersWithIDs;
        }
    }
}
