using System;

namespace RunningContest
{
    struct Contestant
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

    struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    class Program
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
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }

        static void GenerateGeneralRanking(ref Contest contest)
        {
            const int magicNumber = 2;

            for (int interval = contest.GeneralRanking.Contestants.Length / 2; interval > 0; interval /= magicNumber)
            {
                for (int i = interval; i < contest.GeneralRanking.Contestants.Length; i++)
                {
                    var currentKey = contest.GeneralRanking.Contestants[i];
                    var k = i;
                    while (k >= interval && contest.GeneralRanking.Contestants[k - interval].Time > currentKey.Time)
                    {
                        contest.GeneralRanking.Contestants[k] = contest.GeneralRanking.Contestants[k - interval];
                        k -= interval;
                    }

                    contest.GeneralRanking.Contestants[k] = currentKey;
                }
            }
        }

        static Contest ReadContestSeries()
        {
            Contest contest = new Contest();
            int count = 0;

            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

            contest.Series = new ContestRanking[seriesNumber];
            contest.GeneralRanking.Contestants = new Contestant[seriesNumber * contestantsPerSeries];

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
                    contest.GeneralRanking.Contestants[count] = contest.Series[i].Contestants[j];
                    count++;
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
