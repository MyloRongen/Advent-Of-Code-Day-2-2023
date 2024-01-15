namespace Day2_BLL;

public class GameSet
{
    public int RedCubes { get; private set; }
    public int GreenCubes { get; private set; }
    public int BlueCubes { get; private set; }

    public void SetRedCubes(int redCubes)
    {
        RedCubes = redCubes;
    }
    
    public void SetGreenCubes(int greenCubes)
    {
        GreenCubes = greenCubes;
    }
    
    public void SetBlueCubes(int blueCubes)
    {
        BlueCubes = blueCubes;
    }
}