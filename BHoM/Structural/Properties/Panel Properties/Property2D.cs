using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Property2D for 2D finite element structural objects such as PanelPlanar or MeshFace
    /// </summary>
    [Serializable]
    public abstract class Property2D : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double[] Modifiers { get; set; }
        public PanelType Type { get; set; }
        public double Thickness { get; set; }
        public Materials.Material Material { get; set; }
        public Property2D()
        {
            Modifiers = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public Property2D(string name) : this(){ Name = name; }

        public bool HasModifiers()
        {
            for (int i = 0; i < Modifiers.Length; i++)
            {
                if (Modifiers[i] != 1) return true;
            }
            return false;
        }
    }    
}
