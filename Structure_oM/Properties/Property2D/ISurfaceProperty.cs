using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structure.Properties.Surface
{
    /// <summary>
    /// Property2D for 2D finite element structural objects such as PanelPlanar or MeshFace
    /// </summary>
    public interface ISurfaceProperty : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        Material Material { get; set; }

        /***************************************************/
    }    
}
