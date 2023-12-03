namespace Day2;

public class Game
{
    public int Id { get; set; }
    public List<GameSet> GameSets { get; set; }
}

public class GameSet
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}