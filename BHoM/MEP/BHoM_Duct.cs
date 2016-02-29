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
                string aString = Parameters["Duct Type"].GetValue<string>();
                Enum.TryParse(aString, out aDuctType);
                return aDuctType;
            }
            private set
            {
                SetParameter("Duct Type", value.ToString());
            }
        }

        public double Width
        {
            get
            {
                return Parameters["Width"].GetValue<double>();
            }
            private set
            {
                SetParameter("Width", value);
            }
        }

        public double Height
        {
            get
            {
                return Parameters["Height"].GetValue<double>();
            }
            private set
            {
                SetParameter("Height", value);
            }
        }

        public double Diameter
        {
            get
            {
                return Parameters["Diameter"].GetValue<double>();
            }
            private set
            {
                SetParameter("Diameter", value);
            }
        }
    }
}
