namespace DiamondLetters.UnitTests;

public class DiamondServiceTests
{
    [Fact]
    public void CreateDiamond_OnInvalidCharacter_ThrowArgumentException()
    {
        var diamondService = new DiamondService();

        Assert.Throws<ArgumentException>(() => diamondService.GetDiamondRepresentation('1'));
    }
}