using BHoM.Structural;
using BHoM.Structural.Loads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Structural.Elements;

namespace BHoM.Structural.Interface
{
    /// <summary>
    /// An interface class which should be inherited by an external application in order to import and export BHoMObjects
    /// </summary>
    public interface IElementAdapter
    {
        string Filename { get; }

        bool GetNodes(out List<Node> nodes, string option = "");
        bool GetBars(out List<Bar> bars, string option = "");
        bool GetPanels(out List<Panel> panels, string option = "");
        bool GetOpenings(out List<Opening> opening, string option = "");
        bool GetLevels(out List<Storey> levels, string options = "");
        bool GetGrids(out List<Grid> grids, string options = "");

        bool GetLoads(out List<ILoad> loads, string option = "");
        bool GetLoadcases(out List<ICase> cases);

        bool SetNodes(List<Node> nodes, out List<string> ids, string option = "");
        bool SetBars(List<Bar> bars, out List<string> ids, string option = "");
        bool SetPanels(List<Panel> panels, out List<string> ids, string option = "");
        bool SetOpenings(List<Opening> opening, out List<string> ids, string option = "");
        bool SetLevels(List<Storey> stores, out List<string> ids, string option = "");
        bool SetGrids(List<Grid> grid, out List<string> ids, string option = "");


        bool SetLoads(List<ILoad> loads, string option = "");
        bool SetLoadcases(List<ICase> cases);
    }
}
