using RobotBoundCircle.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBoundCircle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RobotBoundCircleHelper robotBoundCircle = new RobotBoundCircleHelper();
            var result = robotBoundCircle.IsRobotBounded("GLGLGGLGL");
        }
    }
}
