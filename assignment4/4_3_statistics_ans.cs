using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            int subCount = data.GetLength(1) - 2;

            Console.WriteLine("Average Scores:");
            double Avg;
            for (int i = 2;i < subCount + 2;i++)
            {
                Avg = 0;
                for (int j = 1;j <= stdCount;j++)
                {
                    Avg += double.Parse(data[j,i]);
                }
                Avg /= stdCount;
                Console.WriteLine(data[0,i] + ": " + Avg.ToString("n2"));
            }

            Console.WriteLine("\nMax and min Scores:");

            int max, min;

            for (int i = 2; i < subCount + 2; i++)
            {
                max = 0;
                min = 0;
                for (int j = 1; j <= stdCount; j++)
                {   
                    if (j == 1) max = int.Parse(data[j, i]);
                    if (j == 1) min = int.Parse(data[j, i]);
                    if (int.Parse(data[j, i]) >= max) max = int.Parse(data[j, i]);
                    if (int.Parse(data[j, i]) <= min) min = int.Parse(data[j, i]);
                }
                Console.WriteLine(data[0, i] + ": (" + max.ToString() + ", " + min.ToString() + ")");
            }

            Console.WriteLine("\nStudents rank by total scores:");
            int[] stdTotal = new int[stdCount];
            for (int i = 0;i < stdCount;i++)
            {
                stdTotal[i] = 0;
            }
            int rank;

            for (int i = 2; i < subCount + 2; i++)
            {
                rank = stdCount;
                for (int j = 1; j <= stdCount; j++)
                {
                    stdTotal[j - 1] += int.Parse(data[j, i]);
                }

            }

            //for (int i = 0; i < stdCount; i++) Console.WriteLine(data[i + 1, 1] + ": " + stdTotal[i].ToString());
            for (int i = 1; i <= stdCount; i++)
            {
                rank = stdCount;
                for (int j = 1; j <= stdCount; j++)
                {
                    if (stdTotal[i - 1] > stdTotal[j - 1]) rank--;
                }
                if (rank % 10 == 1 && rank != 11)
                {
                    Console.WriteLine(data[i, 1] + ": " + rank.ToString() + "st");
                } else if (rank % 10 == 2 && rank != 12)
                {
                    Console.WriteLine(data[i, 1] + ": " + rank.ToString() + "nd");
                } else if (rank % 10 == 3 && rank != 13)
                {
                    Console.WriteLine(data[i, 1] + ": " + rank.ToString() + "rd");
                } else
                {
                    Console.WriteLine(data[i, 1] + ": " + rank.ToString() + "th");
                }
            }

            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd 

*/