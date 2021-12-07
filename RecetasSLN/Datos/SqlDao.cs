using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.presentación;

namespace RecetasSLN.Datos
{
    internal class SqlDao
    {
        private static SqlDao instance; 
        private SqlConnection _conn;
        private SqlCommand _command;
        private string strConnection;

        private SqlDao()
        {
            strConnection = Properties.Resources.strConnection;
            _conn = new SqlConnection(strConnection);
        }

        public static SqlDao GetDao()
        {
            if(instance == null)
                instance = new SqlDao();
            return instance;
        }

        private void OpenConn()
        {
            if(_conn.State.Equals(ConnectionState.Closed))
                _conn.Open();
        }

        private void CloseConn()
        {
            if (_conn.State.Equals(ConnectionState.Open))
                _conn.Close();
        }
        public DateTime GetFecha(string commandText,string id, int idValue)
        {
            OpenConn();
            _command = new SqlCommand();
            _command.Connection = _conn;
            _command.CommandText = commandText;
            _command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Date", SqlDbType.DateTime);
            param.Direction = ParameterDirection.Output;
            _command.Parameters.Add(param);

            _command.Parameters.AddWithValue(id, idValue);

            _command.ExecuteNonQuery();
            DateTime date; 
            if(param.Value != DBNull.Value)
            {
                date = Convert.ToDateTime(param.Value);
            } else
            {
                date = DateTime.MinValue; 
            }
            
            return date; 
        }
        public DataTable Get(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            OpenConn();
            _command = new SqlCommand();
            _command.Connection = _conn;
            _command.CommandText = commandText;
            _command.CommandType = CommandType.StoredProcedure; 
            foreach(KeyValuePair<string, object> param in parameters)
            {
                
                SqlParameter parameter = new SqlParameter(param.Key, param.Value);
                parameter.IsNullable = true;
                _command.Parameters.Add(parameter);
            }

            SqlParameterCollection testParams = _command.Parameters;
            dt.Load(_command.ExecuteReader());
            CloseConn();
            return dt; 
        }

        public DataTable GetAll(string commandText)
        {
            DataTable dt = new DataTable();
            OpenConn();
            _command = _conn.CreateCommand();
            _command.CommandText = commandText;
            _command.CommandType = CommandType.StoredProcedure; 
            dt.Load(_command.ExecuteReader());
            CloseConn();
            return dt; 
        }

        public void Put(string commandText)
        {
            OpenConn();
            _command = _conn.CreateCommand(); 
            _command.CommandText = commandText; 
            _command.CommandType = CommandType.Text; 
            _command.ExecuteNonQuery();
            CloseConn();
        }
    }
}
