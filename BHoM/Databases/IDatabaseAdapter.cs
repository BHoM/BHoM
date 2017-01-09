using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Databases
{
    public interface IDatabaseAdapter
    {
        // Constructor format (for reference)
        // public IDatabaseAdapter(string serverName, string databaseName, string tableName);

        string ServerName { get; }

        string DatabaseName { get; }

        string CollectionName { get; }

        bool PushObjects(IEnumerable<BHoMObject> objects, List<string> tags = null);    //TODO: Need to be on all objects, not just BHoM objects

        bool PushJson(IEnumerable<string> objects, List<string> tags = null);           //TODO: we want a single push method, ideally returning json (what about dependencies?)

        IEnumerable<BHoMObject> QueryObjects(List<string> queryStrings);                //TODO: same as Push

        IEnumerable<string> QueryJson(List<string> queryStrings);                       //TODO: same as Push

        bool DeleteItems(string filterString = "");                                     //TODO: clarify taxonomy. If only one method each, could be Query, Push, Delete
    }
}
