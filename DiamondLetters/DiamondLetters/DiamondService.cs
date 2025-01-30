namespace DiamondLetters;

public class DiamondService
{
    public void GetDiamondRepresentation(char letter)
    {
        if (!char.IsLetter(letter))
        {
            throw new ArgumentException("Character is not a letter");
        }
    }
}
