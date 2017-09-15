using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class PanelFace
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int A { get; set; } = 0;

        public int B { get; set; } = 0;

        public int C { get; set; } = 0;

        public int D { get; set; } = -1;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PanelFace() { }

        /***************************************************/

        public PanelFace(int a, int b, int c, int d = -1)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }


        /***************************************************/
        /**** Local Optimisation Methods                ****/
        /***************************************************/

        public bool IsQuad()
        {
            return D != -1;
        }

    }
}


