namespace DiamondLetters;

using System.Text;

public class DiamondService
{
    public string GetDiamondRepresentation(char letter)
    {
        int alphabetIndex = GetAlphabetIndex(letter)
                            ?? throw new ArgumentException("Character is not a letter");

        if (alphabetIndex == 0)
        {
            return letter.ToString();
        }

        int matrixSize = 2 * alphabetIndex + 1;
        StringBuilder sb = new StringBuilder();

        int lineNumber = 0;

        char alphabetLetter = 'A';
        while (lineNumber < matrixSize)
        {
            int lettersPerLine = lineNumber == 0 || lineNumber == matrixSize - 1 ? 1 : 2;
            int middleWhiteSpace = lineNumber == 0 || lineNumber == matrixSize - 1 ? 0 : 2 * lineNumber - 1;
            int marginWhiteSpace = (matrixSize - lettersPerLine - middleWhiteSpace) / 2;

            sb.Append(' ', marginWhiteSpace);
            sb.Append(alphabetLetter);

            if (lineNumber > 0 && lineNumber < matrixSize - 1)
            {
                sb.Append(' ', middleWhiteSpace);
                sb.Append(alphabetLetter);
            }

            sb.Append(' ', marginWhiteSpace);
            sb.AppendLine();

            if (lineNumber >= matrixSize / 2)
            {
                alphabetLetter--;
            }
            else
            {
                alphabetLetter++;
            }

            lineNumber++;
        }

        return sb.ToString();
    }

    private static int? GetAlphabetIndex(char letter)
        => char.IsLetter(letter) ? char.ToUpperInvariant(letter) - 'A' : null;
}
