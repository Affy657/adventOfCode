namespace Lib.Day05Year2023;

public class Category
{
    public string Name { get; set; }
    public List<Map> Map { get; set; }

    public Category(List<Map> mapList,string nameCat)
    {
        Map = mapList;
        Name = nameCat;
    }

    public long Apply(long seedInput)
    {
        foreach (Map currenMap in Map)
        {
            if (seedInput >= currenMap.StartSeed && seedInput < currenMap.StartSeed + currenMap.Range)
            {
                return currenMap.StartMap + (seedInput - currenMap.StartSeed);
            }
        }
        return seedInput;
    }

}

