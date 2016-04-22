using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BHoM.Geometry.Point startPoint = new BHoM.Geometry.Point(0, 0, 0);
            BHoM.Geometry.Point endPoint = new BHoM.Geometry.Point(1, 1, 1);
            BHoM.Geometry.Line line = new BHoM.Geometry.Line(startPoint, endPoint);

            BHoM.Global.Project project = new BHoM.Global.Project();
            BHoM.Structural.GridFactory gridFactory = new BHoM.Structural.GridFactory(project);
            BHoM.Structural.Grid grid = gridFactory.Create(line, "testGrid");

            string json = grid.JSON();
            BHoM.Structural.Grid newGrid = gridFactory.Create(json);
        }
    }
}
