using System.Text;

namespace TowerOfHanoi.UI.Console;

public sealed class TowerOfHanoiObserver : IObserver<Stack<int>[]>
{
    private static readonly Dictionary<int, char> Places = new() { { 0, 'A' }, { 1, 'B' }, { 2, 'C' } };
    private const string LevelSeparator = " - ";
    private const string PlaceSeparator = " / ";

    private IDisposable _unsubscriber = null!;
    private int _moveNumber;

    public void Subscribe(IObservable<Stack<int>[]> provider)
    {
        _unsubscriber = provider.Subscribe(this);
    }

    public void OnCompleted() => Unsubscribe();

    public void OnError(Exception error)
    {
        // Method intentionally left empty.
    }

    private void Unsubscribe() => _unsubscriber.Dispose();

    public void OnNext(Stack<int>[] value)
    {
        _moveNumber++;
        var levelBuilder = new StringBuilder();
        levelBuilder.Append($"Move {_moveNumber} ");
        for (var i = 0; i < value.Length; i++) levelBuilder.Append(PlaceToString(value[i], Places[i]));
        var levelString = levelBuilder.ToString();
        levelString = PlaceSeparator.Aggregate(levelString, (current, separator) => current.TrimEnd(separator));
        System.Console.WriteLine(levelString);
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
