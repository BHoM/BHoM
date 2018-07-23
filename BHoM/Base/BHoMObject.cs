using System;
using System.Collections.Generic;

namespace BH.oM.Base
{
    public class BHoMObject : IBHoMObject
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

        public IBHoMObject GetShallowClone(bool newGuid = false)
        {
            BHoMObject obj = (BHoMObject)this.MemberwiseClone();

            if (CustomData != null)
                obj.CustomData = new Dictionary<string, object>(CustomData);
            else
                obj.CustomData = new Dictionary<string, object>();

            if (Tags != null)
                obj.Tags = new HashSet<string>(Tags);
            else
                obj.Tags = new HashSet<string>();

            if (newGuid)
                obj.BHoM_Guid = Guid.NewGuid();

            return obj;
        }

        /***************************************************/
    }
}
