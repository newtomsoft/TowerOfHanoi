using Shouldly;
using System.Collections.Generic;
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
    public void Return0Place2WhenMoveOnly0LevelFrom0to2()
    {
        var levelsA = new List<int> { 0 };
        var levelsB = new List<int>();
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] {_stackC, _stackB, _stackA};
        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(1, 0, 2);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }



    [Fact]
    public void Return0Place1WhenMoveOnly0LevelFrom0to1()
    {
        var levelsA = new List<int> { 0 };
        var levelsB = new List<int>();
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackB, _stackA, _stackC };
        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(1, 0, 1);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }

    [Fact]
    public void Return0Place2WhenMoveOnly0LevelFrom1to2()
    {
        var levelsA = new List<int>();
        var levelsB = new List<int> { 0 };
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackA, _stackC, _stackB };

        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(1, 1, 2);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }

    [Fact]
    public void Return0Place0WhenMoveOnly0LevelFrom1to0()
    {
        var levelsA = new List<int>();
        var levelsB= new List<int> { 0 };
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackB, _stackA, _stackC };

        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(1, 1, 0);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }

    [Fact]
    public void Return0And1Place2WhenMove0And1From0To2()
    {
        var levelsA = new List<int> { 0, 1 };
        var levelsB = new List<int>();
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackC, _stackB, _stackA };

        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(0, 2);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }

    [Fact]
    public void Return0And1And2Place2WhenMove0And1And2From0To2()
    {
        var levelsA = new List<int> { 0, 1, 2 };
        var levelsB = new List<int>();
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackC, _stackB, _stackA };

        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(0, 2);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }

    [Fact]
    public void Return0To3Place2WhenMove0To3From0To2()
    {
        var levelsA = new List<int> { 0, 1, 2, 3 };
        var levelsB = new List<int>();
        var levelsC = new List<int>();

        FillStacks(levelsA, levelsB, levelsC);
        var stacksExpected = new[] { _stackC, _stackB, _stackA };

        var towerOfHanoi = new Domain.TowerOfHanoi(levelsA, levelsB, levelsC);
        towerOfHanoi.Move(0, 2);
        towerOfHanoi.Levels.ShouldBe(stacksExpected);
    }
}