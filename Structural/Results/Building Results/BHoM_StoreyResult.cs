using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results.Building
{
    /// <summary>
    /// Results for building storeys for use in multi/tall building post processing
    /// </summary>
    public class StoreyResult
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; private set; }
      
        /// <summary>Storey drift in X (refer to ASCE7 for basis)</summary>
        public double DriftX { get; private set; }
        /// <summary>Storey drift in Y (refer to ASCE7 for basis)</summary>
        public double DriftY { get; private set; }

        /// <summary>Storey drift ratio in X (drift / storey height)</summary>
        public double DriftRatioX { get; private set; }
        /// <summary>Storey drift ratio in Y (drift / storey height)</summary>
        public double DriftRatioY { get; private set; }

        /// <summary>Maximum displacement in X of any point (node) in the story</summary>
        public double MaximumNodalDisplacementX { get; private set; }
        /// <summary>Maximum displacement in Y of any point (node) in the story</summary>
        public double MaximumNodalDisplacementY { get; private set; }

        /// <summary>Minimum displacement in X of any point (node) in the story</summary>
        public double MinimumNodalDisplacementX { get; private set; }
        /// <summary>Minimum displacement in Y of any point (node) in the story</summary>
        public double MinimumNodalDisplacementY { get; private set; }

        /// <summary>Storey shear in X</summary>
        public double ShearX { get; private set; }
        /// <summary>Storey shear in Y</summary>
        public double ShearY { get; private set; }

        /// <summary>Total shear force in X in storey columns</summary>
        public double ShearToColumnsX { get; private set; }
        /// <summary>Total shear force in Y in storey columns</summary>
        public double ShearToColumnsY { get; private set; }
        /// <summary>Total shear force in X in storey walls</summary>
        public double ShearToWallsX { get; private set; }
        /// <summary>Total shear force in Y in storey walls</summary>
        public double ShearToWallsY { get; private set; }

        /// <summary>Total axial force in columns at level</summary>
        public double AxialToColumns { get; private set; }
        /// <summary>Total axial force in walls at level</summary>
        public double AxialToWalls { get; private set; }

        /// <summary>Mass of storey used in seismic calculation</summary>
        public BHoM.Geometry.Vector SeismicMass { get; private set; }

        /// <summary>Centre of rigidity of the storey</summary>
        public BHoM.Geometry.Point CentreOfRigidity { get; private set; }
        /// <summary>Centre of mass of the storey</summary>
        public BHoM.Geometry.Point CentreOfGravity { get; private set; }

        /// <summary>Eccentricity of the storey (vector distance between COG and COR)</summary>
        public BHoM.Geometry.Vector Eccentricity { get; private set; }

        /// <summary>Moment of inertia of a storey</summary>
        public BHoM.Geometry.Vector MomentOfInertia { get; private set; }

        
        /// <summary>
        /// Constructs an empty storey result and set the objects later
        /// </summary>
        public StoreyResult()
        {
        }

        /// <summary>
        /// Constructs a storey result using a BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public StoreyResult(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }

        /// <summary>
        /// Constructs a storey result by loadcase name and number. If name or number are not know, set to "" and 0 respectively.
        /// </summary>
        /// <param name="loadcaseNumber"></param>
        /// <param name="loadcaseName"></param>
        public StoreyResult(int loadcaseNumber, string loadcaseName)
        {
            this.Loadcase = new Loads.Loadcase(loadcaseNumber, loadcaseName);
        }

        /// <summary>
        /// Sets the loadcase by using an existing BHoM loadcase object
        /// </summary>
        /// <param name="loadcase"></param>
        public void SetLoadcase(BHoM.Structural.Loads.Loadcase loadcase)
        {
            this.Loadcase = loadcase;
        }

        /// <summary>
        /// Sets the loadcase by constructing a new BHoM loadcase object
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public void SetLoadcase(int number, string name)
        {
            this.Loadcase = new Loads.Loadcase(number, name);
        }

        /// <summary>
        /// Set storey drifts
        /// </summary>
        /// <param name="driftX"></param>
        /// <param name="driftY"></param>
        public void SetDrift(double driftX, double driftY)
        {
            this.DriftX = driftX;
            this.DriftY = driftY;
        }

        /// <summary>
        /// Sets storey drift ratios
        /// </summary>
        /// <param name="driftRatioX"></param>
        /// <param name="driftRatioY"></param>
        public void SetDriftRatio(double driftRatioX, double driftRatioY)
        {
            this.DriftRatioX = driftRatioX;
            this.DriftRatioY = driftRatioY;
        }

        /// <summary>
        /// Sets the maximum nodal displacements for a given storey
        /// (maximum nodal translations)
        /// </summary>
        /// <param name="maxUX"></param>
        /// <param name="maxUY"></param>
        public void SetMaximumNodalDisplacements(double maxUX, double maxUY)
        {
            this.MaximumNodalDisplacementX = maxUX;
            this.MaximumNodalDisplacementY = maxUY;
        }

        /// <summary>
        /// Sets the Minimum nodal displacements for a given storey
        /// (Minimum nodal translations)
        /// </summary>
        /// <param name="minUX"></param>
        /// <param name="minUY"></param>
        public void SetMinimumNodalDisplacements(double minUX, double minUY)
        {
            this.MinimumNodalDisplacementX = minUX;
            this.MinimumNodalDisplacementY = minUY;
        }

        /// <summary>
        /// Sets storey shears
        /// </summary>
        /// <param name="shearX"></param>
        /// <param name="shearY"></param>
        public void SetShear(double shearX, double shearY)
        {
            this.ShearX = shearX;
            this.ShearY = shearY;
        }

        /// <summary>
        /// Sets the total shear forces in walls and columns for a given storey
        /// (to show relative distribution)
        /// </summary>
        /// <param name="shearToColumnsX"></param>
        /// <param name="shearToColumnsY"></param>
        /// <param name="shearToWallsX"></param>
        /// <param name="shearToWallsY"></param>
        public void SetShearDistribution(double shearToColumnsX, double shearToColumnsY, double shearToWallsX, double shearToWallsY)
        {
            this.ShearToColumnsX = shearToColumnsX;
            this.ShearToColumnsY = shearToColumnsY;
            this.ShearToWallsX = shearToWallsX;
            this.ShearToWallsY = ShearToWallsY;
        }

        /// <summary>
        /// Sets the total axial forces in walls and columns for a given storey
        /// (to show relative distribution)
        /// </summary>
        /// <param name="axialToColumns"></param>
        /// <param name="axialToWalls"></param>
        public void SetAxialDistribution(double axialToColumns, double axialToWalls)
        {
            this.AxialToColumns = axialToColumns;
            this.AxialToWalls = AxialToWalls;
        }

        /// <summary>
        /// Sets the seismic mass for a given storey by constructing a BHoM
        /// vector object
        /// </summary>
        /// <param name="massX"></param>
        /// <param name="massY"></param>
        /// <param name="massZ"></param>
        public void SetSeismicMass(double massX, double massY, double massZ)
        {
            this.SeismicMass = new BHoM.Geometry.Vector(massX, massY, massZ);
        }

        /// <summary>
        /// Sets the centre of rigidity of a given storey by constructing 
        /// a BHoM point object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetCentreOfRigidity(double x, double y, double z)
        {
            this.CentreOfRigidity = new BHoM.Geometry.Point(x, y, z);
        }

        /// <summary>
        /// Sets the centre of gravity of a given storey by constructing
        /// a BHoM point object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetCentreOfGravity(double x, double y, double z)
        {
            this.CentreOfGravity = new BHoM.Geometry.Point(x, y, z);
        }

        /// <summary>
        /// Sets the eccentricity (distance between COG and COR) for a
        /// given storey by constructing a BHoM vector object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetEccentricity(double ex, double ey, double ez)
        {
            this.Eccentricity = new BHoM.Geometry.Vector(ex, ey, ez);
        }

        public void SetMomentOfIntertia(double ix, double iy, double iz)
        {
            this.MomentOfInertia = new BHoM.Geometry.Vector(ix, iy, iz);
        }

  


