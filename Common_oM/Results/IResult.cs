using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Common
{
    public interface IResult : IObject, IComparable<IResult>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        IComparable ObjectId { get; }

        IComparable ResultCase { get; }

        double TimeStep { get; }

        /***************************************************/
    }
}
