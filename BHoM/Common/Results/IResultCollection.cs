﻿using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Common
{
    public interface IResultCollection : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        string ObjectId { get; set; }
        
        /***************************************************/
    }
}
