using TowerOfHanoi.Domain;

var stackA = new Stack<int>();
stackA.Push(6);
stackA.Push(5);
stackA.Push(4);
stackA.Push(3);
stackA.Push(2);
stackA.Push(1);
var stackB = new Stack<int>();
var stackC = new Stack<int>();

var towerOfHanoi = new TowerOfHanoi.Domain.TowerOfHanoi(stackA, stackB, stackC);



Console.WriteLine(towerOfHanoi);