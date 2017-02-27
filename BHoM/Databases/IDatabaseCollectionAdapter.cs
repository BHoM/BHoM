using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Databases
{
    public interface IDatabaseCollectionAdapter
    {
        // Constructor format (for reference)
        // public IDatabaseCollectionAdapter(string serverName, string databaseName, string tableName);

        string ServerName { get; }

        string DatabaseName { get; }

        string CollectionName { get; }

        bool Push(IEnumerable<object> objects, string key, List<string> tags = null);        

        List<object> Pull(string filterString = "", bool keepAsString = false);

        List<object> Query(List<string> queryStrings = null, bool keepAsString = false);      

        bool Delete(string filterString = "");       
    }
}
