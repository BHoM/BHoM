
namespace BH.oM.Structural.Elements
{
    //TODO:Where does this go? Does it actually fit within the structural elements folder???
    /// <summary>Usage of the bar for downstream implementations</summary>
    public enum BarStructuralUsage //TODO: Need to better organise those enums into relevant groups per file
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

    /***************************************************/

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

    /***************************************************/

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

    /***************************************************/

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

    /***************************************************/

    /// <summary>
    /// Sets the type of FE element model to use for bars in analysis software
    /// </summary>
    public enum BarFEAType
    {
        /// <summary>Fixed conection. 2 x 6 DOF:s</summary> 
        Flexural = 0,
        /// <summary>Pin ended conection. 2 x 3 DOF:s</summary>
        Axial,
        /// <summary>Pin ended conection, tension only. 2 x 3 DOF:s</summary>
        CompressionOnly,
        /// <summary>Pin ended conection, compression only. 2 x 3 DOF:s</summary>
        TensionOnly,
        //Cable
    }

    /***************************************************/

    public enum AreaElementType
    {
        Panel,
        Mesh
    }

}
