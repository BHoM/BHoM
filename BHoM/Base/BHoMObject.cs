using System;
using System.Collections.Generic;

namespace BH.oM.Base
{
    public class BHoMObject : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Guid BHoM_Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = "";

        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        public Dictionary<string, object> CustomData { get; set; } = new Dictionary<string, object>();


        /***************************************************/
        /**** Public Local Methods                      ****/
        /***************************************************/

        public BHoMObject GetShallowClone(bool newGuid = false)
        {
            BHoMObject obj = (BHoMObject)this.MemberwiseClone();
            obj.CustomData = new Dictionary<string, object>(CustomData);
            if (newGuid)
                obj.BHoM_Guid = Guid.NewGuid();
            return obj;
        }

        /***************************************************/
    }
}
