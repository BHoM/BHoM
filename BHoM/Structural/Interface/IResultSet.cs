using BH.oM.Structural.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Interface
{
    public interface IResultSet // TODO: Where does this go?
    {
        void AddData(IEnumerable<object[]> rows);
        void AddData(object[] rows);
        List<object[]> ToListData();
        List<T> AsList<T>() where T : IResult, new();
        Envelope MaxEnvelope();
        Envelope MinEnvelope();
        Envelope AbsoluteEnvelope();
    }
}
