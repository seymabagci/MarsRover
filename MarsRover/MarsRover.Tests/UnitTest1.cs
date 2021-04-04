using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRover.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetPosition_With_Null_Input_Should_Return_Null()
        {
            string[] input = null;
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, string.Empty);
        }

        [TestMethod]
        public void GetPosition_With_No_Position_Stay_Start_Point()
        {
            string[] input = new string[] { "5 5" };
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, "0 0 N");
        }

        [TestMethod]
        public void GetPosition_With_No_Direction_Stay_First_Position()
        {
            string[] input = new string[] { "5 5", "1 2 N" };
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, "1 2 N");
        }

        [TestMethod]
        public void GetPosition_First_Rover_Should_Return_13N()
        {
            string[] input = new string[] { "5 5", "1 2 N", "LMLMLMLMM" };
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, "1 3 N");
        }

        [TestMethod]
        public void GetPosition_Second_Rover_Should_Return_51E()
        {
            string[] input = new string[] { "5 5", "3 3 E", "MMRMMRMRRM" };
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, "5 1 E");
        }

        [TestMethod]
        public void GetPosition_More_Than_Two_Rover()
        {
            string[] input = new string[] { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM", "2 1 S", "LMLLMRMRLMM" };
            string result = new GetRoversPosition().GetPosition(input);
            Assert.AreEqual(result, "1 3 N\n5 1 E\n2 4 N");
        }
    }
}