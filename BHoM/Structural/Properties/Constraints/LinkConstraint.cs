using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public enum LinkageType
    {
        All,
        AllPinned,
        XYPlane,
        YZPlane,
        ZXPlane,
        XYPlanePin,
        YZPlanePin,
        ZXPlanePin,
        XPlate,
        YPlate,
        ZPlate,
        XPlatePin,
        YPlatePin,
        ZPlatePin,
        Custom
    }

    public class LinkConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public bool XtoX { get; set; } = false;

        public bool YtoY { get; set; } = false;

        public bool ZtoZ { get; set; } = false;


        public bool XtoYY { get; set; } = false;

        public bool XtoZZ { get; set; } = false;

        public bool YtoXX { get; set; } = false;

        public bool YtoZZ { get; set; } = false;

        public bool ZtoXX { get; set; } = false;

        public bool ZtoYY { get; set; } = false;


        public bool XXtoXX { get; set; } = false;

        public bool YYtoYY { get; set; } = false;

        public bool ZZtoZZ { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LinkConstraint() { }


        ///***************************************************/
        ///**** Static Constructors                       ****/
        ///***************************************************/

        //public static LinkConstraint CreateFixed()    // TODO: this should be probably be in the engine (tis is a factory) although I am happy to discuss this one
        //{
        //    return new LinkConstraint {
        //        XtoX = true,
        //        YtoY = true,
        //        ZtoZ = true,
        //        XtoYY = true,
        //        XtoZZ = true,
        //        YtoXX = true,
        //        YtoZZ = true,
        //        ZtoXX = true,
        //        ZtoYY = true,
        //        XXtoXX = true,
        //        YYtoYY = true,
        //        ZZtoZZ = true,
        //        Name = "Fixed"
        //    };
        //}

        //public static LinkConstraint Pinned
        //{
        //    get
        //    {
        //        bool[] fixities = new bool[12];

        //        for (int i = 0; i < 9; i++)
        //        {
        //            fixities[i] = true;
        //        }

        //        LinkConstraint constr = new LinkConstraint(fixities);
        //        constr.Name = "Pinned";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint XYPlane
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();

        //        constr.XtoX = true;
        //        constr.XtoZZ = true;
        //        constr.YtoY = true;
        //        constr.YtoZZ = true;
        //        constr.ZZtoZZ = true;
        //        constr.Name = "xy-Plane";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint YZPlane
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.YtoY = true;
        //        constr.YtoXX = true;
        //        constr.ZtoZ = true;
        //        constr.ZtoXX = true;
        //        constr.XXtoXX = true;
        //        constr.Name = "yz-Plane";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint ZXPlane
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.XtoX = true;
        //        constr.XtoYY = true;
        //        constr.ZtoZ = true;
        //        constr.ZtoYY = true;
        //        constr.YYtoYY = true;
        //        constr.Name = "zx-Plane";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint XYPlanePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();

        //        constr.XtoX = true;
        //        constr.XtoZZ = true;
        //        constr.YtoY = true;
        //        constr.YtoZZ = true;
        //        constr.Name = "xy-Plane Pin";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint YZPlanePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.YtoY = true;
        //        constr.YtoXX = true;
        //        constr.ZtoZ = true;
        //        constr.ZtoXX = true;
        //        constr.Name = "yz-Plane Pin";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint ZXPlanePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.XtoX = true;
        //        constr.XtoYY = true;
        //        constr.ZtoZ = true;
        //        constr.ZtoYY = true;
        //        constr.Name = "zx-Plane Pin";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint XPlate
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.XtoX = true;
        //        constr.XtoYY = true;
        //        constr.XtoZZ = true;
        //        constr.YYtoYY = true;
        //        constr.ZZtoZZ = true;
        //        constr.Name = "x-Plate";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint YPlate
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.YtoY = true;
        //        constr.YtoXX = true;
        //        constr.YtoZZ = true;
        //        constr.XXtoXX = true;
        //        constr.ZZtoZZ = true;
        //        constr.Name = "y-Plate";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint ZPlate
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.ZtoZ = true;
        //        constr.ZtoXX = true;
        //        constr.ZtoYY = true;
        //        constr.XXtoXX = true;
        //        constr.YYtoYY = true;
        //        constr.Name = "z-Plate";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint XPlatePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.XtoX = true;
        //        constr.XtoYY = true;
        //        constr.XtoZZ = true;
        //        constr.Name = "x-Plate Pin";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint YPlatePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.YtoY = true;
        //        constr.YtoXX = true;
        //        constr.YtoZZ = true;
        //        constr.Name = "y-Plate Pin";
        //        return constr;
        //    }
        //}

        //public static LinkConstraint ZPlatePin
        //{
        //    get
        //    {
        //        LinkConstraint constr = new LinkConstraint();
        //        constr.ZtoZ = true;
        //        constr.ZtoXX = true;
        //        constr.ZtoYY = true;
        //        constr.Name = "z-Plate Pin";
        //        return constr;
        //    }
        //}
    }
}


        //#region Properties
        ///*********************************************/
        ///*** Properties            *******************/
        ///*********************************************/

        //public bool XtoX
        //{
        //    get { return m_constriants[0]; }
        //    set { m_constriants[0] = value; }
        //}

        //public bool XtoYY
        //{
        //    get { return m_constriants[1]; }
        //    set { m_constriants[1] = value; }
        //}

        //public bool XtoZZ
        //{
        //    get { return m_constriants[2]; }
        //    set { m_constriants[2] = value; }
        //}

        //public bool YtoY
        //{
        //    get { return m_constriants[3]; }
        //    set { m_constriants[3] = value; }
        //}

        //public bool YtoXX
        //{
        //    get { return m_constriants[4]; }
        //    set { m_constriants[4] = value; }
        //}

        //public bool YtoZZ
        //{
        //    get { return m_constriants[5]; }
        //    set { m_constriants[5] = value; }
        //}

        //public bool ZtoZ
        //{
        //    get { return m_constriants[6]; }
        //    set { m_constriants[6] = value; }
        //}

        //public bool ZtoXX
        //{
        //    get { return m_constriants[7]; }
        //    set { m_constriants[7] = value; }
        //}

        //public bool ZtoYY
        //{
        //    get { return m_constriants[8]; }
        //    set { m_constriants[8] = value; }
        //}

        //public bool XXtoXX
        //{
        //    get { return m_constriants[9]; }
        //    set { m_constriants[9] = value; }
        //}

        //public bool YYtoYY
        //{
        //    get { return m_constriants[10]; }
        //    set { m_constriants[10] = value; }
        //}

        //public bool ZZtoZZ
        //{
        //    get { return m_constriants[11]; }
        //    set { m_constriants[11] = value; }
        //}

        //#endregion

    //    #region Constructors
    //    /*********************************************/
    //    /*** Constructurs          *******************/
    //    /*********************************************/

    //    public LinkConstraint()
    //    {
    //        m_constriants = new bool[12];
    //    }

    //    public LinkConstraint(IEnumerable<bool> fixities)
    //    {
    //        m_constriants = fixities.ToArray();
    //    }


        

    //    #endregion

    //    #region Public Method
    //    /*********************************************/
    //    /*** Methods               *******************/
    //    /*********************************************/

    //    public bool[] GetBoolArray()
    //    {
    //        return m_constriants;
    //    }

    //    public override string ToString()
    //    {
    //        if (!string.IsNullOrWhiteSpace(Name))
    //            return Name;

    //        return base.ToString();
    //    }

    //    #endregion

    //    #region Private Fields

    //    /*********************************************/
    //    /*** Private fields        *******************/
    //    /*********************************************/

    //    private bool[] m_constriants;

    //    #endregion
    //}
//}
