namespace TowerOfHanoi.Domain;

public class Place
{
    public string Name { get; }
    public List<Level> Levels { get; }

    public Place(IEnumerable<Level> levels, string name)
    {
        Levels = levels.ToList();
        Name = name;
    }

    public Level RemoveLevel()
    {
        var levelToRemove = Levels[^1];
        Levels.Remove(levelToRemove);
        return levelToRemove;
    }

    public void AddLevel(Level level) => Levels.Add(level);

    public Place Copy()
    {
        var levels = Levels.Select(level => level.Copy());
        return new Place(levels, Name);
    }
}