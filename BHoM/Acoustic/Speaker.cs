using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BHoM.Base;
using BHG = BHoM.Geometry;

namespace BHoM.Acoustic
{
    public class Speaker : BHB.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BHG.Point Position { get; set; } = new BHG.Point();

        public BHG.Vector Direction { get; set; } = new BHG.Vector();

        public string Category { get; set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Speaker() { }

        /***************************************************/

        public Speaker(BHG.Point pos, BHG.Vector dir, string category)
        {
            Position = pos;
            Direction = dir;
            Category = category;
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public double GetGainAngleFactor(double angle, double octave) 
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }
    }
}