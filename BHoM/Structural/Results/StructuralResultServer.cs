using BHoM.Base.Results;
using BHoM.Structural.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class StructuralResultServer : IResultAdapter
    {
        string m_Filename;

        public ResultServer<T> GetResultServer<T>() where T : IResult, new()
        {
            return new ResultServer<T>(m_Filename);
        }

        public StructuralResultServer(string fileName)
        {
            m_Filename = fileName;
        }

        public bool GetNodeDisplacements(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<NodeDisplacement>(nodes, cases, orderBy)) != null; ;
        }

        private Dictionary<string, IResultSet> GetResult<T>(List<string> ids, List<string> cases, ResultOrder orderBy) where T : IResult, new()
        {
            ResultServer<T> server = new ResultServer<T>(m_Filename);
            if (!string.IsNullOrEmpty(m_Filename))
            {
                server.NameSelection = ids;
                server.LoadcaseSelection = cases;
                server.OrderBy = orderBy;
                return server.LoadData();
            }
            return null;
        }

        public bool GetBarForces(List<string> bars, List<string> cases, int divisions, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<BarForce>(bars, cases, orderBy)) != null;
        }

        public bool GetBarStresses()
        {
            throw new NotImplementedException();
        }

        public bool GetModalResults()
        {
            throw new NotImplementedException();
        }
      
        public bool GetNodeReactions(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<NodeReaction>(nodes, cases, orderBy)) != null;
        }

        public bool GetNodeVelocities(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<NodeVelocity>(nodes, cases, orderBy)) != null;
        }

        public bool GetNodeAccelerations(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<NodeAcceleration>(nodes, cases, orderBy)) != null;
        }

        public bool GetPanelForces(List<string> panels, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<PanelForce>(panels, cases, orderBy)) != null;
        }

        public bool GetPanelStress(List<string> panels, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<PanelStress>(panels, cases, orderBy)) != null;
        }

        public bool StoreResults(string filename, List<ResultType> resultTypes, List<string> loadcases, bool append = false)
        {
            throw new NotImplementedException();
        }

        public bool GetBarUtilisation(List<string> bars, List<string> cases, ResultOrder orderBy, out Dictionary<string, IResultSet> results)
        {
            return (results = GetResult<SteelUtilisation>(bars, cases, orderBy)) != null;
        }
    }
}
