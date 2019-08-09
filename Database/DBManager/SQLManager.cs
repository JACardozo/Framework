using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DBManager
{
    public class SQLManager : IDatabaseManager
    {
        private string connectionString;

        public SQLManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        /// <summary>
        /// Doing the connection with SQLSERVER database
        /// </summary>
        /// <returns></returns>
        public IDbConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Close the connection with SQLServer Database
        /// </summary>
        /// <param name="connection"></param>
        public void CloseConnection(IDbConnection connection)
        {
            connection.Close();
        }

        /// <summary>
        /// Executes the query sent in parameters
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public IDataReader ExecuteQuery(IDbConnection connection, string query)
        {
            SqlCommand command = (SqlCommand)connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            IDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void ExecuteNonQuery(IDbConnection connection, string query)
        {
            SqlCommand cmd = (SqlCommand)connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }
    }
}
