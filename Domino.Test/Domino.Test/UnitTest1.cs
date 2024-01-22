namespace Domino.Test;

public class UnitTest1
{
    [Fact]
    public void Domino_TwoPieces_MatchAll()
    {
        int n = 2;
        string[] domino = new string[n];
        domino[0] = "1 2";
        domino[1] = "2 3";
        int x = 2;
        Assert.Equal("1 2 2 3\n", DominoPairs.GenerateDominoPairs(n, domino, x));
    }

    [Fact]
    public void Domino_ThreePieces_MatchAll()
    {
        int n = 3;
        string[] domino = new string[n];
        domino[0] = "1 2";
        domino[1] = "2 3";
        domino[2] = "3 4";
        int x = 3;
        Assert.Equal("1 2 2 3 3 4\n", DominoPairs.GenerateDominoPairs(n, domino, x));
    }

    [Fact]
    public void Domino_ThreePieces_MatchTwoOfThem()
    {
        int n = 3;
        string[] domino = new string[n];
        domino[0] = "1 2";
        domino[1] = "2 3";
        domino[2] = "3 4";
        int x = 2;
        Assert.Equal("1 2 2 3\n2 3 3 4\n", DominoPairs.GenerateDominoPairs(n, domino, x));
    }

    [Fact]
    public void Domino_ManyPieces_PairsOfTwo_TwoMatches()
    {
        int n = 9;
        string[] domino = new string[n];
        domino[0] = "1 2";
        domino[1] = "5 3";
        domino[2] = "3 4";
        domino[3] = "5 7";
        domino[4] = "1 4";
        domino[5] = "1 6";
        domino[6] = "1 7";
        domino[7] = "2 4";
        domino[8] = "5 4";

        int x = 2;
        Assert.Equal("1 2 2 4\n5 3 3 4\n", DominoPairs.GenerateDominoPairs(n, domino, x));
    }

    [Fact]
    public void Domino_ManyPieces_PairsOfTwo_UseOnePieceManyTimes()
    {
        int n = 9;
        string[] domino = new string[n];
        domino[0] = "1 2";
        domino[1] = "2 3";
        domino[2] = "1 4";
        domino[3] = "2 7";
        domino[4] = "2 4";
        domino[5] = "1 6";
        domino[6] = "1 7";
        domino[7] = "2 9";
        domino[8] = "5 4";

        int x = 2;
        Assert.Equal("1 2 2 3\n1 2 2 7\n1 2 2 4\n1 2 2 9\n", DominoPairs.GenerateDominoPairs(n, domino, x));
    }
}
