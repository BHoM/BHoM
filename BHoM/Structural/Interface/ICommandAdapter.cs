using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Structural.Loads;

namespace BHoM.Structural.Interface
{
    public interface ICommandAdapter
    {
        bool Analyse(List<string> cases = null);
        bool ClearResults();

        bool Save(string fileName = null);

        bool Close();

        bool ClearModel();

        bool ScreenCapture(string fileName = null, List<string> cases = null, List<string> viewNames = null);

    }
}