//  Private Sub RunScript(ByVal Bar_Nums_or_Types As List(Of String), ByVal Load_Cases As String, ByVal Div_Points As Double, ByVal Activate As Boolean, ByRef FX_Axial_kN As Object, ByRef FY_Shear_kN As Object, ByRef FZ_Shear_kN As Object, ByRef MX_Torsion_kNm As Object, ByRef MY_Bending_kNm As Object, ByRef MZ_Bending_kNm As Object, ByRef SMax_Nmm2 As Object, ByRef SMin_Nmm2 As Object, ByRef SAxial_Nmm2 As Object, ByRef Update As Object) 
//    Dim robot As New RobotApplication
//    If Activate = True Then
//      If robot.Project.Structure.Results.Status = IRobotResultStatusType.I_RST_AVAILABLE Then
//        Dim bar_input_type As String
//        Dim num As int32
//        Dim bar_nums As String: bar_nums = ""
//        Try
//          num = CInt(bar_nums_or_types(0))
//          bar_input_type = "bar_nums"
//          For i As int32 = 0 To bar_nums_or_types.count - 1
//            bar_nums = bar_nums & "," & bar_nums_or_types(i)
//          Next i
//        Catch ex As exception
//          If bar_nums_or_types(0) = "all" Then
//            bar_nums = "all"
//            bar_input_type = "bar_nums"
//          Else
//            bar_input_type = "bar_type"
//          End If
//        End Try

