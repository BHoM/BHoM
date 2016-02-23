using System.Collections.Generic;

namespace BHoM.Global
{
    /// <summary>
    /// BHoM object abstract class, all methods and attributes applicable to all structural objects with
    /// BHoM implemented
    /// </summary>
    public abstract class BHoMObject
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }


        /// <summary>User text input. Can be used to store user information in an object
        /// such as a user ID or a project specific parameter</summary>
        public BHoM.Collections.Dictionary<string, object> UserData { get; set; }


        /// <summary>
        /// Set the BHoM_Guid
        /// </summary>
        public void SetBHoMGuid()
        {
            this.BHoM_Guid = System.Guid.NewGuid();
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> PropertiesDictionary = new BHoM.Collections.Dictionary<string, object>();
            foreach (var prop in this.GetType().GetProperties())
            {
                PropertiesDictionary.Add(prop.Name, prop.GetValue(this));
            }
            return PropertiesDictionary;
        }
    }
}