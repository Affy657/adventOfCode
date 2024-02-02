namespace Lib.Day04Year2023;

internal class Card
{
    public int ReferenceId { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> Numbers { get; set; }
    public int Count { get; set; }

    public Card(int referenceId, List<int> winningNumbers, List<int> numbers)
    {
        ReferenceId = referenceId;
        WinningNumbers = winningNumbers;
        Numbers = numbers;
        Count = 1;
    }
}
