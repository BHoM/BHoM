using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Materials;

namespace BH.oM.Structural.Properties
{
    public abstract class Reinforcement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Diameter { get; set; }
        public int BarCount { get; set; }

        public Material Material { get; set; }

        //[DisplayName("StartLocation")]
        //[Description("location of the beginning of the reinforcement as a ratio of the bar length")]
        public double StartLocation { get; set; } = 0;

        //[DisplayName("EndLocation")]
        //[Description("location of the end of the reinforcement as a ratio of the bar length")]
        public double EndLocation { get; set; } = 1;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Reinforcement() { }

        /***************************************************/

        public Reinforcement(double diameter, int barCount)
        {
            Diameter = diameter;
            BarCount = barCount;
        }





        //public abstract bool IsLongitudinal();

        ///***************************************************/

        //public abstract IBHoMGeometry GetLayout(ConcreteSection property, bool extrude = false);

        ///***************************************************/

        //public virtual List<double> Location(ConcreteSection property, double location, double axis)
        //{
        //    List<double> result = new List<double>();
        //    if (location >= StartLocation && location <= EndLocation)
        //    {
        //        GeometryGroup<Point> geom = GetLayout(property, false) as GeometryGroup<Point>;
        //        foreach (Point p in geom.Elements)
        //        {
        //            if (axis == 0)
        //            {
        //                result.Add(p.X);
        //            }
        //            else
        //            {
        //                result.Add(p.Y);
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
