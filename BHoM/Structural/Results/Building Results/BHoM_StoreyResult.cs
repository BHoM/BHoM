using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results.Building
{
    /// <summary>
    /// Results for building storeys for use in multi/tall building post processing
    /// </summary>
    public class StoreyResult
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; private set; }
      
        /// <summary>Storey drift in X (refer to ASCE7 for basis)</summary>
        public double DriftX { get; private set; }
        /// <summary>Storey drift in Y (refer to ASCE7 for basis)</summary>
        public double DriftY { get; private set; }

        /// <summary>Storey drift ratio in X (drift / storey height)</summary>
        public double DriftRatioX { get; private set; }
        /// <summary>Storey drift ratio in Y (drift / storey height)</summary>
        public double DriftRatioY { get; private set; }

        /// <summary>Maximum displacement in X of any point (node) in the story</summary>
        public double MaximumNodalDisplacementX { get; private set; }
        /// <summary>Maximum displacement in Y of any point (node) in the story</summary>
        public double MaximumNodalDisplacementY { get; private set; }

        /// <summary>Minimum displacement in X of any point (node) in the story</summary>
        public double MinimumNodalDisplacementX { get; private set; }
        /// <summary>Minimum displacement in Y of any point (node) in the story</summary>
        public double MinimumNodalDisplacementY { get; private set; }

        /// <summary>Storey shear in X</summary>
        public double ShearX { get; private set; }
        /// <summary>Storey shear in Y</summary>
        public double ShearY { get; private set; }

        /// <summary>Total shear force in X in storey columns</summary>
        public double ShearToColumnsX { get; private set; }
        /// <summary>Total shear force in Y in storey columns</summary>
        public double ShearToColumnsY { get; private set; }
        /// <summary>Total shear force in X in storey walls</summary>
        public double ShearToWallsX { get; private set; }
        /// <summary>Total shear force in Y in storey walls</summary>
        public double ShearToWallsY { get; private set; }

        /// <summary>Total axial force in columns at level</summary>
        public double AxialToColumns { get; private set; }
        /// <summary>Total axial force in walls at level</summary>
        public double AxialToWalls { get; private set; }

        /// <summary>Mass of storey used in seismic calculation</summary>
        public BHoM.Geometry.Vector SeismicMass { get; private set; }

        /// <summary>Centre of rigidity of the storey</summary>
        public BHoM.Geometry.Point CentreOfRigidity { get; private set; }
        /// <summary>Centre of mass of the storey</summary>
        public BHoM.Geometry.Point CentreOfGravity { get; private set; }

        /// <summary>Eccentricity of the storey (vector distance between COG and COR)</summary>
        public BHoM.Geometry.Vector Eccentricity { get; private set; }

        /// <summary>Moment of inertia of a storey</summary>
        public BHoM.Geometry.Vector MomentOfInertia { get; private set; }

        
        /// <summary>
        /// Constructs an empty storey result and set the objects later
        /// </summary>
        public StoreyResult()
        {
        }

        /// <summary>
        /// Constructs a storey result using a BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public StoreyResult(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }  

        /// <summary>
        /// Sets the loadcase by using an existing BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public void SetLoadcase(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }

        /// <summary>
        /// Set storey drifts
        /// </summary>
        /// <param name="driftX"></param>
        /// <param name="driftY"></param>
        public void SetDrift(double driftX, double driftY)
        {
            this.DriftX = driftX;
            this.DriftY = driftY;
        }

        /// <summary>
        /// Sets storey drift ratios
        /// </summary>
        /// <param name="driftRatioX"></param>
        /// <param name="driftRatioY"></param>
        public void SetDriftRatio(double driftRatioX, double driftRatioY)
        {
            this.DriftRatioX = driftRatioX;
            this.DriftRatioY = driftRatioY;
        }

        /// <summary>
        /// Sets the maximum nodal displacements for a given storey
        /// (maximum nodal translations)
        /// </summary>
        /// <param name="maxUX"></param>
        /// <param name="maxUY"></param>
        public void SetMaximumNodalDisplacements(double maxUX, double maxUY)
        {
            this.MaximumNodalDisplacementX = maxUX;
            this.MaximumNodalDisplacementY = maxUY;
        }

        /// <summary>
        /// Sets the Minimum nodal displacements for a given storey
        /// (Minimum nodal translations)
        /// </summary>
        /// <param name="minUX"></param>
        /// <param name="minUY"></param>
        public void SetMinimumNodalDisplacements(double minUX, double minUY)
        {
            this.MinimumNodalDisplacementX = minUX;
            this.MinimumNodalDisplacementY = minUY;
        }

        /// <summary>
        /// Sets storey shears
        /// </summary>
        /// <param name="shearX"></param>
        /// <param name="shearY"></param>
        public void SetShear(double shearX, double shearY)
        {
            this.ShearX = shearX;
            this.ShearY = shearY;
        }

        /// <summary>
        /// Sets the total shear forces in walls and columns for a given storey
        /// (to show relative distribution)
        /// </summary>
        /// <param name="shearToColumnsX"></param>
        /// <param name="shearToColumnsY"></param>
        /// <param name="shearToWallsX"></param>
        /// <param name="shearToWallsY"></param>
        public void SetShearDistribution(double shearToColumnsX, double shearToColumnsY, double shearToWallsX, double shearToWallsY)
        {
            this.ShearToColumnsX = shearToColumnsX;
            this.ShearToColumnsY = shearToColumnsY;
            this.ShearToWallsX = shearToWallsX;
            this.ShearToWallsY = ShearToWallsY;
        }

        /// <summary>
        /// Sets the total axial forces in walls and columns for a given storey
        /// (to show relative distribution)
        /// </summary>
        /// <param name="axialToColumns"></param>
        /// <param name="axialToWalls"></param>
        public void SetAxialDistribution(double axialToColumns, double axialToWalls)
        {
            this.AxialToColumns = axialToColumns;
            this.AxialToWalls = AxialToWalls;
        }

        /// <summary>
        /// Sets the seismic mass for a given storey by constructing a BHoM
        /// vector object
        /// </summary>
        /// <param name="massX"></param>
        /// <param name="massY"></param>
        /// <param name="massZ"></param>
        public void SetSeismicMass(double massX, double massY, double massZ)
        {
            this.SeismicMass = new BHoM.Geometry.Vector(massX, massY, massZ);
        }

        /// <summary>
        /// Sets the centre of rigidity of a given storey by constructing 
        /// a BHoM point object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetCentreOfRigidity(double x, double y, double z)
        {
            this.CentreOfRigidity = new BHoM.Geometry.Point(x, y, z);
        }

        /// <summary>
        /// Sets the centre of gravity of a given storey by constructing
        /// a BHoM point object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetCentreOfGravity(double x, double y, double z)
        {
            this.CentreOfGravity = new BHoM.Geometry.Point(x, y, z);
        }

        /// <summary>
        /// Sets the eccentricity (distance between COG and COR) for a
        /// given storey by constructing a BHoM vector object
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="ey"></param>
        /// <param name="ez"></param>
        public void SetEccentricity(double ex, double ey, double ez)
        {
            this.Eccentricity = new BHoM.Geometry.Vector(ex, ey, ez);
        }

        /// <summary>
        /// Set the moment of inertia
        /// </summary>
        /// <param name="ix"></param>
        /// <param name="iy"></param>
        /// <param name="iz"></param>
        public void SetMomentOfIntertia(double ix, double iy, double iz)
        {
            this.MomentOfInertia = new BHoM.Geometry.Vector(ix, iy, iz);
        }
    }
}
