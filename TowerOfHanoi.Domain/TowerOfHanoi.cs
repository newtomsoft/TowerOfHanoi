namespace TowerOfHanoi.Domain;

public class TowerOfHanoi
{
    private static readonly int[] PlaceIndexes = { 0, 1, 2 };
    private readonly Place[] _places = new Place[3];
    private IEnumerable<Step> _steps = new List<Step>();
    private int _millisecondsDelay;
    public int StepsNumber { get; private set; }


    public TowerOfHanoi(int levelNumber, int millisecondsDelay = 500)
    {
        _millisecondsDelay = millisecondsDelay;
        var levels0 = new List<Level>();
        levels0.AddRange(Enumerable.Range(0, levelNumber).Select(number => new Level(number)));
        _places[0] = new Place(levels0, "A");
        _places[1] = new Place(new List<Level>(), "B");
        _places[2] = new Place(new List<Level>(), "C");
        var placesCopy = _places.Select(place => place.Copy()).ToArray();
        var step = new Step(0, placesCopy);
        _steps = _steps.Append(step);
    }

    public void ChangeDelay(int millisecondsDelay) => _millisecondsDelay = millisecondsDelay;

    public void MoveLevels() => Move(0, 2);

    public void Move(int startPlaceIndex, int endPlaceIndex) => Move(_places[0].Levels.Count, startPlaceIndex, endPlaceIndex);

    public void Move(int levelsNumber, int startPlaceIndex, int endPlaceIndex)
    {
        if (levelsNumber == 0) return;
        if (levelsNumber == 1)
        {
            StepsNumber++;
            var level = _places[startPlaceIndex].RemoveLevel();
            _places[endPlaceIndex].AddLevel(level);
            var placesCopy = _places.Select(place => place.Copy()).ToArray();
            var step = new Step(StepsNumber, placesCopy);
            _steps = _steps.Append(step);
            return;
        }
        var sidingPlaceIndex = PlaceIndexes.First(index => index != startPlaceIndex && index != endPlaceIndex);
        Move(levelsNumber - 1, startPlaceIndex, sidingPlaceIndex);
        Move(1, startPlaceIndex, endPlaceIndex);
        Move(levelsNumber - 1, sidingPlaceIndex, endPlaceIndex);
    }

    public async IAsyncEnumerable<Step> GetStepsAsync()
    {
        foreach (var step in _steps)
        {
            await Task.Delay(_millisecondsDelay);
            yield return step;
        }
    }
}
