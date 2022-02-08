using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBoundCircle.Helper
{
    internal class RobotBoundCircleHelper
    {
        public bool IsRobotBounded(string instructions)
        {
            bool result = false;
            try
            {
                // L Left Side Anti clock wise
                // R Right side Clock Wise
                // G Move one step forward
                // Default will be (0,0) North direction
                // - X will east and X will be west
                // Y will be north and - Y will be South

                int xaxis = 0;
                int yaxis = 0;
                string direction = "N";

                char[] arrInst = instructions.ToCharArray();
                if (!arrInst.Contains('L') && !arrInst.Contains('R'))
                {
                    return false;
                }

            Found:

                foreach (char ins in arrInst)
                {
                    if (ins == 'G')
                    {
                        var axisDetails = AssistMove(xaxis, yaxis, direction);
                        if (axisDetails != null)
                        {
                            xaxis = axisDetails.Item1;
                            yaxis = axisDetails.Item2;
                        }
                    }
                    else if (ins == 'L' || ins == 'R')
                    {
                        direction = AssistMove(direction, ins);
                    }
                }

                if (xaxis == 0 && yaxis == 0)
                {
                    result = true;
                }
                else if (direction != "N")
                {
                    goto Found;
                }
                else
                {
                    result = false;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // G Move
        private Tuple<int, int> AssistMove(int xaxis, int yaxis, string direction)
        {
            switch (direction)
            {
                case "N":
                    yaxis++;
                    break;
                case "S":
                    yaxis--;
                    break;
                case "W":
                    xaxis++;
                    break;
                case "E":
                    xaxis--;
                    break;
            }
            return Tuple.Create(xaxis, yaxis);
        }

        // Assist Direction R and L
        private string AssistMove(string direction, char move)
        {
            if (move == 'R')
            {
                switch (direction)
                {
                    case "N":
                        direction = "W";
                        break;
                    case "S":
                        direction = "E";
                        break;
                    case "W":
                        direction = "S";
                        break;
                    case "E":
                        direction = "N";
                        break;
                }

            }
            else if (move == 'L')
            {
                switch (direction)
                {
                    case "N":
                        direction = "E";
                        break;
                    case "S":
                        direction = "W";
                        break;
                    case "W":
                        direction = "N";
                        break;
                    case "E":
                        direction = "S";
                        break;
                }

            }

            return direction;
        }
    }
}
