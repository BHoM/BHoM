using BH.oM.Base;
using System;

namespace BH.oM.Common
{
    public interface IResultCollection : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        IComparable ObjectId { get;  }
        
        /***************************************************/
    }
}
