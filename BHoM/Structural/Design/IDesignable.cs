using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Design
{
    public interface IDesignable
    {
        StructuralLayout GetStructuralLayout();
    }
}
