/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */



using BH.oM.Base;
using BH.oM.Physical.Materials;

namespace BH.oM.Structure.Properties.Section
{
    public class CableSection : BHoMObject, ISectionProperty, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Material Material { get; set; } = null;


        /***************************************************/
        /**** Properties - Section dimensions           ****/
        /***************************************************/

        public int NumberOfCables { get; } = 0;


        public double CableDiameter { get; } = 0;


        public CableType CableType { get; } = CableType.FullLockedCoil;


        public double BreakingLoad { get; }



        /***************************************************/
        /**** Properties - Section constants            ****/
        /***************************************************/


        /// <summary>
        /// Gross Area of the cross section
        /// </summary>
        public double Area { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Y-Axis
        /// </summary>
        public double Rgy { get; } = 0;

        /// <summary>
        /// Radius of Gyration about the Z-Axis
        /// </summary>
        public double Rgz { get; } = 0;

        /// <summary>
        /// Torsion Constant
        /// </summary>
        public double J { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Y-Axis
        /// </summary>
        public double Iy { get; } = 0;

        /// <summary>
        /// Moment of Inertia about the Z-Axis
        /// </summary>
        public double Iz { get; } = 0;

        /// <summary>
        /// Warping Constant
        /// </summary>
        public double Iw { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Wely { get; } = 0;

        /// <summary>
        /// Elastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Welz { get; } = 0;
        /// <summary>
        /// Plastic Modulus of the section about the Y-Axis
        /// </summary>
        public double Wply { get; } = 0;

        /// <summary>
        /// Plastic Modulus of the section about the Z-Axis
        /// </summary>
        public double Wplz { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Z direction
        /// </summary>
        public double CentreZ { get; } = 0;
        /// <summary>
        /// Geometric centre of the section in the Y direction
        /// </summary>
        public double CentreY { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to top edge of the section
        /// </summary>
        public double Vz { get; } = 0;

        /// <summary>
        /// Z Distance from the centroid of the section to bottom edge of the section
        /// </summary>
        public double Vpz { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to right edge of the section
        /// </summary>
        public double Vy { get; } = 0;
        /// <summary>
        /// Y Distance from the centroid of the section to Left edge of the section
        /// </summary>
        public double Vpy { get; } = 0;

        /// <summary>
        /// Shear Area in the Y direction
        /// </summary>
        public double Asy { get; } = 0;

        /// <summary>
        /// Shear Area in the Z direction
        /// </summary>
        public double Asz { get; } = 0;



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/


        //Main constructor setting all of the properties of the object
        public CableSection(
            Material material,
            int numberOfCables,
            double cableDiameter,
            CableType cableType,
            double breakingLoad,

            double area,
            double rgy,
            double rgz,
            double j,
            double iy,
            double iz,
            double iw,
            double wely,
            double welz,
            double wply,
            double wplz,
            double centreZ,
            double centreY,
            double vz,
            double vpz,
            double vy,
            double vpy,
            double asy,
            double asz)

        {
            Material = material;
            CableDiameter = cableDiameter;
            NumberOfCables = numberOfCables;
            CableType = cableType;
            BreakingLoad = breakingLoad;

            Area = area;
            Rgy = rgy;
            Rgz = rgz;
            J = j;
            Iy = iy;
            Iz = iz;
            Iw = iw;
            Wely = wely;
            Welz = welz;
            Wply = wply;
            Wplz = wplz;
            CentreZ = centreZ;
            CentreY = centreY;
            Vz = vz;
            Vpz = vpz;
            Vy = vy;
            Vpy = vpy;
            Asy = asy;
            Asz = asz;

        }

        /***************************************************/
    }
}




        /***************************************************/
        /**** TODO: Legacy - To be moved                ****/
        /***************************************************/


        //public CableSection(double diameter, double areaOfOneCable, int numberOfCables = 1) : this(diameter, areaOfOneCable, BH.oM.Materials.Material.Default(Materials.MaterialType.Cable), numberOfCables)
        //{   }

        //public CableSection(double diameter, double areaOfOneCable, BH.oM.Materials.Material mat, int numberOfCables = 1)
        //{
        //    m_numberOfCables = numberOfCables;
        //    m_Area = areaOfOneCable;
        //    Material = mat;
        //    CreateEdgeCurves(diameter, numberOfCables);
        //    SectionData[(int)CableSectionData.D] = diameter;
        //    SectionData[(int)CableSectionData.A] = areaOfOneCable;
        //}

        //public override double GrossArea
        //{
        //    get
        //    {
        //        if (m_Area == 0)
        //            m_Area = SectionData[(int)CableSectionData.A];

        //        return m_Area * m_numberOfCables;
        //    }
        //}

        //public int NumberOfCables
        //{
        //    get
        //    {
        //        return m_numberOfCables;
        //    }
        //    set
        //    {
        //        m_numberOfCables = value;
        //    }
        //}



        //public override ShapeType Shape
        //{
        //    get
        //    {
        //        return ShapeType.Cable;
        //    }

        //    set
        //    {
        //        base.Shape = ShapeType.Cable;
        //    }
        //}

        //protected string GenerateStandardName()
        //{
        //    return m_numberOfCables + "-CABLE LCØ"+SectionData[(int)CableSectionData.D] * 1000;
        //}

        //public double BreakingLoad
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.BL]*NumberOfCables;
        //    }
        //}

        //public double MassPerMetre
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.Weight] * NumberOfCables;
        //    }
        //}

        //public double WeightOpenSpelterSocket
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.WeightEndOpen] * NumberOfCables;
        //    }
        //}

        //public double WeightOpenAdjustableSpelterSocket
        //{
        //    get
        //    {
        //        return SectionData[(int)CableSectionData.WeightEndAdjustable] * NumberOfCables;
        //    }
        //}

        //public double WeightStyliteForkSocket
        //{
        //    get
        //    {
        //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteForkSocketDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

        //if (data != null)
        //{
        //    return NumberOfCables * ((double)data[(int)CableSTFConnectorData.PinOCapsWeight] + (double)data[(int)CableSTFConnectorData.SocketWeight]);
        //}

        //        return -1;
        //    }
        //}

        //public double WeightStyliteAdjustableForkSocket
        //{
        //    get
        //    {
        //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteAdjustableForkSocketDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

        //if (data != null)
        //{
        //    return NumberOfCables * (double)data[(int)CableSTAFConnectorData.Weight];
        //}

        //        return -1;
        //    }
        //}

        //public double WeightStyliteRingConnector
        //{
        //    get
        //    {
        //object[] data = new SQLAccessor(Database.Cables, Project.ActiveProject.Config.StyliteRingConnectorDataBase).GetDataRow("CableDia", SectionData[(int)CableSectionData.D].ToString());

        //if (data != null)
        //{
        //    return NumberOfCables * (double)data[(int)CableSTRCConnectorData.Weight];
        //}

        //        return -1;
        //    }
        //}
