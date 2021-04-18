using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;

namespace CubeRun.Model
{
    public class Cube
    {
        //                90`
        //                |
        //               \/
        //            |-----|
        //            | cube| <-- 0` 
        //            |-----|

        public Edge Edge
        {
            get => activeEdge;
            private set => activeEdge = value;
        }

        public Point Position
        {
            get => position;
            private set => position = value;
        }

        public int Angle
        {
            get => angle;
            private set => angle = Math.Abs(value % 360);
        }

        private readonly Map map;
        private int angle; //in degrees
        private Point position;
        private Edge activeEdge = Edge.Down;

        public Cube(Map map)
        {
            this.map = map;
        }

        public void Jump()
        {
            Edge = (Edge) new Random().Next(0, 3);
            Position += new Size(0, 10);
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Down(Edge);
                    break;
                }

                Run();
                Angle += 10;
                Thread.Sleep(500);
            }
        }

        public void Run()
        {
            Position += new Size(1, 0);
        }

        private void Down(Edge edge)
        {
            Position = map.GetFloor(Position.X) ?? map.Start;
            var currentEdge = GetCurrentEdge();

            if (edge != currentEdge)
            {
                Destroy();
            }
        }

        private Edge GetCurrentEdge()
        {
            var currentEdge = Edge.Down;
            if (Angle >= 315 || Angle <= 45)
            {
                currentEdge = Edge.Right;
            }
            else if (Angle > 45 && Angle <= 135)
            {
                currentEdge = Edge.Up;
            }
            else if (Angle > 135 && Angle <= 225)
            {
                currentEdge = Edge.Left;
            }

            return currentEdge;
        }

        private void Destroy()
        {
            Position = new Point(0, 0); //map start position
        }
    }

    public enum Edge
    {
        Up,
        Down,
        Right,
        Left
    }
}