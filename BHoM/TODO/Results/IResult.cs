using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public interface IResult : IComparable
    {
        string Id { get; set; }
        //object[] Data { get; set; }
        object[] GetData();
        void SetData(object[] data);
        string[] ColumnHeaders { get; }
    }
}