//        Dim result_params As IRobotResultQueryParams
//        result_params = robot.CmpntFactory.Create(IRobotComponentType.I_CT_RESULT_QUERY_PARAMS)

//        Dim bar_sel As IRobotSelection
//        If bar_input_type = "bar_nums" Or bar_nums = "all" Then
//          bar_sel = robot.Project.Structure.Selections.Create(IRobotObjectType.I_OT_BAR)
//          bar_sel.FromText(bar_nums)
//        Else
//          bar_sel = robot.Project.Structure.Selections.Create(IRobotObjectType.I_OT_BAR)
//          For i As int32 = 0 To bar_nums_or_types.count - 1
//            bar_sel.Add(robot.Project.Structure.Selections.CreateByLabel(IRobotObjectType.I_OT_BAR, IRobotLabelType.I_LT_MEMBER_TYPE, bar_nums_or_types(i)))
//          Next i
//        End If
//        Dim cas_sel As IRobotSelection
//        cas_sel = robot.Project.Structure.Selections.Create(IRobotObjectType.I_OT_CASE)
//        cas_sel.FromText(Load_Cases)
//        Dim FX_Tree,FY_Tree,FZ_Tree,MX_Tree,MY_Tree,MZ_Tree,SMax_Tree,Smin_Tree,SX_Tree,Position_Tree As New Grasshopper.DataTree (Of Double)
//        With result_params
//          .ResultIds.SetSize(9)
//          .ResultIds.Set(1, IRobotExtremeValueType.I_EVT_FORCE_BAR_FX)
//          .ResultIds.Set(2, IRobotExtremeValueType.I_EVT_FORCE_BAR_FY)
//          .ResultIds.Set(3, IRobotExtremeValueType.I_EVT_FORCE_BAR_FZ)
//          .ResultIds.Set(4, IRobotExtremeValueType.I_EVT_FORCE_BAR_MX)
//          .ResultIds.Set(5, IRobotExtremeValueType.I_EVT_FORCE_BAR_MY)
//          .ResultIds.Set(6, IRobotExtremeValueType.I_EVT_FORCE_BAR_MZ)
//          .ResultIds.Set(7, IRobotExtremeValueType.I_EVT_STRESS_BAR_SMAX)
//          .ResultIds.Set(8, IRobotExtremeValueType.I_EVT_STRESS_BAR_SMIN)
//          .ResultIds.Set(9, IRobotExtremeValueType.I_EVT_STRESS_BAR_FX_SX)
//          .SetParam(IRobotResultParamType.I_RPT_BAR_DIV_COUNT, Div_Points)
//          .Selection.Set(IRobotObjectType.I_OT_BAR, bar_sel)
//          .Selection.Set(IRobotObjectType.I_OT_CASE, cas_sel)
//          .SetParam(IRobotResultParamType.I_RPT_MODE, 0)
//          .SetParam(IRobotResultParamType.I_RPT_MODE_CMB, IRobotModeCombinationType.I_MCT_CQC)
//          .SetParam(IRobotResultParamType.I_RPT_MULTI_THREADS, True)
//          .SetParam(IRobotResultParamType.I_RPT_THREAD_COUNT, 4)
//        End With

