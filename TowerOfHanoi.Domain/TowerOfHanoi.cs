using System.Text;

namespace TowerOfHanoi.Domain;

public class TowerOfHanoi : IObservable<Stack<int>[]>
{
    private static readonly int[] PlaceIndexes = { 0, 1, 2 };

    public Stack<int>[] Levels { get; } = new Stack<int>[3];

    private int _moveNumber;

    private readonly List<IObserver<Stack<int>[]>> _observers = new();

    public TowerOfHanoi(int levelNumber)
    {
        Levels[0] = new Stack<int>();
        for (var currentLevel = 0; currentLevel < levelNumber; currentLevel++) Levels[0].Push(currentLevel);
        Levels[1] = new Stack<int>();
        Levels[2] = new Stack<int>();
    }

    public TowerOfHanoi(IEnumerable<int> levelsInA, IEnumerable<int> levelsInB, IEnumerable<int> levelsInC)
    {
        Levels[0] = new Stack<int>(levelsInA);
        Levels[1] = new Stack<int>(levelsInB);
        Levels[2] = new Stack<int>(levelsInC);
    }
    
    public void MoveLevels() => Move(Levels[0].Count, 0, 2);


    public void Move(int startPlaceIndex, int endPlaceIndex)
    {
        Console.WriteLine(this);
        Move(Levels[0].Count, startPlaceIndex, endPlaceIndex);
    }

    public void Move(int levelNumber, int startPlaceIndex, int endPlaceIndex)
    {
        if (levelNumber == 1)
        {
            _moveNumber++;
            Levels[endPlaceIndex].Push(Levels[startPlaceIndex].Pop());
            foreach (var observer in _observers) observer.OnNext(Levels);
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

    public IDisposable Subscribe(IObserver<Stack<int>[]> observer)
    {
        if (_observers.Contains(observer)) return new Unsubscriber(_observers, observer);
        _observers.Add(observer);
        observer.OnNext(Levels);
        return new Unsubscriber(_observers, observer);
    }

    private sealed class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Stack<int>[]>> _levelsObservers;
        private readonly IObserver<Stack<int>[]>? _levelsObserver;
        
        public Unsubscriber(List<IObserver<Stack<int>[]>> observers, IObserver<Stack<int>[]> observer)
        {
            _levelsObservers = observers;
            _levelsObserver = observer;
        }

        public void Dispose()
        {
            if (_levelsObserver is not null && _levelsObservers.Contains(_levelsObserver)) _levelsObservers.Remove(_levelsObserver);
        }
    }
}
