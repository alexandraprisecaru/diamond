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
        Span<char> line = stackalloc char[lineLength];

        int lineNumber = 0;
        char currentLetter = char.IsUpper(letter) ? 'A' : 'a';

        // go only through the first half, mirror the results and add in the middle line
        while (lineNumber <= diamondSize / 2)
        {
            int currentLetterIndex = GetAlphabetIndex(currentLetter)!.Value;
            int lettersPerLine = lineNumber == 0 ? 1 : 2;
            int middleWhiteSpace = lineNumber == 0 ? 0 : 2 * currentLetterIndex - 1;
            int marginWhiteSpace = (diamondSize - lettersPerLine - middleWhiteSpace) / 2;

            BuildLine(line, marginWhiteSpace, middleWhiteSpace, currentLetter, lineNumber);

            int upperHalfLineIndex = lineLength * lineNumber;
            int lowerHalfLineIndex = totalDiamondSize - lineLength * (lineNumber + 1);

            line.TryCopyTo(diamond.Slice(upperHalfLineIndex, lineLength));
            if (lineNumber < diamondSize / 2)
            {
                line.TryCopyTo(diamond.Slice(lowerHalfLineIndex, lineLength));
            }

            currentLetter++;
            lineNumber++;
        }

        return diamond.Slice(0, totalDiamondSize - 1).ToString();
    }

    private static void BuildLine(Span<char> line, int margin, int middle, char letter, int lineNumber)
    {
        // left margin
        line[..margin].Fill(WhiteSpace);

        // letter
        line[margin] = letter;

        int index = margin + 1;
        if (lineNumber != 0)
        {
            // middle white space
            line.Slice(index, middle).Fill(WhiteSpace);

            // letter
            line[index + middle] = letter;
            index += middle + 1;
        }

        // right margin
        line.Slice(index, margin).Fill(WhiteSpace);

        // new line
        line[index + margin] = NewLine;
    }

    private static int? GetAlphabetIndex(char letter)
        => char.IsLetter(letter) ? char.ToUpperInvariant(letter) - 'A' : null;
}
