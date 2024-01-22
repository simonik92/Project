namespace ConvertToHexa.Test;

public class UnitTest1
{
    [Fact]
    public void ConvertToHexa_OneNumberSmallerThan16_ShouldReturnTheConversion()
    {
        int input = 10;
        Assert.Equal("A", Program.Reverse(input));
    }

    [Fact]
    public void ConvertToHexa_OneNumberGreaterThan16_ShouldReturnTheConversion()
    {
        int input = 36;
        Assert.Equal("24", Program.Reverse(input));
    }

    [Fact]
    public void ConvertToHexa_OneBigNumber_ShouldReturnTheConversion()
    {
        int input = 256;
        Assert.Equal("100", Program.Reverse(input));
    }

    [Fact]
    public void ConvertToHexa_OneVeryBigNumber_ShouldReturnTheConversion()
    {
        int input = 765432;
        Assert.Equal("BADF8", Program.Reverse(input));
    }

    [Fact]
    public void ConvertToHexa_Number0_ShouldReturnTheConversion()
    {
        int input = 0;
        Assert.Equal("0", Program.Reverse(input));
    }

}
