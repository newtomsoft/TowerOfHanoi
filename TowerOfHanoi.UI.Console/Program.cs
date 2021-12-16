using TowerOfHanoi.UI.Console;

var towerOfHanoi = new TowerOfHanoi.Domain.TowerOfHanoi(6);
var towerOfHanoiLevelsObserver = new TowerOfHanoiObserver();

towerOfHanoiLevelsObserver.Subscribe(towerOfHanoi);
towerOfHanoi.MoveLevels();
towerOfHanoiLevelsObserver.OnCompleted();