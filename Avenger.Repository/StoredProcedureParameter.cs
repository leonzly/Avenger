using System.Data;

namespace Avenger.Repository
{
    public class StoredProcedureParameter
    {
        public string ParamVariable { get; set; }
        public SqlDbType ParamType { get; set; }
        public object ParamValue { get; set; }
        public string TypeName { get; set; }
    }
}
