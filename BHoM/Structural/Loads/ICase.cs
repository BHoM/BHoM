using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    public interface ICase : IObject
    {
        int Number { get; set; }

        CaseType GetCaseType();
    }
}
