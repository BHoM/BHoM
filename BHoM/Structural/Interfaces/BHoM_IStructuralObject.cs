
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

        /// <summary>Object name</summary>
        string Name { get; }

        //////////////
        ////Methods///
        //////////////
    }
}