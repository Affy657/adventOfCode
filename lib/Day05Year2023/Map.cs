namespace lib.Day05Year2023;

public class Map
{
    public long Range { get; set; }
    public long StartSeed { get; set; }
    public long StartMap { get; set; }

    public Map(List<long> numberList)
    {
        if(numberList == null || numberList.Count != 3)
        {
            throw new ArgumentException(nameof(numberList));
        }

        Range = numberList[2];
        StartSeed = numberList[1];
        StartMap = numberList[0];
    }
}
