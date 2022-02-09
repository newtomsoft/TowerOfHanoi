using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
// ReSharper disable CollectionNeverUpdated.Local

namespace TowerOfHanoi.Test;
public class TowerOfHanoiMoveShould
{
    private Stack<int> _stackA = new();
    private Stack<int> _stackB = new();
    private Stack<int> _stackC = new();

    private void FillStacks(IEnumerable<int> levelsA, IEnumerable<int> levelsB, IEnumerable<int> levelsC)
    {
        _stackA = new Stack<int>(levelsA);
        _stackB = new Stack<int>(levelsB);
        _stackC = new Stack<int>(levelsC);
    }

    [Fact]
    public async Task Return0Place2WhenMoveOnly0LevelFrom0to2Async()
    {
        var towerOfHanoi = new Domain.TowerOfHanoi(6);

        towerOfHanoi.StepsNumber.ShouldBe(0);
        await foreach (var move in towerOfHanoi.GetStepsAsync())
        {
            move.Number.ShouldBe(0);
            move.Places.Length.ShouldBe(3);
            move.Places[0].Levels.Count.ShouldBe(6);
            move.Places[1].Levels.Count.ShouldBe(0);
            move.Places[2].Levels.Count.ShouldBe(0);
        }

        towerOfHanoi.Move(1, 0, 2);
        towerOfHanoi.StepsNumber.ShouldBe(1);

        var iterationNumber = 0;
        await foreach (var move in towerOfHanoi.GetStepsAsync())
        {
            move.Number.ShouldBe(iterationNumber);
            move.Places.Length.ShouldBe(3);
            switch (iterationNumber)
            {
                case 0:
                    move.Places[0].Levels.Count.ShouldBe(6);
                    move.Places[1].Levels.Count.ShouldBe(0);
                    move.Places[2].Levels.Count.ShouldBe(0);

                    move.Places[0].Levels[0].Index.ShouldBe(0);
                    move.Places[0].Levels[1].Index.ShouldBe(1);
                    move.Places[0].Levels[2].Index.ShouldBe(2);
                    move.Places[0].Levels[3].Index.ShouldBe(3);
                    move.Places[0].Levels[4].Index.ShouldBe(4);
                    move.Places[0].Levels[5].Index.ShouldBe(5);
                    break;
                case 1:
                    move.Places[0].Levels.Count.ShouldBe(5);
                    move.Places[1].Levels.Count.ShouldBe(0);
                    move.Places[2].Levels.Count.ShouldBe(1);

                    move.Places[0].Levels[0].Index.ShouldBe(0);
                    move.Places[0].Levels[1].Index.ShouldBe(1);
                    move.Places[0].Levels[2].Index.ShouldBe(2);
                    move.Places[0].Levels[3].Index.ShouldBe(3);
                    move.Places[0].Levels[4].Index.ShouldBe(4);

                    move.Places[2].Levels[0].Index.ShouldBe(5);
                    break;
            }

            iterationNumber++;
        }

    }



    //[Fact]
    //public void Return0Place1WhenMoveOnly0LevelFrom0to1()
    //{
    //    var levelsA = new List<int> { 0 };
    //    var levelsB = new List<int>();
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackB, _stackA, _stackC };
    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(1, 0, 1);
    //    towerOfHanoi.Places.ShouldBe(stacksExpected);
    //}

    //[Fact]
    //public void Return0Place2WhenMoveOnly0LevelFrom1to2()
    //{
    //    var levelsA = new List<int>();
    //    var levelsB = new List<int> { 0 };
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackA, _stackC, _stackB };

    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(1, 1, 2);
    //    towerOfHanoi.PlacesOld.ShouldBe(stacksExpected);
    //}

    //[Fact]
    //public void Return0Place0WhenMoveOnly0LevelFrom1to0()
    //{
    //    var levelsA = new List<int>();
    //    var levelsB = new List<int> { 0 };
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackB, _stackA, _stackC };

    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(1, 1, 0);
    //    towerOfHanoi.PlacesOld.ShouldBe(stacksExpected);
    //}

    //[Fact]
    //public void Return0And1Place2WhenMove0And1From0To2()
    //{
    //    var levelsA = new List<int> { 0, 1 };
    //    var levelsB = new List<int>();
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackC, _stackB, _stackA };

    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(0, 2);
    //    towerOfHanoi.PlacesOld.ShouldBe(stacksExpected);
    //}

    //[Fact]
    //public void Return0And1And2Place2WhenMove0And1And2From0To2()
    //{
    //    var levelsA = new List<int> { 0, 1, 2 };
    //    var levelsB = new List<int>();
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackC, _stackB, _stackA };

    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(0, 2);
    //    towerOfHanoi.PlacesOld.ShouldBe(stacksExpected);
    //}

    //[Fact]
    //public void Return0To3Place2WhenMove0To3From0To2()
    //{
    //    var levelsA = new List<int> { 0, 1, 2, 3 };
    //    var levelsB = new List<int>();
    //    var levelsC = new List<int>();

    //    FillStacks(levelsA, levelsB, levelsC);
    //    var stacksExpected = new[] { _stackC, _stackB, _stackA };

    //    var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
    //    towerOfHanoi.Move(0, 2);
    //    towerOfHanoi.PlacesOld.ShouldBe(stacksExpected);
    //}
}