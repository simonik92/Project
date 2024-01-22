namespace RunningContest;

public class RunningContest
{
    public struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;

        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }

    public struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    public struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    public class Program
    {
        static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);
            Print(contest.GeneralRanking);
            Console.Read();
        }

        private static void Print(ContestRanking contestRanking)
        {
            const string line = "{0} - {1} - {2:F3}";
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant[] contestant = new Contestant[contestRanking.Contestants.Length];
                contestant[i] = contestRanking.Contestants[i];
                Console.WriteLine(string.Format(line, contestant[i].Name, contestant[i].Country, contestant[i].Time));
            }
        }

        public static void GenerateGeneralRanking(ref Contest contest)
        {
            contest.GeneralRanking.Contestants = new Contestant[0];
            for (int i = 0; i < contest.Series.Length; i++)
            {
                ContestRanking secondContest = contest.GeneralRanking;
                contest.GeneralRanking.Contestants = new Contestant[contest.GeneralRanking.Contestants.Length + contest.Series[i].Contestants.Length];

                Array.Copy(secondContest.Contestants, contest.GeneralRanking.Contestants, secondContest.Contestants.Length);
                Array.Copy(contest.Series[i].Contestants, 0, contest.GeneralRanking.Contestants, secondContest.Contestants.Length, contest.Series[i].Contestants.Length);
            }

            MergeSort(ref contest, 0, contest.GeneralRanking.Contestants.Length - 1);
        }

        static void MergeSort(ref Contest contest, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int middle = (left + right) / 2;

            MergeSort(ref contest, left, middle);
            MergeSort(ref contest, middle + 1, right);
            Merge(ref contest, left, middle, right);

        }

        static void Merge(ref Contest contest, int left, int middle, int right)
        {
            Contestant[] serie1 = new Contestant[middle - left + 1];
            Contestant[] serie2 = new Contestant[right - middle];

            Array.Copy(contest.GeneralRanking.Contestants, left, serie1, 0, middle - left + 1);
            Array.Copy(contest.GeneralRanking.Contestants, middle + 1, serie2, 0, right - middle);

            int i = 0;
            int j = 0;

            for (int k = left; k < right + 1; k++)
            {
                if (i == serie1.Length)
                {
                    contest.GeneralRanking.Contestants[k] = serie2[j];
                    j++;
                }
                else if (j == serie2.Length || serie1[i].Time <= serie2[j].Time)
                {
                    contest.GeneralRanking.Contestants[k] = serie1[i];
                    i++;
                }
                else
                {
                    contest.GeneralRanking.Contestants[k] = serie2[j];
                    int v = j++;
                }
            }
        }

        static Contest ReadContestSeries()
        {
            Contest contest = new Contest();

            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

            contest.Series = new ContestRanking[seriesNumber];

            for (int i = 0; i < seriesNumber; i++)
            {
                contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                for (int j = 0; j < contestantsPerSeries; j++)
                {
                    string contestantLine = "";

                    while (contestantLine == "")
                    {
                        contestantLine = Console.ReadLine();
                    }

                    contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                }
            }

            return contest;
        }

        private static Contestant CreateContestant(string[] contestantData)
        {
            const int nameIndex = 0;
            const int countryIndex = 1;
            const int timeIndex = 2;

            return new Contestant(
                contestantData[nameIndex].Trim(),
                contestantData[countryIndex].Trim(),
                Convert.ToDouble(contestantData[timeIndex]));
        }
    }
}