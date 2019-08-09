using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DBManager
{
    public interface IDatabaseManager
    {
        IDbConnection OpenConnection();
        void CloseConnection(IDbConnection connection);
        IDataReader ExecuteQuery(IDbConnection connection, string query);
    }
}
