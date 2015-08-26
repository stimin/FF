using System.Linq;

namespace FF.Models
{
    public class Robot
    {
        private int X { get; set; }
        private int Y { get; set; }
        private string Orientation { get; set; } 
        private string Instruction { get; set; }
        private Wall Wall { get; set; }
        public bool Valid { get; set; }

        public Robot (Wall wall, string startPosition)
        {
            // Wall must be valid for us to set the robot
            if (wall != null && wall.Valid && startPosition != null)
            {
                var startValues = startPosition.Split(' ');

                // Ensure we have 3 values
                if (startValues.Count() == 3)
                {
                    int x;
                    int y;
                    // Ensure both are positive integers
                    if (int.TryParse(startValues[0], out x) && int.TryParse(startValues[1], out y))
                    {
                        // Check co-ordinates are valid and orientataion is valid
                        if (x >= 0 && y >= 0 
                            && wall.WithinWalls(x, y) 
                            && IsDirectionValid(startValues[2]))
                        {
                            X = x;
                            Y = y;
                            Orientation = startValues[2];
                            Wall = wall;
                            Valid = true;
                        }
                    }
                }
            }
        }

        public string Run(string instruction)
        {
            string output = "";
            var instructionList = instruction.ToLower().ToList();

            foreach(var movement in instructionList)
            {
                switch (movement)
                {
                    case 'l':
                    case 'r':
                        Turn(movement);
                        break;
                    case 'f':
                        Forward();
                        break;
                }

                if (!Wall.WithinWalls(X, Y))
                {
                    // If not within walls, set message and break out of loop
                    output = "Failed: robot went out of bounds!";
                    break;
                }
            }

            // If not out of bounds then return final position
            if (output == "")
            {
                output = X + " " + Y + " " + Orientation;
            }

            return output;
        }

        private bool IsDirectionValid(string direction)
        {
            var valid = false;

            switch (direction.ToLower())
            {
                case "left":
                case "right":
                case "up":
                case "down":
                    valid = true;
                    break;
            }

            return valid;
        }

        private void Turn(char direction)
        {
            switch (Orientation.ToLower())
            {
                case "left":
                    if (direction == 'l')
                    {
                        Orientation = "Down";
                    }
                    else
                    {
                        Orientation = "Up";
                    }
                    break;
                case "right":
                    if (direction == 'l')
                    {
                        Orientation = "Up";
                    }
                    else
                    {
                        Orientation = "Down";
                    }
                    break;
                case "up":
                    if (direction == 'l')
                    {
                        Orientation = "Left";
                    }
                    else
                    {
                        Orientation = "Right";
                    }
                    break;
                case "down":
                    if (direction == 'l')
                    {
                        Orientation = "Right";
                    }
                    else
                    {
                        Orientation = "Left";
                    }
                    break;
            }
        }

        private void Forward()
        {
            switch (Orientation.ToLower())
            {
                case "left":
                    X--;
                    break;
                case "right":
                    X++;
                    break;
                case "up":
                    Y++;
                    break;
                case "down":
                    Y--;
                    break;
            }
        }
    }
}