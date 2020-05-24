using System.Collections.Generic;
using System.Data;

namespace Avenger.Repository
{
    public interface IStoredProcedureRepository
    {
        DataTable ConvertToDataTable<T>(List<T> items);
        List<T> Execute<T>(string spName, List<StoredProcedureParameter> parameters);
        DataTable ExecuteReturnDataTable(string spName, List<StoredProcedureParameter> parameters);
    }
}