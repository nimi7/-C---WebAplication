using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;

namespace FirsrtWebAplication
{
    public class DAL
    {
        static string Connection = ConfigurationManager.ConnectionStrings["SQL_AsseManagement"].ConnectionString;

        public DAL(string Connection1)
        {
            Connection = Connection1;

        }
        public void Close(IDbConnection Connection)
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }

        public int ExecuteNonQuery1(string Query, List<IDbDataParameter> parameters)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand com = new SqlCommand(Query, con);
            con.Open();
            for (int i = 0; i < parameters.Count; i++)
            {
                com.Parameters.Add(parameters[i]);

            }


            //  con.Open();
            result = com.ExecuteNonQuery();

            //if(Connectionstring != null)
            //{
            //    con.Close();

            //}


            return result;

        }// ישן

        public object ExecuteScalar1(string Query)
        {
            object result = null;
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand com = new SqlCommand(Query, con);
            try
            {
                con.Open();
                result = com.ExecuteScalar();
            }
            catch { }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return result;
        } // ישן

        public IDataReader ExecuteReader1(string Query)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(Connection);
            SqlCommand com = new SqlCommand(Query, con);
            try
            {
                con.Open();
                reader = com.ExecuteReader();
            }
            catch { }
            finally
            {

            }
            return reader;
        } // ישן

        public int ExecuteNonQuery(string Query, List<IDbDataParameter> parameters)
        {
            int result = 0;
            SqlConnection url = new SqlConnection(Connection);

            SqlCommand command = new SqlCommand(Query, url);

            for (int i = 0; i < parameters.Count; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            /* try
             {*/
            url.Open();

            result = command.ExecuteNonQuery();
            /* }
             catch (Exception ex)
             {
                 //MessageBox.Show(ex.Message);
             }
             finally
             {
                 close(url);
             }*/
            return result;
        } // חדש

        public object ExecuteScalar(string Query, List<IDbDataParameter> parameters)
        {
            object result = null;
            SqlConnection url = new SqlConnection(Connection);
            SqlCommand command = new SqlCommand(Query, url);
            for (int i = 0; i < parameters.Count; i++)
            {
                command.Parameters.Add(parameters[i]);
            }

            try
            {
                url.Open();

                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return result;
        } // חדש

        public IDataReader EndExecuteReader(string Query, out IDbConnection connection, List<IDbDataParameter> parameters)
        {
            SqlDataReader reader = null;
            SqlConnection url = new SqlConnection(Connection);
            connection = url;
            SqlCommand command = new SqlCommand(Query, url);

            for (int i = 0; i < parameters.Count; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            try
            {
                url.Open();

                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return reader;
        } // חדש

        public IDbDataParameter CreateParamter(string par, DbType dbType, object Value)
        {
            IDbDataParameter Paramters = new SqlParameter();

            Paramters.Value = Value;
            Paramters.ParameterName = par;
            Paramters.DbType = dbType;

            return Paramters;
        }
    }
}
