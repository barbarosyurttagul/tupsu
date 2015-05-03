using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupveSuAboneTakip.DAL
{
    public static class DatabaseProvider
    {
        #region CreateConnect()
        private static SqlConnection CreateConnect()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["TupSuAboneTakipWinAuth"].ConnectionString;
            return conn;
        } 
        #endregion

        #region CreateCommand()
        private static SqlCommand CreateCommand(string query, CommandType cType, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CreateConnect();
            cmd.CommandText = query;
            cmd.CommandType = cType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        } 
        #endregion

        #region RunExecuteNonQuery()
        /// <summary>
        /// Runs ExecuteNonQuery() method according to the given parameters and creates connection to the database
        /// </summary>
        /// <param name="query">Query for insert, update, delete</param>
        /// <param name="cType">CommandType.StoredProcedure or CommandType.Text</param>
        /// <param name="parameters">null or given parameter array</param>
        /// <returns></returns>
        public static int RunExecuteNonQuery(string query, CommandType cType, SqlParameter[] parameters)
        {
            SqlCommand cmd = CreateCommand(query, cType, parameters);

            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqEx)
            {

                throw sqEx;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        } 
        #endregion

        #region RunExecuteScalar()
        /// <summary>
        /// Runs ExecuteScalar() method according to the given parameters and creates connection to the database
        /// </summary>
        /// <param name="query">query for Select command</param>
        /// <param name="cType">CommandType.StoredProcedure or CommandType.Text</param>
        /// <param name="parameters">null or given parameter array</param>
        /// <returns></returns>
        public static object RunExecuteScalar(string query, CommandType cType, SqlParameter[] parameters)
        {
            SqlCommand cmd = CreateCommand(query, cType, parameters);
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                return cmd.ExecuteScalar();
            }
            catch (SqlException sqEx)
            {

                throw sqEx;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        } 
        #endregion

        #region RunExecuteReader()
        /// <summary>
        /// Runs ExecuteReader() method according to the given parameters and creates connection to the database
        /// Closes connection automatically with SqlDataReader parameter (ex. dr.Close())
        /// </summary>
        /// <param name="query">query for Select command</param>
        /// <param name="cType">CommandType.StoredProcedure or CommandType.Text</param>
        /// <param name="parameters">You can write null for this method</param>
        /// <returns></returns>
        public static SqlDataReader RunExecuteReader(string query, CommandType cType, SqlParameter[] parameters)
        {
            SqlCommand cmd = CreateCommand(query, cType, parameters);
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException sqEx)
            {

                throw sqEx;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion
    }
}
