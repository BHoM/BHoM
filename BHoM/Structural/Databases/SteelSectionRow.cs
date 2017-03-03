using BHoM.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Databases
{
    public class SteelSectionRow : IDataRow
    {
        public string Name
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int Id { get; set; }
        public int Shape { get; set; }
        public double Mass { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public double B3 { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public double r1 { get; set; }
        public double r2 { get; set; }
        public double GAP { get; set; }
        public double Angle { get; set; }
        public double CxPlus { get; set; }
        public double CxMinus { get; set; }
        public double CyPlus { get; set; }
        public double CyMinus { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        public SteelSectionRow() { }

    }
}