//        Dim row_set As New RobotResultRowSet
//        Dim query_return As New IRobotResultQueryReturnType
//        query_return = IRobotResultQueryReturnType.I_RQRT_MORE_AVAILABLE
//        Dim rserver As RobotResultServer: rserver = robot.Kernel.Structure.Results
//        Dim curr_bar As Double
//        Dim result_row As IRobotResultRow

//        While Not query_return = IRobotResultQueryReturnType.I_RQRT_DONE
//          query_return = rserver.Query(result_params, row_set)

//          Dim ok As Boolean
//          ok = row_set.MoveFirst
//          While ok
//            result_row = row_set.CurrentRow
//            curr_bar = result_row.GetParam(IRobotResultParamType.I_RPT_BAR)
//            Dim branch As New GH_Path(curr_bar)
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_FX) Then
//              FX_Tree.Add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_FX) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_FY) Then
//              FY_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_FY) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_FZ) Then
//              FZ_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_FZ) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_MX) Then
//              MX_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_MX) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_MY) Then
//              MY_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_MY) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_FORCE_BAR_MZ) Then
//              MZ_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_FORCE_BAR_MZ) / 1000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_STRESS_BAR_SMAX) Then
//              SMax_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_STRESS_BAR_SMAX) / 1000000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_STRESS_BAR_SMIN) Then
//              Smin_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_STRESS_BAR_SMIN) / 1000000, branch)
//            End If
//            If result_row.IsAvailable(IRobotExtremeValueType.I_EVT_STRESS_BAR_FX_SX) Then
//              SX_Tree.add(result_row.GetValue(IRobotExtremeValueType.I_EVT_STRESS_BAR_FX_SX) / 1000000, branch)
//            End If
//            ok = row_set.MoveNext
//            result_row = Nothing
//          End While
//          row_set.Clear()
//          row_set = Nothing
//        End While

//        FX_Axial_kN = FX_Tree
//        FY_Shear_kN = FY_Tree
//        FZ_Shear_kN = FZ_Tree
//        MX_Torsion_kNm = MX_Tree
//        MY_Bending_kNm = MY_Tree
//        MZ_Bending_kNm = MZ_Tree
//        Smax_Nmm2 = Smax_Tree
//        Smin_Nmm2 = Smin_Tree
//        Saxial_Nmm2 = SX_Tree
//        Update = True
//      Else
//        Update = False
//      End If
//    End If
//  End Sub 

//  Private Sub RunScript(ByVal Import_Nodes As Boolean, ByVal Import_Bars As Boolean, ByVal Import_Bar_Properties As Object, ByVal Import_Panels As Object, ByVal Import_Contours As Object, ByVal Import_FE As Boolean, ByVal Activate As Object, ByRef Panel_Edges As Object, ByRef Panel_Numbers As Object, ByRef Panel_Thickness As Object, ByRef Contours As Object, ByRef Contour_Numbers As Object, ByRef Nodes As Object, ByRef Node_Numbers As Object, ByRef Bars As Object, ByRef Bar_Numbers As Object, ByRef Bar_Sections As Object, ByRef Bar_Types As Object, ByRef FE_Mesh As Object) 
//    If activate = True Then

