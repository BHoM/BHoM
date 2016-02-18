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
        public Dictionary<string,object> UserData { get; set; }
 
    }

}