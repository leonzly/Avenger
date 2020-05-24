using FastMember;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Avenger.Repository
{
    public class StoredProcedureRepository : IStoredProcedureRepository
    {
        private readonly DbContext _context;

        public StoredProcedureRepository(DbContext context)
        {
            _context = context;
        }

        public List<T> Execute<T>(string spName, List<StoredProcedureParameter> parameters)
        {
            var results = new List<T>();
            var conStr = _context.Database.GetDbConnection().ConnectionString;
            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = spName;
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                if(param.ParamType == System.Data.SqlDbType.Structured)
                                {
                                    command.Parameters.Add(new SqlParameter("@" + param.ParamVariable, param.ParamType) { TypeName = param.TypeName, Value = param.ParamValue });
                                }
                                else
                                {
                                    command.Parameters.Add(new SqlParameter("@" + param.ParamVariable, param.ParamType) { Value = param.ParamValue });
                                }
                            }
                        }

                        if (command.Connection.State == ConnectionState.Closed)
                            command.Connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            results = MapToList<T>(reader);
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error : Customer Compliance API || Function : ExecuteStoredProcedure");
                }
                finally
                {
                    connection.Close();
                }
            }

            return results;
        }

        public DataTable ExecuteReturnDataTable(string spName, List<StoredProcedureParameter> parameters)
        {
            var results = new DataTable();
            var conStr = _context.Database.GetDbConnection().ConnectionString;
            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = spName;
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                if (param.ParamType != SqlDbType.Structured)
                                {
                                    command.Parameters.Add(new SqlParameter("@" + param.ParamVariable, param.ParamType) { Value = param.ParamValue });
                                }
                                else
                                {
                                    command.Parameters.Add(new SqlParameter("@" + param.ParamVariable, param.ParamType) { TypeName = param.TypeName, Value = param.ParamValue });
                                }
                            }
                        }

                        if (command.Connection.State == ConnectionState.Closed)
                            command.Connection.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);

                        results = dt;

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error : Customer Compliance API || Function : ExecuteStoredProcedure");
                }
                finally
                {
                    connection.Close();
                }

            }

            return results;

        }

        public DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(items))
            {
                table.Load(reader);
                return table;
            }
        }

        private List<T> MapToList<T>(DbDataReader dr)
        {
            var objList = new List<T>();
            var props = typeof(T).GetRuntimeProperties();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }
    }
}
