namespace TowerOfHanoi.Domain;

public class Level
{
    public int Index { get; }

    public Level(int index) => Index = index;

    public Level Copy() => new(Index);
}