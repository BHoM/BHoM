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
    public enum ObjectSelection
    {
        All,
        Selected,
        FromInput
    }

    /// <summary>
    /// An interface class which should be inherited by an external application in order to import and export BHoMObjects
    /// </summary>
    public interface IElementAdapter
    {
        string Filename { get; }

        ObjectSelection Selection { get; set; }

        List<string> GetNodes(out List<Node> nodes, List<string> ids = null);
        List<string> GetBars(out List<Bar> bars, List<string> ids = null);
        List<string> GetPanels(out List<Panel> panels, List<string> ids = null);
        List<string> GetOpenings(out List<Opening> opening, List<string> ids = null);
        List<string> GetLevels(out List<Storey> levels, List<string> ids = null);
        List<string> GetGrids(out List<Grid> grids, List<string> ids = null);

        List<string> GetLoadcases(out List<ICase> cases);
        bool GetLoads(out List<ILoad> loads, List<string> ids = null);

        bool SetNodes(List<Node> nodes, out List<string> ids);
        bool SetBars(List<Bar> bars, out List<string> ids);
        bool SetPanels(List<Panel> panels, out List<string> ids);
        bool SetOpenings(List<Opening> opening, out List<string> ids);
        bool SetLevels(List<Storey> stores, out List<string> ids);
        bool SetGrids(List<Grid> grid, out List<string> ids);


        bool SetLoads(List<ILoad> loads);
        bool SetLoadcases(List<ICase> cases);
    }
}
