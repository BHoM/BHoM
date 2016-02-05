using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Materials;

namespace BHoM.Structural
{
    [Serializable]
    public class SectionProperty
    {
        ///////////////////////////
        ////FIELD VARIABLES////////
        ///////////////////////////

        bool _hasSectionModuli;
        double _massPerMetre;


        ///////////////////////////
        /////  PROPERTIES  ////////
        ///////////////////////////

        public int Index { get; protected set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Type { get; set; }
        public int MatIndex { get; set; }
        private Material _material;
        public string MtrlDesc { get; set; }
        public List<string> Identities { get; protected set; }

        public string RevitFamilyTypeName { get; set; }


        //// DIMENSIONS ////
        public double Area { get; protected set; }
        public double D { get; set; } //Depth
        public double B { get; set; } //Breatdh
        public double tw { get; set; } //Web thickness
        public double tf { get; set; } //Flange thickness
        public double rootR { get; set; } //Root radius
        public double R { get; set; } // Radius (currently only used for cables)

        //// DESIGN CHECK VARIABLES ////
        public double Fy { get; private set; } //Yield stress specific to the section property (depending on the nominal thickness)
        public double Fu { get; private set; } //Ultimate stress specific to the section property (depending on the nominal thickness)
        public int sClass { get; private set; }
        public double Iyy { get; private set; } //Moment of inertia Iyy
        public double Izz { get; private set; } //Moment of inertia Izz
        public double J { get; private set; } //Torsion constant
        public double WyPl { get; set; }
        public double WyElMin { get; set; }
        public double WyEffMin { get; set; }
        public double WzPl { get; set; }
        public double WzElMin { get; set; }
        public double WzEffMin { get; set; }
        public double Avz { get; protected set; } //Shear area major axis (z)
        public double Avy { get; protected set; } //Shear area minor axis (y)
        public double Sy { get; private set; }
        public double Sz { get; private set; }
        public double C1 { get; private set; }
        public double C2 { get; private set; }

        //// MODIFIERS /////

        public double ModA { get; protected set; }
        public double ModIyy { get; protected set; }
        public double ModIzz { get; protected set; }
        public double ModJ { get; protected set; }

        //// DOUBLE ANGLES ////

        public double DoubleAngleRx { get; set; }
        public double DoubleAngleRy { get; set; }
        public double DoubleAngleR0 { get; set; }
        public double DoubleAngleH { get; set; }
        public double DoubleAngleQs { get; set; }

        //// CAPACITIES ////
        public double NRd { get; set; }
        public double VyRd { get; set; }
        public double VzRd { get; set; }
        public double MyRd { get; set; }
        public double MzRd { get; set; }
        public double NybRd { get; set; } //Design buckling resistance of a compression member (buckling about the y-y axis) // TODO: REMOVE THIS??? #GG 20140929 
        public double NzbRd { get; set; } //Design buckling resistance of a compression member (buckling about the z-z axis)
        public double MybRd { get; set; } //Design buckling resistance about y-y axis (simplified interaction criterion - NCCI)
        public double MzcbRd { get; set; } //Design buckling resistance about z-z axis (simplified interaction criterion - NCCI)

        //// Set Out ////
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public double CutbackS { get; set; }
        public double CutbackE { get; set; }
        public double ZOffsetS { get; set; }
        public double ZOffsetE { get; set; }
        public double[] TaperDepth { get; set; }
        public double[] TaperBreadth { get; set; }
        public double[] TaperOffsetY { get; set; }
        public double[] TaperOffsetZ { get; set; }
        public double[] TaperIntermediatePos { get; set; }

        public SectionProperty() : base()
        {
            Type = "Undefined";
        }

        public bool IsTapered
        {
            get
            {
                if (TaperDepth != null)
                {
                    foreach (double D in TaperDepth)
                    {
                        if (!double.IsNaN(D))
                            return SanitiseTaperingData();
                    }

                }

                if (TaperBreadth != null)
                {
                    foreach (double B in TaperBreadth)
                    {
                        if (!double.IsNaN(B))
                            return SanitiseTaperingData();
                    }

                }

                return false;
            }
        }

        // remove possible unwanted nulls, NaNs and negative numbers
        public bool SanitiseTaperingData()
        {
            double[] sanTaperDepth = new double[] { D, D, D, D };
            double[] sanTaperBreadth = new double[] { B, B, B, B };
            double[] sanTaperOffsetY = new double[] { 0, 0, 0, 0 };
            double[] sanTaperOffsetZ = new double[] { 0, 0, 0, 0 };
            double[] sanTaperIntermediatePos = new double[] { double.NaN, double.NaN };


            if (TaperDepth != null)
            {
                for (int i = 0; i < TaperDepth.Length; i++)
                {
                    if (i < 4 && !double.IsNaN(TaperDepth[i]) && TaperDepth[i] > 0)
                        sanTaperDepth[i] = TaperDepth[i];
                }
            }

            if (TaperBreadth != null)
            {
                for (int i = 0; i < TaperBreadth.Length; i++)
                {
                    if (i < 4 && !double.IsNaN(TaperBreadth[i]) && TaperBreadth[i] > 0)
                        sanTaperBreadth[i] = TaperBreadth[i];
                }
            }

            if (TaperOffsetY != null)
            {
                for (int i = 0; i < TaperOffsetY.Length; i++)
                {
                    if (i < 4 && !double.IsNaN(TaperOffsetY[i]))
                        sanTaperOffsetY[i] = TaperOffsetY[i];
                }
            }

            if (TaperOffsetZ != null)
            {
                for (int i = 0; i < TaperOffsetZ.Length; i++)
                {
                    if (i < 4 && !double.IsNaN(TaperOffsetZ[i]))
                        sanTaperOffsetZ[i] = TaperOffsetZ[i];
                }
            }

            if (TaperIntermediatePos != null)
            {
                for (int i = 0; i < TaperIntermediatePos.Length; i++)
                {
                    if (i < 2 && TaperIntermediatePos[i] > 0)
                        sanTaperIntermediatePos[i] = TaperIntermediatePos[i];
                }
            }

            TaperDepth = sanTaperDepth;
            TaperBreadth = sanTaperBreadth;
            TaperOffsetY = sanTaperOffsetY;
            TaperOffsetZ = sanTaperOffsetZ;
            TaperIntermediatePos = sanTaperIntermediatePos;

            return true;
        }

    }
    }
