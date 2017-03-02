using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Data
{
    public interface IDataAdapter
    {
        List<string> Names();
        List<string> TableNames();
        List<string> ColumnNames();
        List<IDataRow> Query(string query);

        string TableName { get; set; }

        IDataRow GetDataRow(string column, string matches);
        IDataRow GetDataRow(string[] columns, string[] matches, bool AND = false);

        List<string> GetDataColumn(string columnName);

        T GetDataRow<T>(string column, string matches) where T : IDataRow;
        List<IDataRow> GetDataSet(string column, string matches);
        List<string> GetDataColumn(string columnName, string column, string matches);
    }
}
