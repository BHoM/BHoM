
namespace BHoM.Structural
{
    /// <summary>
    /// Structural object interface, all methods and attributes applicable to all structural objects with
    /// IStructuralObject implemented
    /// </summary>
    public interface IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////

        /// <summary>Object number</summary>
        int Number { get; }

        /// <summary>Set object number</summary>
        void SetNumber(int number);

        /// <summary>Object name</summary>
        string Name { get; }

        /// <summary>Set object name</summary>
        void SetName(string name);

        //////////////
        ////Methods///
        //////////////

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        BHoM.Collections.Dictionary<string, object> GetProperties();
    }
}