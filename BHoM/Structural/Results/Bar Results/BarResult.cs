using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;

namespace BH.oM.Structural.Results
{
    public abstract class BarResult : IStructuralResult
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
            BarResult otherRes = other as BarResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.LoadCase.CompareTo(otherRes.LoadCase);
                if (l == 0)
                {
                    int t = this.TimeStep.CompareTo(otherRes.TimeStep);
                    return t == 0 ? this.Position.CompareTo(otherRes.Position) : t;
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
