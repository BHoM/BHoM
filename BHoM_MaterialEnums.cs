using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Materials
{
    public enum SteelGrade
    {
        S235 = 0,
        S275,
        S355,
        S420,
        S450,
        S460,
        unknown
    }

    public enum DefaultMaterials
    {
        Steel = 1,
        ConcreteShortTerm,
        ConcreteLongTerm,
        Aluminium,
        Glass
    }

    public enum MaterialModel
    {
        MAT_ELAS_ISO = 0,
        MAT_ELAS_ORTHO,
        MAT_ELAS_PLAS_ISO,
        MAT_FABRIC 
    }
       
}
