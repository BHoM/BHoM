
namespace BHoM.Structural.Elements
{
    /// <summary>Usage of the bar for downstream implementations</summary>
    public enum BarStructuralUsage
    {
        /// <summary>Undefined</summary>
        Undefined = 0,
        /// <summary>Beam</summary>
        Beam,
        /// <summary>Column</summary>
        Column,
        /// <summary>Brace</summary>
        Brace,
        /// <summary>Cable</summary>
        Cable,
        /// <summary>Pile</summary>
        Pile
    }

    /// <summary>Manufacture type for steel</summary>
    public enum ManufactureType
    {
        /// <summary>Rolled steel section</summary>
        Rolled = 0,
        /// <summary>Welded steel I-section</summary>
        WeldedIBeam,
        /// <summary>Cold formed hollow section</summary>
        ColdFormed,
        /// <summary>Hot finished hollow section</summary>
        HotFinished,
        /// <summary>Welded steel box section</summary>
        WeldedBox,
        /// <summary>Not known</summary>
        unknown,
    }

    /// <summary>Steel strut buckling curves</summary>
    public enum BucklingCurve
    {
        /// <summary>a0</summary>
        a0 = 0,
        /// <summary>a</summary>
        a,
        /// <summary>b</summary>
        b,
        /// <summary>c</summary>
        c,
        /// <summary>d</summary>
        d,
        /// <summary>Not Known</summary>
        unknown,
    }

    /// <summary>Shear type</summary>
    public enum ShearType
    {
        /// <summary>a</summary>
        a = 0,
        /// <summary>b</summary>
        b,
        /// <summary>c1</summary>
        c1,
        /// <summary>c2</summary>
        c2,
        /// <summary>d</summary>
        d,
        /// <summary>e</summary>
        e,
        /// <summary>f1</summary>
        f1,
        /// <summary>f2</summary>
        f2,
        /// <summary>g</summary>
        g,
    }

}
