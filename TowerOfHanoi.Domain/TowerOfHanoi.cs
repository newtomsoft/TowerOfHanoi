using System.Text;

namespace TowerOfHanoi.Domain;

public class TowerOfHanoi
{
    private const string LevelSeparator = " - ";
    private const string PlaceSeparator = " / ";
    private Stack<int> _levelsInA;
    private Stack<int> _levelsInB;
    private Stack<int> _levelsInC;

    public TowerOfHanoi(Stack<int> levelsInA, Stack<int> levelsInB, Stack<int> levelsInC)
    {
        _levelsInA = levelsInA;
        _levelsInB = levelsInB;
        _levelsInC = levelsInC;
    }

    public override string ToString()
    {
        var levelBuilder = new StringBuilder();
        levelBuilder.Append(PlaceToString(_levelsInA, "A"));
        levelBuilder.Append(PlaceToString(_levelsInB, "B"));
        levelBuilder.Append(PlaceToString(_levelsInC, "C"));
        var levelString = levelBuilder.ToString();
        levelString = PlaceSeparator.Aggregate(levelString, (current, separator) => current.TrimEnd(separator));
        return levelString;
    }

    private static string PlaceToString(Stack<int> levelStack, string placeName)
    {
        if (levelStack.Count == 0) return string.Empty;
        var levelBuilder = new StringBuilder();
        levelBuilder.Append($"place {placeName}: ");
        foreach (var level in levelStack) levelBuilder.Append(level + LevelSeparator);
        levelBuilder.Remove(levelBuilder.Length - LevelSeparator.Length, LevelSeparator.Length);
        levelBuilder.Append(PlaceSeparator);
        return levelBuilder.ToString();
    }

    public void Move()
    {

    }
}
