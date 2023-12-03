// See https://aka.ms/new-console-template for more information

using Day2;

var inputLines = Input.Data.Trim()
    .Split(Environment.NewLine);

var games = new List<Game>();

foreach (var line in inputLines)
{
    var gameId = line.Split(':')[0].Split(' ')[1];
    var game = new Game
    {
        Id = int.Parse(gameId),
        GameSets = new List<GameSet>()
    };
    
    var gameSets = line.Split(':')[1].Trim().Split(';');
    foreach (var set in gameSets)
    {
        var gameSet = new GameSet();
        var gameSetValues = set.Trim().Split(',');
        foreach (var value in gameSetValues)
        {
            var amount = int.Parse(value.Trim().Split(' ')[0]);
            var color = value.Trim().Split(' ')[1].Trim();
            switch (color)
            {
                case "red":
                    gameSet.Red = amount;
                    break;
                case "green":
                    gameSet.Green = amount;
                    break;
                case "blue":
                    gameSet.Blue = amount;
                    break;
            }
        }
        game.GameSets.Add(gameSet);
    }
    games.Add(game);
}

var sum = 0;

foreach (var game in games)
{
    var bagContents = new GameSet
    {
        Red = 12,
        Green = 13,
        Blue = 14
    };
    var addGame = true;
    
    foreach (var gameSet in game.GameSets)
    {
        if (
            gameSet.Red > bagContents.Red
            || gameSet.Green > bagContents.Green
            || gameSet.Blue > bagContents.Blue
            )
        {
            addGame = false;
            break;
        }
        
        // bagContents.Red -= gameSet.Red;
        // bagContents.Green -= gameSet.Green;
        // bagContents.Blue -= gameSet.Blue;
        
    }
    Console.WriteLine($"{game.Id} - {addGame}");
    if (addGame) sum += game.Id;
}

Console.WriteLine(sum);