susing System.Runtime.ConstrainedExecution;

namespace SoccerTeamsRanking.Test;

public class UnitTest1
{
    [Fact]
    public void SoccerTeamsRanking_14Teams_ReturnOrderedListOfTeams()
    {
        SoccerTeamsRanking.SoccerTeam[] team = new SoccerTeamsRanking.SoccerTeam[14];
        SoccerTeamsRanking.SoccerTeam[] orderedList = new SoccerTeamsRanking.SoccerTeam[14];
        team[0] = new SoccerTeamsRanking.SoccerTeam("CFR Cluj ", 33 + 3);
        team[1] = new SoccerTeamsRanking.SoccerTeam("FCSB ", 31 + 0);
        team[2] = new SoccerTeamsRanking.SoccerTeam("U Craiova ", 29 + 3);
        team[3] = new SoccerTeamsRanking.SoccerTeam("Dinamo ", 23 + 1);
        team[4] = new SoccerTeamsRanking.SoccerTeam("Viitorul ", 22 + 0);
        team[5] = new SoccerTeamsRanking.SoccerTeam("Astra Giurgiu ", 22 + 3);
        team[6] = new SoccerTeamsRanking.SoccerTeam("CSMS Iasi ", 21 + 0);
        team[7] = new SoccerTeamsRanking.SoccerTeam("FC Botosani ", 21 + 1);
        team[8] = new SoccerTeamsRanking.SoccerTeam("FC Voluntari ", 17 + 0);
        team[9] = new SoccerTeamsRanking.SoccerTeam("Chiajna ", 15 + 3);
        team[10] = new SoccerTeamsRanking.SoccerTeam("ACS Poli Tim", 14 + 0);
        team[11] = new SoccerTeamsRanking.SoccerTeam("Sepsi OSK", 11 + 3);
        team[12] = new SoccerTeamsRanking.SoccerTeam("Gaz Metan", 8 + 0);
        team[13] = new SoccerTeamsRanking.SoccerTeam("Juventus", 7 + 3);

        orderedList[0] = new SoccerTeamsRanking.SoccerTeam("CFR Cluj ", 33 + 3);
        orderedList[2] = new SoccerTeamsRanking.SoccerTeam("FCSB ", 31 + 0);
        orderedList[1] = new SoccerTeamsRanking.SoccerTeam("U Craiova ", 29 + 3);
        orderedList[4] = new SoccerTeamsRanking.SoccerTeam("Dinamo ", 23 + 1);
        orderedList[5] = new SoccerTeamsRanking.SoccerTeam("Viitorul ", 22 + 0);
        orderedList[3] = new SoccerTeamsRanking.SoccerTeam("Astra Giurgiu ", 22 + 3);
        orderedList[7] = new SoccerTeamsRanking.SoccerTeam("CSMS Iasi ", 21 + 0);
        orderedList[6] = new SoccerTeamsRanking.SoccerTeam("FC Botosani ", 21 + 1);
        orderedList[9] = new SoccerTeamsRanking.SoccerTeam("FC Voluntari ", 17 + 0);
        orderedList[8] = new SoccerTeamsRanking.SoccerTeam("Chiajna ", 15 + 3);
        orderedList[10] = new SoccerTeamsRanking.SoccerTeam("ACS Poli Tim", 14 + 0);
        orderedList[11] = new SoccerTeamsRanking.SoccerTeam("Sepsi OSK", 11 + 3);
        orderedList[13] = new SoccerTeamsRanking.SoccerTeam("Gaz Metan", 8 + 0);
        orderedList[12] = new SoccerTeamsRanking.SoccerTeam("Juventus", 7 + 3);
        SoccerTeamsRanking.Program.BubbleSort(team);


        Assert.Equal(orderedList, team);
    }
}
