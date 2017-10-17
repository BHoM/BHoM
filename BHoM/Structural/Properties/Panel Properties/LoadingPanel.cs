using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Properties
{
    public enum LoadPanelSupportConditions
    {
        AllSides,
        ThreeSides,
        TwoSides,
        TwoAdjacentSides,
        OneSide,
        Cantilever
    }

    public class LoadingPanelProperty : PanelProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadPanelSupportConditions LoadApplication { get; set; }

        public int ReferenceEdge { get; set; } = 1;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LoadingPanelProperty() { }
    }
}
