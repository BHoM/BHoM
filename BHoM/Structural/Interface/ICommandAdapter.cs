using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Structural.Loads;

namespace BH.oM.Structural.Interface
{
    public interface ICommandAdapter
    {
        bool Analyse(List<string> cases = null);
        bool ClearResults();

        bool Save(string fileName = null);

        bool Close();



    }
}
