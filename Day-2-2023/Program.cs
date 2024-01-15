// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using Day2_BLL;


string[] lines = File.ReadAllLines(@"D:\Fontys\AdventOfCode\Day-2-2023\Day-2-2023\input.txt");

SnowIsland snowIsland = new SnowIsland();
snowIsland.SetGames(lines);

IEnumerable<Game> games = snowIsland.GetPossibleGames();
int sumOfGameIds = games.Sum(game => game.Id);
Console.WriteLine($"Sum of Game IDs: {sumOfGameIds}");

int sumOfPowers = snowIsland.GetPowerFromGameSet();
Console.WriteLine($"Sum of Game Powers: {sumOfPowers}");