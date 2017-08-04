using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Interface
{
    public interface IResult : IComparable //TODO: where does this go?
    {
        string Id { get; set; }
        //object[] Data { get; set; }
        object[] GetData();
        void SetData(object[] data);
        string[] ColumnHeaders { get; }
    }
}
