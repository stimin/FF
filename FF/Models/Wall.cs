using System.Linq;

namespace FF.Models
{
    public class Wall
    {
        private int X { get; set; }
        private int Y { get; set; }
        public bool Valid { get; set; }
        
        public Wall(string wallSize)
        {
            if (wallSize != null)
            {
                var walls = wallSize.Split(' ');

                // Ensure we have an x and y value
                if (walls.Count() == 2)
                {
                    int x;
                    int y;
                    // Ensure both are positive integers
                    if (int.TryParse(walls[0], out x) && int.TryParse(walls[1], out y))
                    {
                        if (x >= 0 && y >= 0)
                        {
                            X = x;
                            Y = y;
                            Valid = true;
                        }
                    }
                }
            }
        }

        public bool WithinWalls(int x, int y)
        {
            var withinWalls = false;

            // Make sure wall has been set before checking values
            if (X != -1 && Y != -1)
            {
                // Check co-ordinates are within wall
                if (x >= 0 && x < X && y >= 0 && y < Y)
                {
                    withinWalls = true;
                }
            }

            return withinWalls;
        }
    }
}