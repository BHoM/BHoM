using BHoM.Base.Results;
using BHoM.Structural.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Databases;

namespace BHoM.Structural.Interface
{
    public interface IResultAdapter
    {
        //Analytical Results
        bool StoreResults(string filename, List<ResultType> resultTypes, List<string> loadcases, bool append = false);

        bool GetBarForces(List<string> bars, List<string> cases, int divisions, ResultOrder orderBy, out Dictionary<string, IResultSet> results);
        bool GetBarStresses(List<string> bars, List<string> cases, int divisions, ResultOrder orderBy, out Dictionary<string, IResultSet> results);

        bool GetNodeReactions(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);
        bool GetNodeDisplacements(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);
        bool GetNodeVelocities(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);
        bool GetNodeAccelerations(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);

        bool GetModalResults();

        bool GetPanelForces(List<string> panels, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);
        bool GetPanelStress(List<string> panels, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);

        bool GetBarUtilisation(List<string> bars, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);

        //Design Results
        bool GetSlabReinforcement(List<string> panels, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results);

        //Geometry
        bool GetNodeCoordinates(List<string> nodes, out Dictionary<string, IResultSet> results);
        bool GetBarCoordinates(List<string> bars, out Dictionary<string, IResultSet> results);

        bool PushToDataBase(IDatabaseAdapter dbAdapter, List<ResultType> resultTypes, List<string> loadcases, string key, bool append = false);
    }
}

