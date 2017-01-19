using BHoM.Geometry;
using BHoM.Base;
using BHoM.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BHoM.Global;
using BHoM.Structural.Databases;

namespace BHoM.Structural.Properties
{
    public enum Fabrication
    {
        Welded,
        HotRolled,
        HotFormed, 
        ColdFormed
    }

    public class SteelSection : SectionProperty
    {

        public SteelSection()
        {
            Material = null; // BHoM.Materials.Material.Default(MaterialType.Steel);
        }

        /// <summary>
        /// Create a section property from standard input values
        /// </summary>
        /// <param name="sType">Shape type</param>
        /// <param name="mType">Material type</param>
        /// <param name="height">Total Height</param>
        /// <param name="width">Total width</param>
        /// <param name="t1">Flange Thickness</param>
        /// <param name="t2">Web Thickness</param>
        /// <param name="r1">Radius 1</param>
        /// <param name="r2">Radius 2</param>
        /// <param name="mass">Mass per metre</param>
        public SteelSection(ShapeType sType, double height, double width, double t1, double t2, double r1, double r2, double mass = 0, double b1 = 0, double b2 = 0, double t3 = 0, double b3 = 0):this()
        {
            SectionData = CreateSectionData(height, width, t1, t2, r1, r2, mass, b1, b2, t3, b3);
            Edges = CreateGeometry(sType, height, width, t1, t2, r1, r2, b1, b2, t3, b3);
            Shape = sType;
            //SectionMaterial = mType;
        }

        /// <summary>
        /// Create a section property from a list of edges, shape type and material
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="sType"></param>
        /// <param name="mType"></param>
        public SteelSection(BHoM.Geometry.Group<Curve> edges, ShapeType sType) : this()
        {
            Edges = edges;
            Shape = sType;
            //SectionMaterial = mType;
        }     

        public double GetGrade()
        {
            return Material.TensileYieldStrength / 1000000;         
        }   

        public Fabrication Fabrication
        {
            get; set;
        }

        public double B1
        {
            get
            {
                return SectionData[(int)SteelSectionData.B1];
            }
        }

        public double B2
        {
            get
            {
                return SectionData[(int)SteelSectionData.B2];
            }
        }

        public double Tw
        {
            get
            {
                return SectionData[(int)SteelSectionData.TW];
            }
        }

        public double Tf1
        {
            get
            {
                return SectionData[(int)SteelSectionData.TF1];
            }
        }

        public double Tf2
        {
            get
            {
                return SectionData[(int)SteelSectionData.TF2];
            }
        }

        public double r1
        {
            get
            {
                return SectionData[(int)SteelSectionData.r1];
            }
        }
    }
}
