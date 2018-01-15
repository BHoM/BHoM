using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structural.Results
{
    public class BarResult : IObjectResult, IStructuralResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ModelDescription { get; set; } = "";

        public string ObjectId { get; set; } = "";

        public string LoadCase { get; set; } = "";

        public double TimeStep { get; set; } = 0.0;

        public double Position { get; set; } = 0.0;

        public int Divisions { get; set; } = 1;
    }
}
