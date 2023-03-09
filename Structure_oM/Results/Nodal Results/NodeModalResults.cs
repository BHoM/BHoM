using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.Results.Nodal_Results
{
    public class NodeModalResults : NodeResult, INodeDisplacement, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Translational X component of the mode shape in global coordinates.")]
        public virtual double UX { get; }

        [Description("Translational Y component of the mode shape in global coordinates.")]
        public virtual double UY { get; }

        [Description("Translational Z component of the mode shape in global coordinates.")]
        public virtual double UZ { get; }

        [Description("Rotational component about the X-axis of the mode shape in global coordinates.")]
        public virtual double RX { get; }

        [Description("Rotational component about the Y-axis of the mode shape in global coordinates.")]
        public virtual double RY { get; }

        [Description("Rotational component about the Z-axis of the mode shape in global coordinates.")]
        public virtual double RZ { get; }

        [Mass]
        [Description("Nodal modal mass in the X-direction as defined by orientation basis. Proportional amount of the total modal mass that acts in the X-direction at the specific Node.")]
        public virtual double NodalMassX { get; }

        [Mass]
        [Description("Nodal modal mass in the Y-direction as defined by orientation basis. Proportional amount of the total modal mass that acts in the Y-direction at the specific Node.")]
        public virtual double NodalMassY { get; }

        [Mass]
        [Description("Nodal modal mass in the Z-direction as defined by orientation basis. Proportional amount of the total modal mass that acts in the Z-direction at the specific Node.")]
        public virtual double NodalMassZ { get; }

        [Mass]
        [Description("Nodal modal mass in the X-direction as defined by orientation basis. Proportional amount of the total modal mass that acts around the X-axis at the specific Node.")]
        public virtual double NodalRotationalMassX { get; }

        [Mass]
        [Description("Nodal modal mass in the Y-direction as defined by orientation basis. Proportional amount of the total modal mass that acts around the X-axis at the specific Node.")]
        public virtual double NodalRotationalMassY { get; }

        [Mass]
        [Description("Nodal modal mass in the Z-direction as defined by orientation basis. Proportional amount of the total modal mass that acts around the X-axis at the specific Node.")]
        public virtual double NodalRotationalMassZ { get; }

        [Description("States if the result has been normalised based on the Eigenvector or on the Mass.")]
        public virtual ModalResultNormalisation NormalisationProcedure { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NodeModalResults(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, Basis orientation, 
                            double ux, 
                            double uy, 
                            double uz, 
                            double rx, 
                            double ry, 
                            double rz, 
                            double nodalMassX,
                            double nodalMassY,
                            double nodalMassZ,
                            double nodalRotationalMassX,
                            double nodalRotationalMassY,
                            double nodalRotationalMassZ) :
            base(objectId, resultCase, modeNumber, timeStep, orientation)
        {
            UX = ux;
            UY = uy;
            UZ = uz;
            RX = rx;
            RY = ry;
            RZ = rz;
            NodalMassX = nodalMassX;
            NodalMassY = nodalMassY;
            NodalMassZ = nodalMassZ;
            NodalRotationalMassX = nodalRotationalMassX;
            NodalRotationalMassY = nodalRotationalMassY;
            NodalRotationalMassZ = nodalRotationalMassZ;
        }

        /***************************************************/
    }
}