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
        var result = diamondService.GetDiamondRepresentation('A');
        Assert.Equal("A", result);
    }
}
