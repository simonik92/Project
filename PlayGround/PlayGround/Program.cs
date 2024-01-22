    public struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;
​
        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }
​
   public struct ContestRanking
    {
        public Contestant[] Contestants;
    }
​
   public struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }
​
   public class Program
    {
        public static void GenerateGeneralRanking(ref Contest contest)
        {
            // TO DO: remove the line below and implement this function
            contest.GeneralRanking.Contestants = new Contestant[0];
            for (int i = 0; i < contest.Series.Length; i++)
            {
                ContestRanking original = contest.GeneralRanking;
                contest.GeneralRanking.Contestants = new Contestant[contest.GeneralRanking.Contestants.Length + contest.Series[i].Contestants.Length];
                Array.Copy(original.Contestants, contest.GeneralRanking.Contestants, original.Contestants.Length);
                Array.Copy(contest.Series[i].Contestants, 0, contest.GeneralRanking.Contestants, original.Contestants.Length, contest.Series[i].Contestants.Length);
            }
​
            MergeSort(ref contest, 0, contest.GeneralRanking.Contestants.Length - 1);
        }
​
        static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);
            Print(contest.GeneralRanking);
            Console.Read();
        }
​
        private static void Print(ContestRanking contestRanking)
        {
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }
​
        static void MergeSort(ref Contest contest, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
​
            int middle = (start + end) / 2;
​
            MergeSort(ref contest, start, middle);
            MergeSort(ref contest, middle + 1, end);
            Merge(ref contest, start, middle, end);
        }
​
        static void Merge(ref Contest contest, int left, int middle, int right)
        {
            Contestant[] firstSeries = new Contestant[middle - left + 1];
            Contestant[] secondSeries = new Contestant[right - middle];
​
            Array.Copy(contest.GeneralRanking.Contestants, left, firstSeries, 0, middle - left + 1);
            Array.Copy(contest.GeneralRanking.Contestants, middle + 1, secondSeries, 0, right - middle);
​
            int i = 0;
            int j = 0;
​
            for (int k = left; k < right + 1; k++)
            {
                if (i == firstSeries.Length)
                {
                    contest.GeneralRanking.Contestants[k] = secondSeries[j];
                    j++;
                }
                else if (j == secondSeries.Length || firstSeries[i].Time <= secondSeries[j].Time)
                {
                    contest.GeneralRanking.Contestants[k] = firstSeries[i];
                    i++;
                }
                else
                {
                    contest.GeneralRanking.Contestants[k] = secondSeries[j];
                    int v = j++;
                }
            }
        }
​
        static Contest ReadContestSeries()
        {
            Contest contest = new Contest();
​
            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());
​
            contest.Series = new ContestRanking[seriesNumber];
​
            for (int i = 0; i < seriesNumber; i++)
            {
                contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                for (int j = 0; j < contestantsPerSeries; j++)
                {
                    string contestantLine = "";
​
                    while (contestantLine == "")
                    {
                        contestantLine = Console.ReadLine();
                    }
​
                    contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                }
            }
​
            return contest;
        }
​
        private static Contestant CreateContestant(string[] contestantData)
        {
            const int nameIndex = 0;
            const int countryIndex = 1;
            const int timeIndex = 2;
​
            return new Contestant(
                contestantData[nameIndex].Trim(),
                contestantData[countryIndex].Trim(),
                Convert.ToDouble(contestantData[timeIndex]));
        }
    }