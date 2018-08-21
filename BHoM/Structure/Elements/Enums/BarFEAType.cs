namespace BH.oM.Structure.Elements
{
    /***************************************************/
    public enum BarFEAType
    {
        /// <summary>Fixed conection. 2 x 6 DOF:s</summary> 
        Flexural = 0,
        /// <summary>Pin ended conection. 2 x 3 DOF:s</summary>
        Axial,
        /// <summary>Pin ended conection, compression only. 2 x 3 DOF:s</summary>
        CompressionOnly,
        /// <summary>Pin ended conection, tension only. 2 x 3 DOF:s</summary>
        TensionOnly,
    }

    /***************************************************/
}
