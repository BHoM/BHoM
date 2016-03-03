using BHoM.Global;
using BHoM.MEP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.MEP
{
    public class Pipe : Element
    {
        public Pipe(ClosedShell ClosedShell, LocationLine LocationLine, double Diameter)
            : base(LocationLine, ClosedShell)
        {
            this.Diameter = Diameter;
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
