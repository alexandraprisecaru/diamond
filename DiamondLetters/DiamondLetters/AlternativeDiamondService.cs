namespace DiamondLetters;

using DiamondLetters.Exceptions;

public class AlternativeDiamondService
{
    private const char WhiteSpace = ' ';
    private const char NewLine = '\n';

    public string CreateDiamond(char letter)
    {
        int alphabetIndex = GetAlphabetIndex(letter)
                            ?? throw new InvalidLetterException(letter);

        if (alphabetIndex == 0)
        {
            return letter.ToString();
        }

        int diamondSize = 2 * alphabetIndex + 1;
        int lineLength = diamondSize + 1; // add new line character
        int totalDiamondSize = diamondSize * lineLength;

        Span<char> diamond = stackalloc char[totalDiamondSize];

        int lineNumber = 0;

        char currentLetter = char.IsUpper(letter) ? 'A' : 'a';

        Span<char> line = stackalloc char[lineLength];

        // go only through the first half, mirror the results and add in the middle line
        while (lineNumber <= diamondSize / 2)
        {
            int currentLetterIndex = GetAlphabetIndex(currentLetter)!.Value;
            int lettersPerLine = lineNumber == 0 ? 1 : 2;
            int middleWhiteSpace = lineNumber == 0 ? 0 : 2 * currentLetterIndex - 1;
            int marginWhiteSpace = (diamondSize - lettersPerLine - middleWhiteSpace) / 2;

            // left margin
            line[..marginWhiteSpace].Fill(WhiteSpace);

            // letter
            line[marginWhiteSpace] = currentLetter;

            int index = marginWhiteSpace + 1;
            if (lineNumber != 0)
            {
                // middle white space
                line.Slice(index, middleWhiteSpace).Fill(WhiteSpace);

                // letter
                line[index + middleWhiteSpace] = currentLetter;
                index += middleWhiteSpace + 1;
            }

            // right margin
            line.Slice(index, marginWhiteSpace).Fill(WhiteSpace);
            
            // new line
            line[index + marginWhiteSpace] = NewLine;

            int firstDiamondIndex = lineLength * lineNumber;
            int secondDiamondIndex = totalDiamondSize - lineLength * (lineNumber + 1);

            line.TryCopyTo(diamond.Slice(firstDiamondIndex, lineLength));
            if (lineNumber < diamondSize / 2)
            {
                line.TryCopyTo(diamond.Slice(secondDiamondIndex, lineLength));
            }

            currentLetter++;
            lineNumber++;
        }

        return diamond.Slice(0, totalDiamondSize - 1).ToString();
    }

    private static int? GetAlphabetIndex(char letter)
        => char.IsLetter(letter) ? char.ToUpperInvariant(letter) - 'A' : null;
}
