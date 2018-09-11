using BH.oM.Common;
using BH.oM.Geometry;

namespace BH.oM.Structure.Results
{
    public abstract class MeshResult 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ObjectId { get; set; } = "";
        
        public CoordinateSystem CoordinateSystem { get; set; } = null;

        public MeshResultType PanelResultLayer { get; set; } = MeshResultType.AbsoluteMaximum;

        public MeshResultSmoothingType PanelResultSmoothingType { get; set; } = MeshResultSmoothingType.None;
       
        /***************************************************/
    }
}
