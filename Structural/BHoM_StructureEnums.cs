using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    public enum BarStructuralUsage
    {
        Beam = 0,
        Column,
        Brace,
        Cable
    }

    public enum FEMAppHost
    {
        GSA = 0,
        Robot,
        Tensyl
    }

    public enum ElementTypeGSA
    {
        Unknown = 0,
        Cable,
        Beam,
        Bar,
        Tie,
        Link //Rigid
    }

    public enum DesignCode
    {
        EuroCode = 0,
        AISC
    }

    public enum RobotFaceLoadDistribution
    {
        Unknown = -1,
        X = 0,
        Y,
        XY

    }

    public enum BeamJustificaion
    {
        MiddleCenter = 0,
        TopLeft,
        TopRight,
        TopCenter,
        MiddleRight,
        MiddleLeft,
        BottomLeft,
        BotttomCenter,
        BottomRight
    }


    public enum Element2DTypeGSA
    {
        Unknown = 0,
        Tri3,
        Quad4,
        Tri6,
        Quad8

    }

    public enum SuperBeamType
    {
        Span = 0,
        CantileverA, //cantilever supported in end node
        CantileverB, //cantilever supported in start node
        NotImportant,
    }

    public enum BeamType
    {
        Unknown = 0,
        RHS,
        CHS,
    }


    public enum SessionType
    {
        General = 0,
        Connection,
        InitialDesignCheck,
        SingleDesignCheck,
        ApplyModelData,
        Test0,
        ReactionForce,
        FullVerificationEnvelope,
        AutoFormFind,
        EtihadOpt,
    }

    public enum SubSessionType
    {
        ApplyLoadingInfo = 0,
        ApplySectionProperties,
        StraightenStruts,
        CreateGSAWindFromBMT,
        ConnectionExtractionSingleModel,
        ConnectionExtractionMultipleModels,
        None,

    }

    public enum ConnectionExtractionSubsessionType
    {
        Envelope = 0,
        Elements,
    }

    public enum ExtractionCaseType
    {
        Analysis = 0,
        Combination,
        Unknown,
    }


    public enum ManufactureType
    {
        Rolled = 0, //Rolled section
        WeldedIBeam, //Welded I-section
        ColdFormed, //Cold-formed Hollow Section
        HotFinished, //Hot-finished Hollow Section
        WeldedBox, //Welded box section
        unknown,
    }

    public enum ShearDataType
    {
        Low = 0,
        LowHorHighVert,
        HighHorLowVert,
        High,
    }

    public enum LoadAxis
    {
        X = 0,
        Y,
        Z,
        XX,
        YY,
        ZZ,
    }

    public enum BucklingCurve
    {
        a0 = 0,
        a,
        b,
        c,
        d,
        unknown,
    }

    public enum ShearType
    {
        a = 0,
        b,
        c1,
        c2,
        d,
        e,
        f1,
        f2,
        g,
    }

    public enum SectionClass
    {
        c1 = 0,
        c2,
        c3,
        c4,
        unknown,
    }

    public enum ListType
    {
        NODE = 0,
        ELEMENT,
        MEMBER,
        CASE,
        LINE,
        AREA,
        REGION,
        ELEMENT2D,
        UNDEF
    }

    public enum AmericanCompressionSlenderness
    {
        nonslender = 0,
        slender,
        unknown
    }

    public enum AmericanFlexureSlenderness
    {
        compact = 0,
        noncompact,
        slender,
        unknown
    }

    public enum AxisDirection
    {
        X = 0,
        Y,
        Z,
        XX,
        YY,
        ZZ
    }

    /// <summary>
    /// Enumerator of types of degrees of freedom
    /// </summary>
    public enum DOFType
    {
        Free = 0, 
        Fixed,
        FixedNegative, //Zero stiffness in the positive direction
        FixedPositive, //Zero stiffness in the negative direction
        Spring, 
        SpringNegative, //Non-linear, zero stiffness in positive direction
        SpringPositive, //Non-linear, zero stiffness in negative direction
        SpringRelative, //Spring stiffness between 0-1 relates to the element to which the DOF applies (e.g. bar end stiffness)
        SpringRelativeNegative, //As spring negative, but relative stiffness
        SpringRelativePositive, 
        NonLinear,
        Friction,
        Damped,
        Gap
    }

    public enum ConstraintType
    {
        Restraint = 0,
        Release,
        Rigid, 
        Compatibility
    }
}
