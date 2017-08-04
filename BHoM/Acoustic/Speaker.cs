
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Speaker : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Position { get; set; } = new Point();

        public Vector Direction { get; set; } = new Vector();

        public string Category { get; set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Speaker() { }

        /***************************************************/

        public Speaker(Point pos, Vector dir, string category = "")
        {
            Position = pos;
            Direction = dir;
            Category = category;
        }
  
    }
}




//public static double GetGainAngleFactor(double angle, double octave)
//{
//    return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
//}