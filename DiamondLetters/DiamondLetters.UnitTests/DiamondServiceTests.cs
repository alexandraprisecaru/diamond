namespace DiamondLetters.UnitTests;

public class DiamondServiceTests
{
    readonly DiamondService diamondService = new();

    [Fact]
    public void CreateDiamond_OnInvalidCharacter_ThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => diamondService.GetDiamondRepresentation('1'));
    }

    [Fact]
    public void CreateDiamond_OnCharacterA_ReturnsTheSameCharacterAsString()
    {
        string result = diamondService.GetDiamondRepresentation('A');
        Assert.Equal("A", result);
    }

    [Fact]
    public void CreateDiamond_OnLowerCharacterA_ReturnsTheSameCharacterAsString()
    {
        string result = diamondService.GetDiamondRepresentation('a');
        Assert.Equal("a", result);
    }

    [Fact]
    public void CreateDiamond_OnCharacterB_ReturnsDiamondThatHasBInTheMiddle()
    {
        const string bDiamond = " A \nB B\n A \n";

        string result = diamondService.GetDiamondRepresentation('B');
        Assert.Equal(bDiamond.Length, result.Length);
        Assert.Equal(bDiamond, result);
    }
}
