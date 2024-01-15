namespace Day2_BLL;

public class SnowIsland
{
    private readonly List<Game> _games = new();
    
    public void SetGames(string[] gameLines)
    {
        foreach (string gameLine in gameLines)
        {
            Game game = new Game();
            game.ParseGame(gameLine);
            
            _games.Add(game);
        }
    }

    public IEnumerable<Game> GetPossibleGames()
    {
        return (from game in _games let allSetsArePossible = game.CheckIfGameSetsArePossible() where allSetsArePossible select game).ToList();
    }

    public int GetPowerFromGameSet()
    {
        List<GameSet?> gameSetsWithFewestCubeAmount = GetGameSetWithFewestCubeAmountNeeded();
        List<int> powerGameSets = new();

        if (gameSetsWithFewestCubeAmount.Count != 0)
        {
            powerGameSets.AddRange(gameSetsWithFewestCubeAmount.Select(gameSet => gameSet!.RedCubes * gameSet.GreenCubes * gameSet.BlueCubes));
        }

        return powerGameSets.Sum();
    }

    private List<GameSet?> GetGameSetWithFewestCubeAmountNeeded()
    {
        return _games.Select(game => game.GetGameSetWithFewestCubeAmountNeeded()).Where(gameSet => gameSet != null).ToList();
    }
}