//      Dim robot As New RobotApplication
//      Dim bar_serv As RobotBarServer: bar_serv = robot.Project.Structure.Bars
//      Dim nod_serv As RobotNodeServer: nod_serv = robot.Project.Structure.Nodes
//      Dim rstructure As RobotStructure: rstructure = robot.Project.Structure
//      Dim panel_col As IRobotCollection
//      Dim panel_sel, bar_sel, nod_sel, FE_sel, cas_sel As RobotSelection
//      Dim contour_col As IRobotCollection
//      Dim contour_sel As RobotSelection
//      Dim r_panel As RobotObjObject
//      Dim r_contour As RobotObjObject
//      Dim panel_edge As RobotObjEdge
//      Dim contour_edge As RobotObjEdge
//      Dim edge_path_col As IRobotCollection
//      Dim point_3d As IRobotGeoPoint3D
//      Dim edge_col As IRobotCollection
//      Dim panel_plines As New list (Of Polyline)
//      Dim contour_plines As New list (Of polyline)
//      Dim kounta As int32: kounta = 0
//      Dim pnts As New list(Of Point3d)
//      Dim panel_numbers_list As New list (Of int32)
//      Dim panel_thickness_list As New list (Of String)
//      Dim bar_nos As New list (Of int32)
//      Dim contour_numbers_list As New list (Of int32)
//      Dim bar_list As New list(Of line)
//      Dim bar_num_list As New list (Of int32)
//      Dim bar_sections_list As New list (Of string)
//      Dim nod_list As New list(Of Point3d)
//      Dim nod_num_list As New list(Of int32)
//      Dim FE_list As New list(Of system.Object)
//      Dim FE_num_list As New list(Of Double)
//      Dim result_params As IRobotResultQueryParams: result_params = robot.kernel.CmpntFactory.Create(IRobotComponentType.I_CT_RESULT_QUERY_PARAMS)
//      Dim query_return As IRobotResultQueryReturnType
//      Dim ok As Boolean
//      Dim result_row As RobotResultRow
//      Dim nod_num, bar_num, panel_num As Double
//      Dim nod_tree As New Grasshopper.DataTree(Of point3d)
//      Dim mface_tree As New Grasshopper.DataTree(Of MeshFace)
//      Dim msh_tree As New Grasshopper.DataTree(Of Mesh)

//      'Import Robot nodes. If mesh is also required, nodes need to be imported first

//      If Import_Nodes = True Or Import_FE Or Import_Bars = True Then
//        nod_sel = rstructure.Selections.CreateFull(IRobotObjectType.I_OT_NODE)
//        result_params.ResultIds.SetSize(3)
//        result_params.ResultIds.Set(1, 0)
//        result_params.ResultIds.Set(2, 1)
//        result_params.ResultIds.Set(3, 2)
//        result_params.Selection.Set(IRobotObjectType.I_OT_NODE, nod_sel)
//        result_params.SetParam(IRobotResultParamType.I_RPT_MULTI_THREADS, True)
//        result_params.SetParam(IRobotResultParamType.I_RPT_THREAD_COUNT, 4)
//        query_return = IRobotResultQueryReturnType.I_RQRT_MORE_AVAILABLE
//        Dim row_set As New RobotResultRowSet
//        While Not query_return = IRobotResultQueryReturnType.I_RQRT_DONE
//          query_return = rstructure.Results.Query(result_params, row_set)
//          ok = row_set.MoveFirst
//          While ok
//            result_row = row_set.CurrentRow
//            nod_num = result_row.GetParam(IRobotResultParamType.I_RPT_NODE)
//            Dim branch As New GH_Path(nod_num)
//            Dim pnt As New point3d(row_set.CurrentRow.GetValue(0), row_set.CurrentRow.GetValue(1), row_set.CurrentRow.GetValue(2))
//            nod_tree.Add(pnt, branch)
//            kounta = kounta + 1
//            ok = row_set.MoveNext
//          End While
//          row_set.Clear()
//        End While
//        result_params.Reset
//      End If

