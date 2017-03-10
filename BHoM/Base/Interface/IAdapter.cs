using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base
{
    public interface IAdapter
    {
        bool Push(IEnumerable<object> data, out List<object> failed, string config = "");

        bool Push(IEnumerable<object> data, string config = "");

        List<object> Pull(string queryStrings = "", bool keepAsString = false);

        bool Delete(string filterString = "");
    }
}
