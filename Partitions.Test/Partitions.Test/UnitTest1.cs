namespace Partitions.Test;

public class UnitTest1
{
    [Fact]
    public void Partition_Number2()
    {
        int n = 2;
        Assert.Equal("1 + 1\n", Program.GeneratePartitions(n));
    }

    [Fact]
    public void Partition_Number5()
    {
        int n = 5;
        Assert.Equal("1 + 1 + 1 + 1 + 1\n1 + 1 + 1 + 2\n1 + 1 + 3\n1 + 2 + 2\n1 + 4\n2 + 3\n", Program.GeneratePartitions(n));
    }

    [Fact]
    public void Partition_Number7()
    {
        int n = 7;
        Assert.Equal("1 + 1 + 1 + 1 + 1 + 1 + 1\n1 + 1 + 1 + 1 + 1 + 2\n1 + 1 + 1 + 1 + 3\n1 + 1 + 1 + 2 + 2\n1 + 1 + 1 + 4\n1 + 1 + 2 + 3\n1 + 1 + 5\n1 + 2 + 2 + 2\n1 + 2 + 4\n1 + 3 + 3\n1 + 6\n2 + 2 + 3\n2 + 5\n3 + 4\n", Program.GeneratePartitions(n));
    }
}
