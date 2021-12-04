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

        public DataTable Get(Object filter, string commandText, Dictionary<string, Object> parameters)
        {
            DataTable dt = new DataTable();
            OpenConn();
            _command = _conn.CreateCommand(); 
            _command.CommandText = commandText;
            foreach(KeyValuePair<string, Object> param in parameters)
            {
                _command.Parameters.AddWithValue(param.Key, param.Value);
            }
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
            dt.Load(_command.ExecuteReader());
            CloseConn();
            return dt; 
        }
    }
}
