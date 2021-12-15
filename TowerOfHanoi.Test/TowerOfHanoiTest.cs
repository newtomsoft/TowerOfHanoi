using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace TowerOfHanoi.Test;
public class TowerOfHanoiTest
{
    [Fact]
    public void TowerOfHanoiWith2LevelsInPlaceAToStringShouldReturn()
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
    public void TowerOfHanoiWith1and2LevelsInPlaceA3and4InPlaceBToStringShouldReturn()
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


}