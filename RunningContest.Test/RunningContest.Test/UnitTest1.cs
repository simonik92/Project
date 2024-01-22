using static RunningContest.RunningContest;

namespace RunningContest.Test;

public class UnitTest1
{
    [Fact]
    public void RunningContest_TwoSeries_ThreeContestsPerSerie_RankingAllContests()
    {
        RunningContest.Contest contest = new Contest();
        int seriesNumber = 2;
        int contestantsPerSeries = 3;
        contest.Series = new ContestRanking[seriesNumber];
        
        contest.Series[0].Contestants = new Contestant[contestantsPerSeries];
        contest.Series[1].Contestants = new Contestant[contestantsPerSeries];

        RunningContest.Contestant c1 = new Contestant("Ion", "Romania", 9.800);
        RunningContest.Contestant c2 = new Contestant("John", "USA", 9.825);
        RunningContest.Contestant c3 = new Contestant("Zoli", "Ungaria", 9.910);
        RunningContest.Contestant c4 = new Contestant("Michael", "Franta", 9.810);
        RunningContest.Contestant c5 = new Contestant("Vasile", "Romania", 9.900);
        RunningContest.Contestant c6 = new Contestant("Adriano", "Italia", 9.925);

        RunningContest.Contestant[] orderedContestants = new Contestant[] { c1, c4, c2, c5, c3, c6 };

        contest.Series[0].Contestants = new Contestant[] { c1, c2, c3 };
        contest.Series[1].Contestants = new Contestant[] { c4, c5, c6 };

        Program.GenerateGeneralRanking(ref contest);

        Assert.Equal(orderedContestants, contest.GeneralRanking.Contestants);

    }

}
