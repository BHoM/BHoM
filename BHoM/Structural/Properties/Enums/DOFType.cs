namespace BH.oM.Structural.Properties
{

    /***************************************************/

    /// <summary>
    /// Enumerator of types of degrees of freedom
    /// </summary>
    public enum DOFType
    {
        /// <summary>Free - all DOF's released</summary>
        Free = 0,
        /// <summary>Fixed - all DOF's blocked</summary>
        Fixed = 1,
        /// <summary>Zero stiffness in the positive direction</summary>
        FixedNegative = 2,
        /// <summary>Zero stiffness in the negative direction</summary>
        FixedPositive = 3,
        /// <summary>Linear spring constant</summary>
        Spring = 4,
        /// <summary>Non-linear, zero stiffnss in positive direction</summary>
        SpringNegative = 5,
        /// <summary>Non-linear, zero stiffness in negative direction</summary>
        SpringPositive = 6,
        /// <summary>Spring stiffness between 0-1 relates to the element to which the DOF applies (e.g. bar end stiffness)</summary>
        SpringRelative = 7,
        /// <summary>As spring negative, but relative stiffness</summary>
        SpringRelativeNegative = 8,
        /// <summary>As spring positive but relative stiffness</summary>
        SpringRelativePositive = 9,
        /// <summary>Non-linear spring model</summary>
        NonLinear = 10,
        /// <summary>Friction model (relative to the load applied)</summary>
        Friction = 11,
        /// <summary>Damped velocities/accelerations</summary>
        Damped = 12,
        /// <summary>Gap model</summary>
        Gap = 13
    }

    /***************************************************/
}
