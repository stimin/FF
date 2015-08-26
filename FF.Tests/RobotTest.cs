using FF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FF.Tests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void OutOfBoundsMinusX()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "FLFFFFFFF";

            Assert.AreEqual("Failed: robot went out of bounds!", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void OutOfBoundsX()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "FRFFFFFFF";

            Assert.AreEqual("Failed: robot went out of bounds!", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void OutOfBoundsMinusY()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "FFFFFF";

            Assert.AreEqual("Failed: robot went out of bounds!", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void OutOfBoundsY()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "RRFFFFFFF";

            Assert.AreEqual("Failed: robot went out of bounds!", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void Rotations()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "RRRRRRRRLLLLLLLLRRLLRLRLRLRLRR";

            Assert.AreEqual("5 5 Down", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void RotateAndOneMove()
        {
            var wallSize = "10 10";
            var robotStart = "5 5 Up";
            var instructions = "RLRLRLRLFRLRLR";

            Assert.AreEqual("5 6 Right", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void LargeMovement()
        {
            var wallSize = "20 20";
            var robotStart = "0 0 Up";
            var instructions = "FFFFFFFFFFFFFFFFFFFRFFFFFFFFFFFFFFFFFFFRFFFFFFFFFFFFFFFFFFFRFFFFFFFFFFFFFFFFFFF";

            Assert.AreEqual("0 0 Left", TestForm(wallSize, robotStart, instructions));
        }

        [TestMethod]
        public void TopRightToBottomLeft()
        {
            var wallSize = "20 20";
            var robotStart = "19 19 Up";
            var instructions = "LFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLF";

            Assert.AreEqual("0 0 Down", TestForm(wallSize, robotStart, instructions));
        }

        private string TestForm(string wallSize, string robotStart, string instructions)
        {
            var wall = new Wall(wallSize);
            var robot = new Robot(wall, robotStart);
            var output = robot.Run(instructions);

            return output;
        }
    }
}
