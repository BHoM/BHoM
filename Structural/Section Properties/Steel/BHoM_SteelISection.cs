using BHoM.Materials;

namespace BHoM.Structural.SectionProperties 
{
    /// <summary>
    /// 
    /// </summary>
     public abstract class SteelISection : SectionProperty
    {
        /// <summary></summary>
        public SteelISection() : base()
        {
            Type = "SteelISection";
        }

        /// <summary></summary>
        //public SteelISection(double D, double B, double t, double T) : base ()
        //{
        //    SetDimensions(D, B, t, T);
        //    Type = "SteelISection";
        //}

        ///// <summary></summary>
        //public SteelISection(int index, string name, Material mat, double area, double D, double B, double t, double T)
        //    : base(index, name, area, mat)
        //{
        //    SetDimensions(D, B, t, T);
        //    Type = "SteelISection";
        //}

        ///// <summary></summary>
        //public SteelISection(int index, string name, Material mat, double area, double iyy, double izz, double j, double D, double B, double t,
        //    double T)
        //    : base(index, name, area, iyy, izz, j, mat)
        //{
        //    SetDimensions(D, B, t, T);
        //    Type = "SteelISection";
        //}

        ///// <summary></summary>
        //public SteelISection(int index, string name, string desc, int matIndex, string mfType, double area, double D, double B, double tw, double tf, double rootR)
        //    : this()
        //{
        //    SetDimensions(D, B, tw, tf, rootR);

        //    Index = index;
        //    Name = name;
        //    Description = desc;
        //    MatIndex = matIndex;

        //    if (mfType != "-")
        //        SetManufactureType(mfType);

        //    Area = area;
        //    Type = "SteelISection";
        //}

        ///// <summary></summary>
        //public SteelISection(int index, string name, Material mat, double area, double iyy, double izz, double j, double D, double B, double t,
        //    double T, int sc, double wypl, double wyelmin, double wyeffmin, double wzpl, double wzelmin,
        //    double wzeffmin, double avy, double avz, double sy, double sz) :
        //    this(index, name, mat, area, iyy, izz, j,  D, B, t, T)
        //{
        //    base.SetDesignCheckData(sc, wypl, wyelmin, wyeffmin, wzpl, wzelmin, wzeffmin, avy, avz, sy, sz);
        //    Type = "SteelISection";
        //}

        /////////////////////////
        //// METHODS ////////////
        ///////////////////////// 



        ///// <summary>
        ///// Sets the dimensions of the section, setting root radius to 0
        ///// </summary>
        ///// <param name="nD">New depth</param>
        ///// <param name="nB">New breadth</param>
        ///// <param name="nt">New web thickness</param>
        ///// <param name="nT">New flange thickness</param>
        //protected override void SetDimensions(double nD, double nB, double nt, double nT)
        //{
        //    SetDimensions(nD, nB, nt, nT, 0);
        //}


        //public override void SetIdentities()
        //{
        //    Identities = new List<string> { "SteelISection", "SteelISection", "SteelISection", "UB / UC" };
        //}

        //protected override void SetUtilisationsPropertiesValidity()
        //{
        //    foreach (UtilisationEnvelope up in Utilisations)
        //        up.Valid = true;
        //}

        //public override void SetManufactureType(string mfType)
        //{
        //    base.ManufactureType = base.GetManufactureTypeRolledWelded(mfType);
        //}

        //public override void SetDefaultManufactureType()
        //{
        //    ManufactureType = StructuralComponents.ManufactureType.Rolled; //Default
        //}

        //public override void GenerateSectionCurve()
        //{
        //    SectionCurve = new List<CrocPoint>();

        //    SectionCurve.Add(new CrocPoint(this.B / 2, -this.D / 2, 0));
        //    SectionCurve.Add(new CrocPoint(-this.B / 2, -this.D / 2, 0));
        //    SectionCurve.Add(new CrocPoint(-this.B / 2, -this.D / 2 + this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(-this.tw / 2, -this.D / 2 + this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(-this.tw / 2, this.D / 2 - this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(-this.B / 2, this.D / 2 - this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(-this.B / 2, this.D / 2, 0));
        //    SectionCurve.Add(new CrocPoint(this.B / 2, this.D / 2, 0));
        //    SectionCurve.Add(new CrocPoint(this.B / 2, this.D / 2 - this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(this.tw / 2, this.D / 2 - this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(this.tw / 2, -this.D / 2 + this.tf, 0));
        //    SectionCurve.Add(new CrocPoint(this.B / 2, -this.D / 2 + this.tf, 0));
        //}


        //public override CrocMesh GenerateMesh(Beam beam)
        //{
        //    this.GenerateSectionCurve();

        //    CrocMesh mesh = new CrocMesh();

        //    int meshResolution = SectionCurve.Count;

        //    CrocVec zVec = beam.GetZVector();
        //    CrocVec xVec = new CrocVec(beam.EndNode.Pos - beam.StartNode.Pos);
        //    CrocVec yVec = CrocVec.CrossProduct(zVec, xVec);

        //    List<CrocPlane> plns = new List<CrocPlane>();


        //    zVec.Unitize();
        //    xVec.Unitize();

        //    plns.Add(new CrocPlane(yVec, zVec, beam.StartNode.Pos + zVec * ZOffsetS + xVec * CutbackS));
        //    plns.Add(new CrocPlane(yVec, zVec, beam.EndNode.Pos + zVec * ZOffsetE - xVec * CutbackE));


        //    foreach (CrocPoint pt in SectionCurve)
        //    {
        //        mesh.AddVertice(pt.TranslateToWorldSpace(plns[0]));
        //        mesh.AddVertice(pt.TranslateToWorldSpace(plns[1]));
        //    }


        //    //sides
        //    for (int i = 0; i < meshResolution; i++)
        //    {
        //        int[] meshFace;

        //        meshFace = new int[] { i * 2, i * 2 + 1, i * 2 + 3, i * 2 + 2 };

        //        if (i == meshResolution - 1) // if it's the last face in winding
        //            meshFace = new int[] { i * 2, i * 2 + 1, 1, 0 };


        //        mesh.AddFace(meshFace);
        //    }



        //    //ends


        //    int[][] endArray =
        //    {
        //        new int[]{0, 10,3,1},
        //        new int[]{1,3,2},
        //        new int[]{3,10,9,4},
        //        new int[]{5,4,6},
        //        new int[]{6,4,9,7},
        //        new int[]{9,8,7},
        //        new int[]{0,11,10}

        //    };

        //    foreach (int[] array in endArray)
        //    {
        //        int[] meshFace = array;

        //        //start end cap
        //        for (int i = 0; i < meshFace.Length; i++)
        //            meshFace[i] = meshFace[i] * 2;

        //        Array.Reverse(meshFace);

        //        mesh.AddFace(meshFace);

        //        int[] meshFace2 = new int[meshFace.Length];

        //        // end end cap
        //        for (int i = 0; i < meshFace.Length; i++)
        //            meshFace2[i] = meshFace[i] + 1;

        //        Array.Reverse(meshFace2);

        //        mesh.AddFace(meshFace2);
        //    }


        //    return mesh;
        //}
    //}

}
}