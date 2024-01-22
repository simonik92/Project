using System;

namespace SoccerTeamsRanking;

public class SoccerTeamsRanking
{
    public struct SoccerTeam
    {
        public string Name;
        public int Points;

        public SoccerTeam(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }

    public class Program
    {
        public static void Main()
        {
            SoccerTeam[] teamsRanking = ReadTeams();
            Console.WriteLine(GenerateTheMessage(teamsRanking));
        }

        public static string GenerateTheMessage(SoccerTeam[] teamsRanking)
        {
            string swapMessage = BubbleSort(teamsRanking);
            string ranking = Print(teamsRanking);
            return swapMessage + ranking;
        }

        public static string BubbleSort(SoccerTeam[] teams)
        {
            string message = "";
            for (int i = teams.Length - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (teams[j - 1].Points < teams[j].Points)
                    {
                        message += Swap(teams, j - 1, j);
                    }
                }
            }
            return message;
        }

        public static string Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);
            const string message = "Swapping elements with indexes ({0}, {1}) and values ({2}, {3})" + "\n";
            string result = string.Format(message, minIndex, maxIndex, teams[minIndex].Name, teams[maxIndex].Name);

            SoccerTeam temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
            return result;
        }

        public static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }

        public static string Print(SoccerTeam[] teamsRanking)
        {
            string result = "";
            for (int i = 0; i < teamsRanking.Length; i++)
            {
                result += teamsRanking[i].Name + "- " + teamsRanking[i].Points + "\n";
            }
            return result;
        }

        public static SoccerTeam[] ReadTeams()
        {
            SoccerTeam[] result = new SoccerTeam[14];

            for (int i = 0; i < result.Length; i++)
            {
                string[] teamData = Console.ReadLine().Split('-');
                int points = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
                result[i] = new SoccerTeam(teamData[0], points);
            }

            return result;
        }
    }
}

