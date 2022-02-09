var towerOfHanoi06Levels = new TowerOfHanoi.Domain.TowerOfHanoi(06, 50);
//var towerOfHanoi07Levels = new TowerOfHanoi.Domain.TowerOfHanoi(07);
//var showPlaces07Levels = new ShowPlaces(towerOfHanoi07Levels.GetEnumerablePlacesOld);

var move06Levels = new Task(() => towerOfHanoi06Levels.MoveLevels());
//var move07Levels = new Task(() => towerOfHanoi07Levels.MoveLevels());
move06Levels.Start();

var placesWriter = new PlacesWriter();

Console.WriteLine("Compute 06 levels started...");
//move07Levels.Start();
//Console.WriteLine("Compute 07 levels started...");

//showPlaces07Levels.Show();

await foreach (var move in towerOfHanoi06Levels.GetStepsAsync()) placesWriter.Write(move.Places);

//await showPlaces06Levels.Show();

//Task.WaitAll(move06Levels, move07Levels);
Task.WaitAll(move06Levels);

Console.WriteLine("End Application");
