using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structural.Properties
{
    /// <summary>
    /// Property2D for 2D finite element structural objects such as PanelPlanar or MeshFace
    /// </summary>
    public abstract class Property2D : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double[] Modifiers { get; set; } = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        public PanelType Type { get; set; }

        public double Thickness { get; set; }

        public Material Material { get; set; }

        /***************************************************/
    }    
}
