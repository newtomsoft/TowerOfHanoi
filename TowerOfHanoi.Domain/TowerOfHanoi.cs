using System.Text;

namespace TowerOfHanoi.Domain;

public class TowerOfHanoi
{
    private const string LevelSeparator = " - ";
    private const string PlaceSeparator = " / ";
    private static readonly Dictionary<int, char> Places = new() { { 0, 'A' }, { 1, 'B' }, { 2, 'C' } };

    private readonly Stack<int>[] _levels = new Stack<int>[3];
    private static readonly int[] PlaceIndexes = { 0, 1, 2 };
    
    private int _moveNumber;

    public TowerOfHanoi(Stack<int> levelsInA, Stack<int> levelsInB, Stack<int> levelsInC)
    {
        _moveNumber = 0;
        _levels[0] = levelsInA;
        _levels[1] = levelsInB;
        _levels[2] = levelsInC;
    }

    public TowerOfHanoi(int levelNumber)
    {
        _levels[0] = new Stack<int>();
        for (var currentLevel = levelNumber - 1; currentLevel >= 0; currentLevel--) _levels[0].Push(currentLevel);
        _levels[1] = new Stack<int>();
        _levels[2] = new Stack<int>();
    }

    public void MoveLevels() => Move(_levels[0].Count, 0, 2);


    public void Move(int startPlaceIndex, int endPlaceIndex)
    {
        Console.WriteLine(this);
        Move(_levels[0].Count, startPlaceIndex, endPlaceIndex);
    }

    public void Move(int levelNumber, int startPlaceIndex, int endPlaceIndex)
    {
        if (levelNumber == 1)
        {
            _moveNumber++;
            var levelToMove = _levels[startPlaceIndex].Pop();
            _levels[endPlaceIndex].Push(levelToMove);
            Console.WriteLine(this);
            return;
        }

        var sidingPlaceIndex = PlaceIndexes.First(index => index != startPlaceIndex && index != endPlaceIndex);
        if (levelNumber == 2)
        {
            Move(1, startPlaceIndex, sidingPlaceIndex);
            Move(1, startPlaceIndex, endPlaceIndex);
            Move(1, sidingPlaceIndex, endPlaceIndex);
            return;
        }

        Move(levelNumber - 1, startPlaceIndex, sidingPlaceIndex);
        Move(1, startPlaceIndex, endPlaceIndex);
        Move(levelNumber - 1, sidingPlaceIndex, endPlaceIndex);
    }

    public override string ToString()
    {
        var levelBuilder = new StringBuilder();
        levelBuilder.Append($"Move {_moveNumber} ");
        for (var i = 0; i < _levels.Length; i++) levelBuilder.Append(PlaceToString(_levels[i], Places[i]));
        var levelString = levelBuilder.ToString();
        levelString = PlaceSeparator.Aggregate(levelString, (current, separator) => current.TrimEnd(separator));
        return levelString;
    }

    private static string PlaceToString(Stack<int> levelStack, char placeName)
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
