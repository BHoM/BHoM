using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public interface IAdapter
    {
        bool Push(IEnumerable<object> data, string tag = "", Dictionary<string, string> config = null);

        IList Pull(IEnumerable<string> query, Dictionary<string, string> config = null);

        bool Execute(string command, Dictionary<string, string> config = null);

        bool Delete(string filter = "", Dictionary<string, string> config = null);

        List<string> ErrorLog { get; set; }
    }
}
