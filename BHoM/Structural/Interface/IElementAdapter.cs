//using BH.oM.Structural;
//using BH.oM.Structural.Loads;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BH.oM.Structural.Elements;
//using BH.oM.Base;

//namespace BH.oM.Structural.Interface
//{
//    public enum ObjectSelection //TODO: remove?
//    {
//        All,
//        Selected,
//        FromInput
//    }

//    /// <summary>
//    /// An interface class which should be inherited by an external application in order to import and export BHoMObjects
//    /// </summary>
//    public interface IElementAdapter //TODO: Probably needs to be deleted or moved to BHoM_Adapter
//    {
//        string Filename { get; }

//        ObjectSelection Selection { get; set; }

//        List<string> GetNodes(out List<Node> nodes, List<string> ids = null);
//        List<string> GetBars(out List<Bar> bars, List<string> ids = null);
//        List<string> GetPanels(out List<PanelPlanar> panels, List<string> ids = null);
//        List<string> GetFEMeshes(out List<FEMesh> meshes, List<string> ids = null);
//        List<string> GetOpenings(out List<Opening> opening, List<string> ids = null);
//        List<string> GetLevels(out List<Storey> levels, List<string> ids = null);
//        List<string> GetGrids(out List<Grid> grids, List<string> ids = null);
//        List<string> GetRigidLinks(out List<RigidLink> links, List<string> ids = null);
//        List<string> GetGroups(out List<BHoMGroup> groups, List<string> ids = null);
//        List<string> GetLoadcases(out List<ICase> cases);
//        bool GetLoads(out List<ILoad> loads, List<Loadcase> ids = null);

//        bool SetNodes(List<Node> nodes, out List<string> ids);
//        bool SetBars(List<Bar> bars, out List<string> ids);
//        bool SetPanels(List<PanelPlanar> panels, out List<string> ids);
//        bool SetFEMeshes(List<FEMesh> meshes, out List<string> ids);
//        bool SetOpenings(List<Opening> opening, out List<string> ids);
//        bool SetLevels(List<Storey> stores, out List<string> ids);
//        bool SetGrids(List<Grid> grid, out List<string> ids);
//        bool SetRigidLinks(List<RigidLink> rigidLinks, out List<string> ids);
//        bool SetGroups(List<BHoMGroup> groups, out List<string> ids);

//        bool SetLoads(List<ILoad> loads);
//        bool SetLoadcases(List<ICase> cases);
//    }
//}
