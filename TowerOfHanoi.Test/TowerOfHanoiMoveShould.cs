using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace TowerOfHanoi.Test;
public class TowerOfHanoiMoveShould
{
    [Fact]
    public void Return1PlaceCWhenMoveOnly1LevelFrom0to2()
    {
        var stackA = new Stack<int>();
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.Move(1,0,2);
        towerOfHanoi.ToString().ShouldBe("place C: 1");
    }

    [Fact]
    public void Return1PlaceBWhenMoveOnly1LevelFrom0to1()
    {
        var stackA = new Stack<int>();
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.Move(1, 0, 1);
        towerOfHanoi.ToString().ShouldBe("place B: 1");
    }

    [Fact]
    public void Return1PlaceCWhenMoveOnly1LevelFrom1to2()
    {
        var stackA = new Stack<int>();
        var stackB = new Stack<int>();
        stackB.Push(1);
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.Move(1, 1, 2);
        towerOfHanoi.ToString().ShouldBe("place C: 1");
    }

    [Fact]
    public void Return1PlaceAWhenMoveOnly1LevelFrom1to0()
    {
        var stackA = new Stack<int>();
        var stackB = new Stack<int>();
        stackB.Push(1);
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.Move(1, 1, 0);
        towerOfHanoi.ToString().ShouldBe("place A: 1");
    }
}