using BH.oM.Base;
using BH.oM.Common.Materials;

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

        public double StartLocation { get; set; } = 0;  // location of the beginning of the reinforcement as a ratio of the bar length

        public double EndLocation { get; set; } = 1; // location of the end of the reinforcement as a ratio of the bar length


        /***************************************************/
    }
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

