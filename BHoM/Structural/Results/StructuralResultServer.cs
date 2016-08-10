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

        public StructuralResultServer(string fileName)
        {
            m_Filename = fileName;
        }

        private void SetParameters<T>(ResultServer<T> server, List<string> ids, List<string> cases, ResultOrder orderBy) where T : Result, new()
        {
            server.NameSelection = ids;
            server.LoadcaseSelection = cases;
            server.OrderBy = orderBy;
        }

        public bool GetBarForces(List<string> bars, List<string> cases, int divisions, ResultOrder orderBy, out Dictionary<string, ResultSet<BarForce>> results)
        {
            if (!string.IsNullOrEmpty(m_Filename))
            {
                ResultServer<BarForce> barServer = new ResultServer<BarForce>(m_Filename);
                SetParameters(barServer, bars, cases, orderBy);
                results = barServer.LoadData();
                return true;               
            }
            results = null;
            return false;
        }

        public bool GetBarStresses()
        {
            throw new NotImplementedException();
        }

        public bool GetModalResults()
        {
            throw new NotImplementedException();
        }

        public bool GetNodeAccelerations()
        {
            throw new NotImplementedException();
        }

        public bool GetNodeDisplacements()
        {
            throw new NotImplementedException();
        }

        public bool GetNodeReactions(List<string> nodes, List<string> cases, ResultOrder orderBy, out Dictionary<string, ResultSet<NodeReaction>> results)
        {
            if (!string.IsNullOrEmpty(m_Filename))
            {
                ResultServer<NodeReaction> server = new ResultServer<NodeReaction>(m_Filename);
                SetParameters(server, nodes, cases, orderBy);
                results = server.LoadData();
                return true;
            }
            results = null;
            return false;
        }

        public bool GetNodeVelocities()
        {
            throw new NotImplementedException();
        }

        public bool GetPanelForces()
        {
            throw new NotImplementedException();
        }

        public bool GetPanelStress()
        {
            throw new NotImplementedException();
        }
    }
}