//      'Imports the bars from Robot - bars only no properties

//      dim nod1, nod2 As int32
//      If Import_Bars = True And Not import_bar_properties = True Then
//        Dim nod1_id As int32: nod1_id = 15
//        Dim nod2_id As int32: nod2_id = 16
//        Dim length_id As int32: length_id = 17
//        Dim gamma_id As int32: gamma_id = 20
//        Dim area_id As int32: area_id = 27
//        Dim Ix_id As int32: Ix_id = 30
//        Dim Iy_id As int32: Iy_id = 31
//        Dim Iz_id As int32: Iz_id = 32
//        Dim HY_id As int32: HY_id = 33
//        Dim HZ_id As int32: HZ_id = 34
//        Dim VY_id As int32: VY_id = 35
//        Dim VZ_id As int32: VZ_id = 36
//        Dim VPY_id As int32: VPY_id = 37
//        Dim VPZ_id As int32: VPZ_id = 38
//        Dim Wx_id As int32: Wx_id = 39
//        Dim Wy_id As int32: Wy_id = 40
//        Dim Wz_id As int32: Wz_id = 41
//        Dim SurfaceArea_id As int32: SurfaceArea_id = 42
//        Dim E_id As int32: E_id = 76
//        Dim G_id As int32: G_id = 77
//        Dim Poissons_id As int32: Poissons_id = 78
//        Dim ThermalCoeff_id As int32: ThermalCoeff_id = 79
//        Dim Density_id As int32: Density_id = 80
//        Dim YieldStrength_id As int32: YieldStrength_id = 81
//        bar_sel = rstructure.Selections.CreateFull(IRobotObjectType.I_OT_BAR)
//        cas_sel = rstructure.Selections.Create(IRobotObjectType.I_OT_CASE)
//        cas_sel.FromText("1")
//        With result_params
//          .ResultIds.SetSize(6)
//          .ResultIds.Set(1, IRobotExtremeValueType.I_EVT_FORCE_BAR_FX)
//          .ResultIds.Set(2, nod1_id)
//          .ResultIds.Set(3, nod2_id)
//          .ResultIds.Set(4, gamma_id)
//          .ResultIds.Set(5, 269)
//          .ResultIds.Set(6, 270)
//          .SetParam(IRobotResultParamType.I_RPT_BAR_DIV_COUNT, 1)
//          .SetParam(IRobotResultParamType.I_RPT_BAR_RELATIVE_POINT, 0.5)
//          .Selection.Set(IRobotObjectType.I_OT_BAR, bar_sel)
//          .Selection.Set(IRobotObjectType.I_OT_CASE, cas_sel)
//          .SetParam(IRobotResultParamType.I_RPT_MULTI_THREADS, True)
//          .SetParam(IRobotResultParamType.I_RPT_THREAD_COUNT, 4)
//        End With
//        query_return = IRobotResultQueryReturnType.I_RQRT_MORE_AVAILABLE
//        Dim row_set As New RobotResultRowSet
//        While Not query_return = IRobotResultQueryReturnType.I_RQRT_DONE
//          query_return = rstructure.Results.Query(result_params, row_set)
//          ok = row_set.MoveFirst
//          While ok
//            result_row = row_set.CurrentRow
//            bar_num = result_row.GetParam(IRobotResultParamType.I_RPT_BAR)
//            Dim bar_branch As New GH_Path(bar_num)
//            nod1 = result_row.GetValue(nod1_id)
//            nod2 = result_row.GetValue(nod2_id)
//            Dim nod1_branch As New GH_Path(nod1)
//            Dim nod2_branch As New GH_Path(nod2)
//            Dim bar As New Line(nod_tree.Branch(nod1_branch).item(0), nod_tree.Branch(nod2_branch).item(0))
//            bar_list.add(bar)
//            bar_num_list.add(bar_num)
//            ok = row_set.MoveNext
//          End While
//          row_set.Clear()
//        End While
//        result_params.Reset
//      End If

