using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class GetRoversPosition
    {
        private int X_Coordinate { get; set; }
        private int Y_Coordinate { get; set; }
        private string Direction { get; set; }
        private InputLines InputLines { get; set; }
        StringBuilder PositionBuilder { get; set; }
        string[] MaxCoordinatesArr { get; set; }

        public GetRoversPosition()
        {
            Direction = Constants.North;
            X_Coordinate = 0;
            Y_Coordinate = 0;
        }

        public string GetPosition(string[] linesArr)
        {
            string position = string.Empty;
            InputLines = GetInputValues(linesArr);
            if (InputLines == null) return position;
            if (InputLines.RoversInfoList != null && InputLines.RoversInfoList.Count > 0)
            {
                position = TurnAndMove();
            }
            else
            {
                position = X_Coordinate.ToString() + " " + Y_Coordinate.ToString() + " " + Direction;
            }
            ValidatePosition(position.Split(new[] {"\n" }, StringSplitOptions.None));
            return position;
        }

        private InputLines GetInputValues(string[] linesArr)
        {
            RoversInfo roversInfo = null;
            List<RoversInfo> roversInfoList = new List<RoversInfo>();
            if (linesArr != null && linesArr.Length > 0)
            {
                InputLines = new InputLines
                {
                    MaxCoordinates = linesArr[0]
                };
                ValidateMaxCoordinates();
                if (linesArr.Length == 2)
                {
                    //if input has two lines, first is max coordinates second is the position
                    roversInfoList.Add(new RoversInfo() { Position = linesArr[1], Instruction = string.Empty });
                }
                else
                {
                    //if input has more than two lines, it has max coordinates, position, directions
                    for (int i = 0; i <= linesArr.Length - 2; i = i + 2)
                    {
                        if (!string.IsNullOrEmpty(linesArr[i + 1]) && !string.IsNullOrEmpty(linesArr[i + 2]))
                        {
                            roversInfo = new RoversInfo
                            {
                                Position = linesArr[i + 1],
                                Instruction = linesArr[i + 2]
                            };
                            ValidatePosition(roversInfo.Position);
                            roversInfoList.Add(roversInfo);
                        }
                        else if(!string.IsNullOrEmpty(linesArr[i + 1]) && string.IsNullOrEmpty(linesArr[i + 2]))
                        {
                            roversInfoList.Add(new RoversInfo() { Position = linesArr[i+1], Instruction = string.Empty });
                        }
                    }
                }
                if (roversInfoList != null)
                {
                    InputLines.RoversInfoList = roversInfoList;
                }
            }
            return InputLines;
        }
        
        private string TurnAndMove()
        {
            string position = string.Empty;
            List<string> InstructionsList = new List<string>();
            string[] positionArr = null;
            char[] instructionArr = null;
            PositionBuilder = new StringBuilder();

            foreach (RoversInfo rovers in InputLines.RoversInfoList)
            {
                if (rovers.Position != null)
                {
                    positionArr = rovers.Position.Split();
                }
                if (rovers.Instruction != null)
                {
                    instructionArr = rovers.Instruction.ToCharArray();
                }
                //set position
                if (positionArr != null && positionArr.Length == 3)
                {
                    X_Coordinate = Convert.ToInt32(positionArr[0]);
                    Y_Coordinate = Convert.ToInt32(positionArr[1]);
                    Direction = Convert.ToString(positionArr[2]);
                }
                if (instructionArr != null)
                {
                    for (int i = 0; i < instructionArr.Length; i++)
                    {
                        switch (instructionArr[i].ToString())
                        {
                            case Constants.Right:
                                TurnRight(Direction);
                                break;
                            case Constants.Left:
                                TurnLeft(Direction);
                                break;
                            case Constants.Move:
                                MoveForward(Direction);
                                break;
                            default:
                                break;
                        }
                    }
                }
                position = GetOutputPosition();
            }
            return position;
        }
        
        private void TurnRight(string direction)
        {
            switch (direction)
            {
                case Constants.East:
                    Direction = Constants.South;
                    break;
                case Constants.South:
                    Direction = Constants.West;
                    break;
                case Constants.West:
                    Direction = Constants.North;
                    break;
                case Constants.North:
                    Direction = Constants.East;
                    break;
                default:
                    break;
            }
        }

        private void TurnLeft(string direction)
        {
            switch (direction)
            {
                case Constants.East:
                    Direction = Constants.North;
                    break;
                case Constants.South:
                    Direction = Constants.East;
                    break;
                case Constants.West:
                    Direction = Constants.South;
                    break;
                case Constants.North:
                    Direction = Constants.West;
                    break;
                default:
                    break;
            }
        }

        private void MoveForward(string direction)
        {
            switch (direction)
            {
                case Constants.East:
                    X_Coordinate = X_Coordinate + 1;
                    break;
                case Constants.South:
                    Y_Coordinate = Y_Coordinate - 1;
                    break;
                case Constants.West:
                    X_Coordinate = X_Coordinate - 1;
                    break;
                case Constants.North:
                    Y_Coordinate = Y_Coordinate + 1;
                    break;
                default:
                    break;
            }
        }

        private string GetOutputPosition()
        {
            PositionBuilder.Append(X_Coordinate);
            PositionBuilder.Append(" ");
            PositionBuilder.Append(Y_Coordinate);
            PositionBuilder.Append(" ");
            PositionBuilder.Append(Direction);
            PositionBuilder.Append("\n");
            return PositionBuilder.ToString().Substring(0, PositionBuilder.Length - 1);
        }

        private void ValidateMaxCoordinates()
        {
            MaxCoordinatesArr = InputLines.MaxCoordinates.Split();
            if (MaxCoordinatesArr == null)
            {
                throw new Exception(Constants.MaxCoordinatesCannotBeNull);
            }
            if (MaxCoordinatesArr.Length != 2)
            {
                throw new Exception(Constants.MaxCoordinatesHaveTwoCoordinates);
            }
            if (MaxCoordinatesArr != null && MaxCoordinatesArr.Length == 2)
            {
                if (Convert.ToInt32(MaxCoordinatesArr[0]) < 0 || Convert.ToInt32(MaxCoordinatesArr[1]) < 0)
                {
                    throw new Exception(Constants.MaxCoordinatesCannotBeSmallerThanZero);
                }
            }
        }

        private void ValidatePosition(string position)
        {
            string[] PositionArr = position.Split();
            if (PositionArr != null && PositionArr.Length < 3)
            {
                throw new Exception(Constants.PositionMustHaveThreeElements);
            }
            if (PositionArr != null && PositionArr.Length == 3)
            {
                if (!PositionArr[2].Equals(Constants.East) && !PositionArr[2].Equals(Constants.West)
                   && !PositionArr[2].Equals(Constants.South) && !PositionArr[2].Equals(Constants.North))
                {
                    throw new Exception(Constants.DirectionCodes);
                }
                if (Convert.ToInt32(PositionArr[0]) > Convert.ToInt32(MaxCoordinatesArr[0])
                    || Convert.ToInt32(PositionArr[1]) > Convert.ToInt32(MaxCoordinatesArr[1]))
                {
                    throw new Exception(Constants.PositionMustSmallerThanMaxCoordinates);
                }
                if (Convert.ToInt32(PositionArr[0]) < 0 || Convert.ToInt32(PositionArr[1]) < 0)
                {
                    throw new Exception(Constants.PositionCannotBeSmallerThanZero);
                }
            }
        }

        private void ValidatePosition(string[] positionArr)
        {
            for(int i = 0; i<positionArr.Length; i++)
            {
                ValidatePosition(positionArr[i]);
            }
        }
    }
}