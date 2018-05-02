using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntelliGuardTest.Common
{
    public class DatabaseAccess
    {
        public IEnumerable<T> Query<T>(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters = null) where T : new()
        {
            return Enumerable.Range(0, storedProcedureName.Length).Select(x => GenerateRandomClass<T>());
        }

        public T ExecuteScalar<T>(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters = null) where T : new()
        {
            return GenerateRandomClass<T>();
        }

        private T GenerateRandomClass<T>() where T : new()
        {
            Random rnd = new Random();
            var index = 0;
            var result = new T();
            var type = typeof(T);
            var propertyInfo = type.GetProperties();
            foreach (PropertyInfo pInfo in propertyInfo)
            {
                if (!pInfo.CanWrite) { continue; }
                if (pInfo.PropertyType == typeof(int))
                {
                    pInfo.SetValue(result, rnd.Next(1, 200));
                    index++;
                }
                if (pInfo.PropertyType == typeof(string))
                {
                    pInfo.SetValue(result, Path.GetRandomFileName().Replace(".", ""));
                    index++;
                }
            }
            return result;
        }
    }
}