//      'Import bars with properties (slower method)

//      Dim bar_col As IRobotCollection
//      Dim bar_numbers_list As New list(Of int32)
//      Dim r_bar As RobotBar
//      Dim start_nod As Point3d
//      Dim end_nod As Point3d
//      Dim bar_types_list As New list(Of String)
//      If import_bars = True And import_bar_properties = True Then
//        bar_col = robot.Project.Structure.Bars.GetAll
//        For i As int32 = 1 To bar_col.Count
//          r_bar = bar_col.Get(i)
//          bar_numbers_list.add(r_bar.number)
//          bar_sections_list.add(r_bar.GetLabel(IRobotLabelType.I_LT_BAR_SECTION).Name)
//          bar_types_list.add(r_bar.GetLabel(IRobotLabelType.I_LT_MEMBER_TYPE).Name)
//          Dim branch1 As New GH_Path(r_bar.StartNode)
//          start_nod = nod_tree.Branch(branch1).item(0)
//          Dim branch2 As New GH_Path(r_bar.EndNode)
//          end_nod = nod_tree.Branch(branch2).item(0)
//          Dim start_pnt As New Point3d(start_nod.X, start_nod.Y, start_nod.Z)
//          Dim end_pnt As New point3d(end_nod.X, end_nod.Y, end_nod.Z)
//          Dim bar_cl As New line(start_pnt, end_pnt)
//          bar_list.add(bar_cl)
//        Next i
//      End If


//      'Import finite elements (nodes must be imported first)

//      If Import_FE = True Then
//        FE_sel = rstructure.Selections.CreateFull(IRobotObjectType.I_OT_FINITE_ELEMENT)
//        Dim dummy_pnt As New point3d(0, 0, 0)
//        For i As int32 = 0 To nod_tree.Path(nod_tree.BranchCount - 1).Indices(0)
//          Dim branch As New GH_Path(i)
//          If nod_tree.PathExists(i) Then
//            nod_list.Add(nod_tree.Branch(branch)(0))
//          Else
//            nod_list.add(dummy_pnt)
//          End If
//        Next i
//        result_params.ResultIds.SetSize(5)
//        result_params.ResultIds.Set(1, 564)
//        result_params.ResultIds.Set(2, 565)
//        result_params.ResultIds.Set(3, 566)
//        result_params.ResultIds.Set(4, 567)
//        result_params.ResultIds.Set(5, 1252)
//        result_params.Selection.Set(IRobotObjectType.I_OT_FINITE_ELEMENT, FE_sel)
//        result_params.SetParam(IRobotResultParamType.I_RPT_MULTI_THREADS, True)
//        result_params.SetParam(IRobotResultParamType.I_RPT_THREAD_COUNT, 4)
//        result_params.SetParam(IRobotResultParamType.I_RPT_SMOOTHING, IRobotFeResultSmoothing.I_FRS_IN_ELEMENT_CENTER)
//        query_return = IRobotResultQueryReturnType.I_RQRT_MORE_AVAILABLE
//        Dim row_set As New RobotResultRowSet
//        While query_return <> IRobotResultQueryReturnType.I_RQRT_DONE
//          query_return = robot.Project.Structure.Results.Query(result_params, row_set)
//          ok = row_set.MoveFirst
//          While ok
//            result_row = row_set.CurrentRow
//            panel_num = result_row.GetValue(1252)
//            Dim branch As New GH_Path(panel_num)
//            If result_row.IsAvailable(566) Then
//              If result_row.IsAvailable(567)
//                Dim mface As New MeshFace(result_row.GetValue(564), result_row.GetValue(565), result_row.GetValue(566), result_row.GetValue(567))
//                mface_tree.add(mface, branch)
//              Else
//                Dim mface As New MeshFace(result_row.GetValue(564), result_row.GetValue(565), result_row.GetValue(566))
//                mface_tree.add(mface, branch)
//              End If
//            End If
//            ok = row_set.MoveNext
//          End While
//          row_set.Clear
//        End While
//        result_params.Reset

