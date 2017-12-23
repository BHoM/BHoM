using System;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Structural.Design
{
    [Serializable] public class DesignGroup : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int Number { get; set; } = 0;

        public string MaterialName { get; set; } = "";

        public List<int> MemberIds { get; set; } = new List<int>();

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public DesignGroup() { }

        /***************************************************/
    }
}



     
