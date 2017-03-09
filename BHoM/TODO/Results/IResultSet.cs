using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public interface IResultSet
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
