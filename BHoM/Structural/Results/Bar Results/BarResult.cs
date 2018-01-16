using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
{
    public class BarResult : IStructuralResult
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


        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            BarResult otherBar = other as BarResult;

            if (otherBar == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherBar.ObjectId);
            if (n == 0)
            {
                int l = this.LoadCase.CompareTo(otherBar.LoadCase);
                if (l == 0)
                {
                    int f = this.Position.CompareTo(otherBar.Position);
                    return f == 0 ? this.TimeStep.CompareTo(otherBar.TimeStep) : f;
                }
                else
                {
                    return l;
                }
            }
            else
            {
                return n;
            }

        }

    }
}
