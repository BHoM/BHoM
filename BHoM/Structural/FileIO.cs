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
    public class FileIO : IElementAdapter
    {
        private Project m_Project;

        public FileIO(string directoryIn, string directoryOut)
        {
            FileIn = directoryIn;
            FileOut = directoryOut;
            m_Project = new Project();
            if (!Directory.Exists(FileIn))
            {
                Directory.CreateDirectory(FileIn);
            }
            if (!Directory.Exists(FileOut))
            {
                Directory.CreateDirectory(FileOut);
            }
            //using (StreamReader fs = new StreamReader(fileName))
            //{
            //    string json = fs.ReadToEnd();
            //    m_Project = Project.FromJSON(json);
            //    fs.Close();
            //}
            Identifier = FilterOption.Guid;
        }

        public string Filename { get; set; }

        public string FileIn
        {
            get;
            set;
        }

        public string FileOut
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
            bars = Read<Bar>();
            return new ObjectFilter<Bar>(bars).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetGrids(out List<Grid> grids, List<string> ids = null)
        {
            grids = Read<Grid>();
            return new ObjectFilter<Grid>(grids).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetGroups(out List<IGroup> groups, List<string> ids = null)
        {
            groups = Read<IGroup>();
            return new ObjectFilter<IGroup>(groups).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetLevels(out List<Storey> levels, List<string> ids = null)
        {
            levels = Read<Storey>();
            return new ObjectFilter<Storey>(levels).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetLoadcases(out List<ICase> cases)
        {
            cases = Read<ICase>();
            return new ObjectFilter<ICase>(cases).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public bool GetLoads(out List<ILoad> loads, List<string> ids = null)
        {
            loads = new ObjectFilter<ILoad>(m_Project).ToList();
            return true;
        }

        public List<string> GetNodes(out List<Node> nodes, List<string> ids = null)
        {
            nodes = Read<Node>();
            return new ObjectFilter<Node>(nodes).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetOpenings(out List<Opening> opening, List<string> ids = null)
        {
            opening = Read<Opening>();
            return new ObjectFilter<Opening>(opening).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetPanels(out List<Panel> panels, List<string> ids = null)
        {
            panels = Read<Panel>();
            return new ObjectFilter<Panel>(panels).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetFEMeshes(out List<FEMesh> meshes, List<string> ids = null)
        {
            meshes = Read<FEMesh>();
            return new ObjectFilter<FEMesh>(meshes).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public List<string> GetRigidLinks(out List<RigidLink> links, List<string> ids = null)
        {
            links = Read<RigidLink>();
            return new ObjectFilter<RigidLink>(links).ToDictionary<string>(Key, Identifier).Keys.ToList();
        }

        public bool SetBars(List<Bar> bars, out List<string> ids)
        {
            ids = bars.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Bar>(bars);
        }

        public bool SetGrids(List<Grid> grid, out List<string> ids)
        {
            ids = grid.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Grid>(grid);
        }

        public bool SetGroups(List<IGroup> groups, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetLevels(List<Storey> stories, out List<string> ids)
        {
            ids = stories.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Storey>(stories);
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
            ids = nodes.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Node>(nodes);
        }

        public bool SetOpenings(List<Opening> opening, out List<string> ids)
        {
            ids = opening.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Opening>(opening);
        }

        public bool SetPanels(List<Panel> panels, out List<string> ids)
        {
            ids = panels.Select(e => e.BHoM_Guid.ToString()).ToList();
            return Write<Panel>(panels);
        }

        public bool SetRigidLinks(List<RigidLink> rigidLinks, out List<string> ids)
        {
            throw new NotImplementedException();
        }

        public bool SetFEMeshes(List<FEMesh> meshes, out List<string> ids)
        {
            ids = meshes.Select(e => e.BHoM_Guid.ToString()).ToList();
            Write<FEMesh>(meshes);
            return true;
        }

        private bool Write<T>(List<T> objects) where T : BHoMObject, IBase
        {
            using (StreamWriter fs = new StreamWriter(Path.Combine(FileOut, typeof(T).Name + ".txt"), false))
            {
                fs.Write(BHoMJSON.WritePackage(objects.Cast<BHoMObject>().ToList()));
                fs.Close();
            }
            return true;
        }

        private List<T> Read<T>() where T : IBase
        {
            List<T> result = new List<T>();
            using (StreamReader fs = new StreamReader(Path.Combine(FileIn, typeof(T).Name + ".txt")))
            {
                result = BHoM.Base.BHoMJSON.ReadPackage(fs.ReadToEnd()).Cast<T>().ToList();
                fs.Close();
            }
            return result;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
