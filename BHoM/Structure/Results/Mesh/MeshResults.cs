using System.ComponentModel;
using BH.oM.Common;
using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base;
using System.Collections.ObjectModel;
using System;

namespace BH.oM.Structure.Results
{
    public class MeshResults : IResultCollection, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IComparable ObjectId { get; } = "";

        public MeshResultLayer Layer { get;} 

        [Description("Position within the element thickness that result is extracted from, normalised to 1. 0 = lower surface, 0.5 = middle, 1 = top surface")]
        public double LayerPosition { get; }

        public MeshResultSmoothingType Smoothing { get;  }

        public ReadOnlyCollection<MeshResult> MeshResultCollection { get; }       

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshResults(IComparable objectId, MeshResultLayer resultLayer, MeshResultSmoothingType smoothing, ReadOnlyCollection<MeshResult> meshResultCollection)
        {
            Layer = resultLayer;
            LayerPosition = LayerPosition;
            Smoothing = smoothing;
            MeshResultCollection = meshResultCollection;
        }

        /***************************************************/

    }
}
