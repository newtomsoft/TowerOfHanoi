using System.Text;

namespace TowerOfHanoi.Domain;

public class TowerOfHanoi
{
    private const string LevelSeparator = " - ";
    private const string PlaceSeparator = " / ";
    private readonly Stack<int>[] _levels = new Stack<int>[3];

    public TowerOfHanoi(Stack<int> levelsInA, Stack<int> levelsInB, Stack<int> levelsInC)
    {
        _levels[0] = levelsInA;
        _levels[1] = levelsInB;
        _levels[2] = levelsInC;
    }

    public void Move(int levelNumber, int startPlaceIndex, int endPlaceIndex)
    {
        if (levelNumber == 1)
        {
            var levelToMove = _levels[startPlaceIndex].Pop();
            _levels[endPlaceIndex].Push(levelToMove);
            return;
        }
        if (levelNumber == 2)
        {
            var placeIndexes = new int[] {0, 1, 2};
            var otherPlaceIndex = placeIndexes.First(i => i!= startPlaceIndex && i!= endPlaceIndex);
            Move(1, startPlaceIndex, otherPlaceIndex);
            Move(1, startPlaceIndex, endPlaceIndex);
            Move(1, otherPlaceIndex, endPlaceIndex);
            return;
        }

        return;
    }

    public override string ToString()
    {
        var levelBuilder = new StringBuilder();
        levelBuilder.Append(PlaceToString(_levels[0], "A"));
        levelBuilder.Append(PlaceToString(_levels[1], "B"));
        levelBuilder.Append(PlaceToString(_levels[2], "C"));
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
}
