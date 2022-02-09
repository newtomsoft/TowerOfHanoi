namespace TowerOfHanoi.Domain;

public class Step
{
    public int Number { get; }

    public Place[] Places { get; }

    public Step(int number, Place[] places)
    {
        Number = number;
        Places = places;
    }
}