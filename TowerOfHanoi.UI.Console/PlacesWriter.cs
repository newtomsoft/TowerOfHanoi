namespace TowerOfHanoi.UI.Console;

internal class PlacesWriter
{
    private const string LevelSeparator = " - ";
    private const string PlaceSeparator = " / ";

    private int _moveNumber;

    public void Write(IEnumerable<Place> places)
    {
        var levelBuilder = new StringBuilder();
        levelBuilder.Append($"Move {_moveNumber} ");
        _moveNumber++;
        foreach (var place in places) levelBuilder.Append(PlaceToString(place));
        var levelString = levelBuilder.ToString();
        levelString = PlaceSeparator.Aggregate(levelString, (current, separator) => current.TrimEnd(separator));
        System.Console.WriteLine(levelString);
    }

    private static string PlaceToString(Place place)
    {
        if (place.Levels.Count == 0) return string.Empty;
        var levelBuilder = new StringBuilder();
        levelBuilder.Append($"place {place.Name}: ");
        foreach (var level in place.Levels) levelBuilder.Append(level.Index + LevelSeparator);
        levelBuilder.Remove(levelBuilder.Length - LevelSeparator.Length, LevelSeparator.Length);
        levelBuilder.Append(PlaceSeparator);
        return levelBuilder.ToString();
    }
}