

using System;

namespace BHoM.Structural.Sections
{
    /// <summary>
    /// Section property interface, all methods and attributes applicable to all section properties
    /// </summary>
    public interface ISectionProperty
    {
        /////////////////
        ////Properties///
        /////////////////


        /// <summary>Object name</summary>
        string Name { get; }

        //////////////
        ////Methods///
        //////////////

        ///<summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        BHoM.Collections.Dictionary<string, object> GetProperties();
    }
}