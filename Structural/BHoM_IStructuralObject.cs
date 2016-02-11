using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// Structural object interface, all methods and attributes applicable to all structural objects with
    /// IStructuralObject implemented
    /// </summary>
    public interface IStructuralObject
    {
        /// <summary>BHoM unique ID</summary>
        System.Guid BHoM_ID { get; }

        /// <summary>User text input. Can be used to store user information in an object
        /// such as a user ID or a project specific parameter</summary>
        string UserText { get; set; }

        /// <summary>Object number</summary>
        int Number { get; }

        /// <summary>Set object number</summary>
        void SetNumber(int number);

        /// <summary>Object name</summary>
        string Name { get; }

        /// <summary>Set object name</summary>
        void SetName(string name);
    }
}