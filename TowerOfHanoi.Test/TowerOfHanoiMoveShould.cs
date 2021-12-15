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
        towerOfHanoi.ToString().ShouldBe("Move 1 place C: 1");
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
        towerOfHanoi.ToString().ShouldBe("Move 1 place B: 1");
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
        towerOfHanoi.ToString().ShouldBe("Move 1 place C: 1");
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
        towerOfHanoi.ToString().ShouldBe("Move 1 place A: 1");
    }

    [Fact]
    public void Return1And2PlaceCWhenMove1And2From0To2()
    {
        var stackA = new Stack<int>();
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("Move 0 place A: 1 - 2");
        towerOfHanoi.Move( 0, 2);
        towerOfHanoi.ToString().ShouldBe("Move 3 place C: 1 - 2");
    }

    [Fact]
    public void Return1And2And3PlaceCWhenMove1And2And3From0To2()
    {
        var stackA = new Stack<int>();
        stackA.Push(3);
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("Move 0 place A: 1 - 2 - 3");
        towerOfHanoi.Move(0, 2);
        towerOfHanoi.ToString().ShouldBe("Move 7 place C: 1 - 2 - 3");
    }

    [Fact]
    public void Return1To4PlaceCWhenMove1To4From0To2()
    {
        var stackA = new Stack<int>();
        stackA.Push(4);
        stackA.Push(3);
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("Move 0 place A: 1 - 2 - 3 - 4");
        towerOfHanoi.Move(0, 2);
        towerOfHanoi.ToString().ShouldBe("Move 15 place C: 1 - 2 - 3 - 4");
    }
}