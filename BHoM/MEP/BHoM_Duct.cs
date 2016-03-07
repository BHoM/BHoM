using BHoM.Global;
using BHoM.MEP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    public enum DuctType
    {
        Round,
        Rectuangular
    }

    public class Duct : Element
    {
        public Duct(ClosedShell ClosedShell, LocationLine LocationLine, double Width, double Height)
            : base(LocationLine, ClosedShell)
        {
            this.Width = Width;
            this.Height = Height;
            this.Diameter = double.NaN;
            DuctType = DuctType.Rectuangular;
        }

        public Duct(ClosedShell ClosedShell, LocationLine LocationLine, double Diameter)
            : base(LocationLine, ClosedShell)
        {
            this.Diameter = Diameter;
            this.Width = double.NaN;
            this.Height = double.NaN;
            DuctType = DuctType.Round;
        }

        public DuctType DuctType
        {
            get
            {
                DuctType aDuctType = DuctType.Rectuangular;
                string aString = Parameters.LookUp<string>("Duct Type"); ;
                Enum.TryParse(aString, out aDuctType);
                return aDuctType;
            }
            private set
            {
                Parameters.AddItem("Height", value.ToString());
            }


        }

        public double Width
        {
            get
            {
                return Parameters.LookUp<double>("Width");
            }
            private set
            {
                Parameters.AddItem("Width", value);
            }
        }

        public double Height
        {
            get
            {
                return Parameters.LookUp<double>("Height");
            }
            private set
            {
                Parameters.AddItem("Height", value);
            }
        }

        public double Diameter
        {
            get
            {
                return Parameters.LookUp<double>("Diameter");
            }
            private set
            {
                Parameters.AddItem("Diameter", value);
            }
        }
    }
}
