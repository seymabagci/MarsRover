using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover
{
    public class Constants
    {
        public const string North = "N";
        public const string South = "S";
        public const string East = "E";
        public const string West = "W";
               
        public const string Right = "R";
        public const string Left = "L";
        public const string Move = "M";

        public const string MaxCoordinatesCannotBeNull = "Max Coordinates can not be null";
        public const string MaxCoordinatesHaveTwoCoordinates = "Max Coordinates must have 2 coordinates";
        public const string MaxCoordinatesCannotBeSmallerThanZero = "Max Coordinates can not be smaller than 0";
        public const string PositionMustHaveThreeElements = "Position must have 3 elements which are 2 coordinates and a direction";
        public const string DirectionCodes = "Direction must be one of the S, N, W or E codes";
        public const string PositionMustSmallerThanMaxCoordinates = "Position coordinates can not be larger than max coordinates";
        public const string PositionCannotBeSmallerThanZero = "Position coordinates can not be smaller than 0";
    }
}