﻿using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    public interface ICase : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        int Number { get; set; }  //TODO: Do we still need this ? Should we not use name or Guid ??


        /***************************************************/
    }
}
