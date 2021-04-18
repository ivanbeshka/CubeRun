namespace CubeRun.Model
{
    public class Game
    {
        public readonly Map Map;
        public readonly Cube Cube;

        public Game(Map map)
        {
            Map = map;
            Cube = new Cube(map);
        }
    }
}