//        'Create Rhino meshes from the nodes and finite element data (the finite element data includes a list of nodes each element is connected to)

//        For i As int32 = 0 To mface_tree.BranchCount - 1
//          Dim msh As New Mesh
//          msh.Vertices.AddVertices(nod_list)
//          msh.Faces.AddFaces(mface_tree.Branch(i))
//          msh.Vertices.CullUnused
//          Dim branch As New GH_Path(mface_tree.Path(i).Indices(0))
//          msh_tree.add(msh, branch)
//        Next i
//      End If



//      If import_panels = True Then
//        panel_sel = robot.Project.Structure.Selections.CreateFull(IRobotObjectType.I_OT_PANEL)
//        panel_col = robot.Project.Structure.Objects.GetMany(panel_sel)
//        For i As int32 = 1 To panel_col.Count
//          kounta = 0
//          r_panel = panel_col.Get(i)
//          panel_numbers_list.add(r_panel.Number)
//          panel_thickness_list.add(r_panel.GetLabel(IRobotLAbelType.I_LT_PANEL_THICKNESS).Name)
//          edge_col = r_panel.Main.Edges
//          For j As int32 = 1 To edge_col.Count
//            panel_edge = edge_col.Get(j)
//            edge_path_col = panel_edge.Path
//            For k As int32 = 1 To edge_path_col.Count
//              kounta = kounta + 1
//              point_3D = edge_path_col.Get(k)
//              Dim pnt As New Point3d(point_3d.X, point_3d.Y, point_3d.Z)
//              pnts.add(pnt)
//            Next k
//          Next j
//          Dim pline As New Polyline(pnts)
//          pline.Insert(kounta, pline.First)
//          panel_plines.add(pline)
//          pnts.clear
//        Next i
//      End If

//      'Imports contours from Robot

//      If import_contours = True Then
//        contour_sel = robot.Project.Structure.Selections.CreateFull(IRobotObjectType.I_OT_GEOMETRY)
//        contour_col = robot.Project.Structure.Objects.getmany(contour_sel)
//        For i As int32 = 1 To contour_col.Count
//          kounta = 0
//          r_contour = contour_col.Get(i)
//          If r_contour.Main.Geometry.Type = IRobotGeoObjectType.I_GOT_CONTOUR Then
//            contour_numbers_list.add(r_contour.Number)
//            edge_col = r_contour.Main.Edges
//            For j As int32 = 1 To edge_col.Count
//              contour_edge = edge_col.Get(j)
//              edge_path_col = contour_edge.Path
//              For k As int32 = 1 To edge_path_col.Count
//                kounta = kounta + 1
//                point_3d = edge_path_col.Get(k)
//                Dim pnt As New point3d(point_3d.X, point_3d.Y, point_3d.Z)
//                pnts.add(pnt)
//              Next k
//            Next j
//            Dim pline As New polyline(pnts)
//            pline.Insert(kounta, pline.First)
//            contour_plines.add(pline)
//            pnts.clear
//          End If
//        Next i
//      End If

//      'Convert the node tree back to a list, and create a second list (same order) containing the node numbers)

//      nod_list.Clear
//      For i As int32 = 0 To nod_tree.BranchCount - 1
//        nod_list.add(nod_tree.Branch(i).item(0))
//        nod_num_list.add(nod_tree.Path(i).Indices(0))
//      Next i

//      panel_edges = panel_plines
//      panel_numbers = panel_numbers_list
//      panel_thickness = panel_thickness_list
//      contours = contour_plines
//      contour_numbers = contour_numbers_list
//      If import_nodes = True Then nodes = nod_list
//      If import_nodes = True Then node_numbers = nod_num_list
//      bars = bar_list
//      bar_numbers = bar_num_list
//      bar_sections = bar_sections_list
//      bar_types = bar_types_list
//      FE_mesh = msh_tree

//    End If
//  End Sub 

//  '<Custom additional code> 

//  '</Custom additional code> 
//End Class
    }
}
