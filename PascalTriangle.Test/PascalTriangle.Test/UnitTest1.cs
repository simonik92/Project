namespace PascalTriangle.Test;

public class UnitTest1
{
    [Fact]
    public void PascalTriangle_GenerateOneLevel()
    {
        int n = 1;
        Assert.Equal("1 \n", Program.Triangle(n));
    }

    [Fact]
    public void PascalTriangle_Generate2Levels()
    {
        int n = 2;
        Assert.Equal("1 \n1 1 \n", Program.Triangle(n));
    }

    [Fact]
    public void PascalTriangle_Generate3Levels()
    {
        int n = 3;
        Assert.Equal("1 \n1 1 \n1 2 1 \n", Program.Triangle(n));
    }

    [Fact]
    public void PascalTriangle_Generate4Levels()
    {
        int n = 4;
        Assert.Equal("1 \n1 1 \n1 2 1 \n1 3 3 1 \n", Program.Triangle(n));
    }

}
