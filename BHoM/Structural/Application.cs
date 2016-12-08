using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Global;
using BHoM.Structural.Elements;
using BHoM.Structural.Loads;
using System.IO;
using BHoM.Structural.Interface;

namespace BHoM.Structural
{
    public class Application : IElementAdapter
    {
        private Project m_Project;

        public Application(string fileName)
        {
            Filename = fileName;
            using (StreamReader fs = new StreamReader(fileName))
            {
                string json = fs.ReadToEnd();
                m_Project = Project.FromJSON(json);
                fs.Close();
            }
            Identifier = FilterOption.Guid;
        }

        public string Filename
        {
            get;
            set;
        }

        public ObjectSelection Selection
        {
            get;
            set;
        }

        public FilterOption Identifier
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }


        public List<string> GetBars(out List<Bar> bars, List<string> ids = null)
        {
            ObjectManager<string, Bar> manager = new ObjectManager<string, Bar>(m_Project, Key, Identifier);
            bars = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetGrids(out List<Grid> grids, List<string> ids = null)
        {
            ObjectManager<string, Grid> manager = new ObjectManager<string, Grid>(m_Project, Key, Identifier);
            grids = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetGroups(out List<IGroup> groups, List<string> ids = null)
        {
            ObjectManager<string, IGroup> manager = new ObjectManager<string, IGroup>(m_Project, Key, Identifier);
            groups = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetLevels(out List<Storey> levels, List<string> ids = null)
        {
            ObjectManager<string, Storey> manager = new ObjectManager<string, Storey>(m_Project, Key, Identifier);
            levels = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetLoadcases(out List<ICase> cases)
        {
            ObjectManager<string, ICase> manager = new ObjectManager<string, ICase>(m_Project, Key, Identifier);
            cases = manager.ToList();
            return manager.Keys;
        }

        public bool GetLoads(out List<ILoad> loads, List<string> ids = null)
        {
            loads = new ObjectFilter<ILoad>(m_Project).ToList();
            return true;
        }

        public List<string> GetNodes(out List<Node> nodes, List<string> ids = null)
        {
            ObjectManager<string, Node> manager = new ObjectManager<string, Node>(m_Project, Key, Identifier);
            nodes = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetOpenings(out List<Opening> opening, List<string> ids = null)
        {
            ObjectManager<string, Opening> manager = new ObjectManager<string, Opening>(m_Project, Key, Identifier);
            opening = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetPanels(out List<Panel> panels, List<string> ids = null)
        {
            ObjectManager<string, Panel> manager = new ObjectManager<string, Panel>(m_Project, Key, Identifier);
            panels = manager.ToList();
            return manager.Keys;
        }

        public List<string> GetRigidLinks(out List<RigidLink> links, List<string> ids = null)
        {
            ObjectManager<string, RigidLink> manager = new ObjectManager<string, RigidLink>(m_Project, Key, Identifier);
            links = manager.ToList();
            return manager.Keys;
        }

        public bool SetBars(List<Bar> bars, out List<string> ids)
        {
            m_Project.AddObjects(bars.Cast<BHoMObject>());
            ids = bars.Select(e => e.BHoM_Guid.ToString()).ToList();
            return true;
        }

        public bool SetGrids(List<Grid> grid, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetGroups(List<IGroup> groups, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetLevels(List<Storey> stores, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetLoadcases(List<ICase> cases)
        {
            throw new NotImplementedException();
        }

        public bool SetLoads(List<ILoad> loads)
        {
            throw new NotImplementedException();
        }

        public bool SetNodes(List<Node> nodes, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetOpenings(List<Opening> opening, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetPanels(List<Panel> panels, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetRigidLinks(List<RigidLink> rigidLinks, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFEMeshes(out List<FEMesh> meshes, List<string> ids = null)
        {
            throw new NotImplementedException();
        }

        public bool SetFEMeshes(List<FEMesh> meshes, out List<string> ids)
        {
            m_Project.AddObjects(meshes.Cast<BHoMObject>());
            ids = meshes.Select(e => e.BHoM_Guid.ToString()).ToList();
            
            return true;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
