using System;

namespace Homework6._1
{
    class Program
    {          
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        static void Main(string[] args)
        {
            Difficulty Rank = 0;
            double score = 0;

            SelectPages(Rank, score);
        }

        static void SelectPages(Difficulty Rank, double score)
        {
            Console.WriteLine("Score: {0}, Difficulty: {1}", score, Rank);
            int Select;
            for (int i = 0; ; i++)
            {
                Select = int.Parse(Console.ReadLine());
                while (Select > 2 || Select < 0)
                {
                    Console.WriteLine("“Please input 0 - 2.”");
                    Select = int.Parse(Console.ReadLine());
                }              
                if (Select == 0)
                {
                    playGame(Rank, score);
                }
                else if (Select == 1)
                {
                    GameLevels(ref Rank, score);
                }
                else if (Select == 2)
                {
                    break;
                }
               
                break;
            }

        }

        static void playGame(Difficulty Rank, double score)
        {
            int numquestion = 0;
            double levelDifficul = 0;
            if (Rank == 0)
            {
                numquestion = 3;
                levelDifficul = 0;
            }
            if (Rank == Difficulty.Normal)
            {
                numquestion = 5;
                levelDifficul = 1;
            }
            if (Rank == Difficulty.Hard)
            {
                numquestion = 7;
                levelDifficul = 2;
            }
            Problem[] Gameplay = GenerateRandomProblems(numquestion);

            long starttime = DateTimeOffset.Now.ToUnixTimeSeconds();
            double ture = 0;
            for (int i = 0; i <= Gameplay.Length - 1; i++)
            {
                Console.WriteLine(Gameplay[i].Message);
                int answer;
                answer = int.Parse(Console.ReadLine());

                if (Gameplay[i].Answer == answer)
                {
                    ture++;
                }
            }
            long endtime = DateTimeOffset.Now.ToUnixTimeSeconds();
            long time = endtime - starttime;

            double now;
            now = (ture / numquestion) * ((25 - levelDifficul * levelDifficul) / Math.Max(time, 25 - levelDifficul * levelDifficul)) * Math.Pow(2 * levelDifficul + 1, 2);
            Console.WriteLine("Your score is {0}", now);
            score += now;

            SelectPages(Rank, score);
        }

        static void GameLevels(ref Difficulty Rank, double score)
        {
            for (int i = 0; ; i++)
            {
                int choose;
                Console.WriteLine("In put the difficulty: ");
                choose = int.Parse(Console.ReadLine());
                while (choose > 2 || choose < 0)
                {
                    Console.WriteLine("“Please input 0 - 2.”");
                    choose = int.Parse(Console.ReadLine());
                }
                if (choose == 0)
                {
                    Rank = Difficulty.Easy;
                }
                else if (choose == 1)
                {
                    Rank = Difficulty.Normal;
                }
                else if (choose == 2)
                {
                    Rank = Difficulty.Hard;
                }                
                break;
            }
            Console.WriteLine("difficult:{0}", Rank);

            SelectPages(Rank, score);
        }
        
        
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }
    }
}
