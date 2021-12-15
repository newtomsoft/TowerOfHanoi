using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace TowerOfHanoi.Test;
public class TowerOfHanoiToStringShould
{
    [Fact]
    public void Return1And2LevelsInPlaceA()
    {
        var stackA = new Stack<int>();
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("place A: 1 - 2");
    }

    [Fact]
    public void Return1And2LevelsInPlaceA3And4InPlaceB()
    {
        var stackA = new Stack<int>();
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        stackB.Push(4);
        stackB.Push(3);
        var stackC = new Stack<int>();
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("place A: 1 - 2 / place B: 3 - 4");
    }

    [Fact]
    public void Return1And2LevelsInPlaceA3And4InPlaceB5And6And7InPlaceC()
    {
        var stackA = new Stack<int>();
        stackA.Push(2);
        stackA.Push(1);
        var stackB = new Stack<int>();
        stackB.Push(4);
        stackB.Push(3);
        var stackC = new Stack<int>();
        stackC.Push(7);
        stackC.Push(6);
        stackC.Push(5);
        var towerOfHanoi = new Domain.TowerOfHanoi(stackA, stackB, stackC);
        towerOfHanoi.ToString().ShouldBe("place A: 1 - 2 / place B: 3 - 4 / place C: 5 - 6 - 7");
    }
}