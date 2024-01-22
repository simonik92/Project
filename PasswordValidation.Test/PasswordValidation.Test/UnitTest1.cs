using Xunit;
using PasswordValidation;

namespace PasswordValidation.Test;

public class UnitTest1
{
    [Fact]
    public void IsPasswordCorrect_HasOneSmallLetter_ShouldReturnTrue()
    {
        string password = "a";
        Program.Conditions conditions = new Program.Conditions(1, 0, 0, 0, false, false);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneCapitalLetter_ShouldReturnTrue()
    {
        string password = "B";
        Program.Conditions conditions = new Program.Conditions(0, 1, 0, 0, false, false);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneDigit_ShouldReturnTrue()
    {
        string password = "6";
        Program.Conditions conditions = new Program.Conditions(0, 0, 1, 0, false, false);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneSymbol_ShouldReturnTrue()
    {
        string password = "+";
        Program.Conditions conditions = new Program.Conditions(0, 0, 0, 1, false, false);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneSmallLetter_HasOneCapitalLetter_HasOneDigit_HasOneSymbol_ShouldReturnTrue()
    {
        string password = "aB4+";
        Program.Conditions conditions = new Program.Conditions(1, 1, 1, 1, false, false);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneSmallLetter_HasOneCapitalLetter_HasOneDigit_HasOneSymbol_HasSimilarCharactersWhenShouldNotHave_ShouldReturnFalse()
    {
        string password = "aB4+O";
        Program.Conditions conditions = new Program.Conditions(1, 1, 1, 1, false, false);
        Assert.False(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneSmallLetter_HasOneCapitalLetter_HasOneDigit_HasOneSymbol_HasAmbiguousCharacters_ShouldReturnTrue()
    {
        string password = "aB4+}";
        Program.Conditions conditions = new Program.Conditions(1, 1, 1, 1, false, true);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void IsPasswordCorrect_HasOneSmallLetter_HasOneCapitalLetter_HasOneDigit_HasOneSymbol_HasAmbiguousCharactersWhenShouldNotHave_ShouldReturnFalse()
    {
        string password = "aB4+}";
        Program.Conditions conditions = new Program.Conditions(1, 1, 1, 1, false, false);
        Assert.False(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void Password_HasMoreSmallLetters_HasCapitalLetter_HasDigit_HasSymbol_NoSimilarChars_CanHaveAmbiguousChars_ShouldReturnTrue()
    {
        string password = "abcdeA2+";
        Program.Conditions conditions = new Program.Conditions(5, 1, 1, 1, false, true);
        Assert.True(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void Password_HasMoreSmallLetter_HasCapitalLetter_HasDigit_HasSymbol_NoSimilarChars_NoAmbiguousChars_ShouldReturnFalse()
    {
        string password = "abcdefA2+;";
        Program.Conditions conditions = new Program.Conditions(5, 1, 1, 1, false, false);
        Assert.False(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void Password_LessSmallLetter_HasCapitalLetter_HasDigit_HasSymbol_NoSimilarChars_CanHaveAmbiguousChars_ShouldReturnFalse()
    {
        string password = "abcdA2+;";
        Program.Conditions conditions = new Program.Conditions(5, 1, 1, 1, false, true);
        Assert.False(Program.IsPasswordCorrect(password, conditions));
    }

    [Fact]
    public void Password_HasSmallLetter_NoCapitalLetter_HasDigit_HasSymbol_NoSimilarChars_CanHaveAmbiguousChars_ShouldReturnFalse()
    {
        string password = "abcde2+;";
        Program.Conditions conditions = new Program.Conditions(5, 1, 1, 1, false, true);
        Assert.False(Program.IsPasswordCorrect(password, conditions));
    }
}
