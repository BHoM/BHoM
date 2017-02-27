using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Databases
{
    public interface IDatabaseAdapter
    {
        // Constructor format (for reference)
        // public IDatabaseCollectionAdapter(string serverName, string databaseName, string tableName);

        string ServerName { get; }

        string DatabaseName { get; }

        bool Push(string collection, IEnumerable<object> objects, string key, List<string> tags = null);

        List<object> Pull(string collection, string filterString = "", bool keepAsString = false);

        List<object> Query(string collection, List<string> queryStrings = null, bool keepAsString = false);

        bool Delete(string collection, string filterString = "");

    }
}
