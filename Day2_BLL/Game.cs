namespace Day2_BLL;

public class Game
{
    private static int _lastAssignedId;
    private const int MaxAmountRedCubes = 12;
    private const int MaxAmountGreenCubes = 13;
    private const int MaxAmountBlueCubes = 14;

    public int Id { get; private set; }
    private readonly List<GameSet> _gameSets = new();

    public Game()
    {
        Id = ++_lastAssignedId;
    }

    public void ParseGame(string gameData)
    {
        int colonIndex = GetColonIndex(gameData);

        if (colonIndex != -1)
        {
            string gameString = ExtractGameData(gameData, colonIndex);
            string[] setsData = gameString.Split(';');

            foreach (string setString in setsData)
            {
                GameSet gameSet = ParseGameSet(setString);
                _gameSets.Add(gameSet);
            }
        }
    }

    private GameSet ParseGameSet(string setString)
    {
        GameSet gameSet = new GameSet();
        string[] colorCounts = setString.Split(',');

        foreach (string colorCount in colorCounts)
        {
            ParseColorCounts(gameSet, colorCount);
        }

        return gameSet;
    }

    private static void ParseColorCounts(GameSet gameSet, string colorCount)
    {
        string[] parts = colorCount.Trim().Split(' ');

        if (parts.Length == 2)
        {
            int numericValue = int.Parse(parts[0]);
            string color = parts[1].ToLower();

            AssignValueToColor(gameSet, numericValue, color);
        }
    }

    private static void AssignValueToColor(GameSet gameSet, int numericValue, string color)
    {
        switch (color)
        {
            case "red":
                gameSet.SetRedCubes(numericValue);
                break;
            case "green":
                gameSet.SetGreenCubes(numericValue);
                break;
            case "blue":
                gameSet.SetBlueCubes(numericValue);
                break;
        }
    }

    private static int GetColonIndex(string data)
    {
        return data.IndexOf(':');
    }

    private static string ExtractGameData(string data, int colonIndex)
    {
        return data[(colonIndex + 1)..];
    }

    public bool CheckIfGameSetsArePossible()
    {
        return _gameSets.All(CheckIfSetIsPossible);
    }

    private static bool CheckIfSetIsPossible(GameSet gameSet)
    {
        return gameSet.RedCubes <= MaxAmountRedCubes && gameSet is { GreenCubes: <= MaxAmountGreenCubes, BlueCubes: <= MaxAmountBlueCubes };
    }

    public GameSet? GetGameSetWithFewestCubeAmountNeeded()
    {
        if (_gameSets.Count == 0)
        {
            return null;
        }

        GameSet gameSet = new();
        gameSet.SetRedCubes(_gameSets.Max(gs => gs.RedCubes));
        gameSet.SetGreenCubes(_gameSets.Max(gs => gs.GreenCubes));
        gameSet.SetBlueCubes(_gameSets.Max(gs => gs.BlueCubes));
        
        return gameSet;
    }
}