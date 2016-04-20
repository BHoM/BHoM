using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Structural;
using BHoM.Structural.Loads;
using BHoM.Structural.Results;
using BHoM.Geometry;

namespace BHoM.Application
{
    public interface IApplication
    {
        ApplicationSettings Settings { get; set; }

        #region Geometry
        List<Node> GetNodes();
        List<Bar> GetBars();
        //PanelFactory GetPanels();
        //MeshFactory GetMesh();
        //void GetOpenning();

        /// <summary>
        /// Sets the Nodes in the application
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns>A list of ids used in the application corresponding to each node</returns>
        List<string> SetNodes(List<Node> nodes);
        List<string> SetBars(List<Bar> bars);
        List<string> SetWalls();
        List<string> SetSlabs();
        List<string> SetMesh(List<Mesh> meshes);
        List<string> SetOpenning();
        #endregion

        #region Loads
        List<Load> GetLoads();
        List<Load> GetAdditionalMass();
        List<Loadcase> GetLoadcases();

        List<string> SetLoads(List<Load> loads);
        List<string> SetMass(List<Load> masses);
        List<string> SetLoadcases(List<Loadcase> loadcases);

        #endregion

        #region Results
        
        #endregion
    }
}
