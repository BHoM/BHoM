using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    /// <summary>
    /// This class is used to collect and inspect results for a 
    /// whole structure for sanity checks - global reactions, mass sums, shears etc
    /// </summary>
    public class GlobalResult
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; private set; }

        /// <summary>Base shear force in X direction (reacion in X as a percentage of total mass)</summary>
        public double BaseShearX {get; private set;}
        /// <summary>Base shear force in Y direction (reaction in Y as a percentage of total mass)</summary>
        public double BaseShearY { get; private set; }

        /// <summary>Sum of reactions (X, Y, Z) as vector</summary>
        public BHoM.Geometry.Vector SumOfReactions_F {get; private set;}

        /// <summary>Sum of reactions (MX, MY, MZ) as vector</summary>
        public BHoM.Geometry.Vector SumOfReactions_M { get; private set; }

        /// <summary>Sum of modal masses as vector</summary>
        public double SumOfMass { get; private set; }

        /// <summary>Constructs an empty GlobalResult</summary>
        public GlobalResult() { }

        /// <summary>
        /// Constructs a global result using a BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public GlobalResult(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }

        /// <summary>
        /// Constructs a global result by loadcase name and number. If name or number are not know, set to "" and 0 respectively.
        /// </summary>
        /// <param name="loadcaseNumber"></param>
        /// <param name="loadcaseName"></param>
        public GlobalResult(int loadcaseNumber, string loadcaseName)
        {
            this.Loadcase = new Loads.Loadcase(loadcaseNumber, loadcaseName);
        }

        /// <summary>
        /// Sets the base shear in X and Y for the loadcase
        /// </summary>
        /// <param name="vX"></param>
        /// <param name="vY"></param>
        public void SetBaseShear(double vX, double vY)
        {
            this.BaseShearX = vX;
            this.BaseShearY = vY;
        }

        /// <summary>
        /// Sets the sum of reactions for a given loadcase by constructing 
        /// two BHoM vector objects (forces and moments)
        /// </summary>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="fZ"></param>
        /// <param name="mX"></param>
        /// <param name="mY"></param>
        /// <param name="mZ"></param>
        public void SetReactions(double fX, double fY, double fZ, double mX, double mY, double mZ)
        {
            this.SumOfReactions_F = new BHoM.Geometry.Vector(fX, fY, fZ);
            this.SumOfReactions_M = new BHoM.Geometry.Vector(mX, mY, mZ);
        }

        /// <summary>
        /// Sets the sum of mass for the given loadcase
        /// </summary>
        /// <param name="mass"></param>
        public void SetSumOfMass(double mass)
        {
            this.SumOfMass = mass;
        }

    }
}
