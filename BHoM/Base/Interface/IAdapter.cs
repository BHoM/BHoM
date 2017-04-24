using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base
{
    public interface IAdapter
    {
        bool Push(IEnumerable<object> data, string tag = "", Dictionary<string, string> config = null);

        IList Pull(string query, List<string> parameters = null, Dictionary<string, string> config = null);

        bool Execute(string command, List<string> parameters = null, Dictionary<string, string> config = null);

        bool Delete(string filter = "", Dictionary<string, string> config = null);

        List<string> ErrorLog { get; set; }
    }
}
