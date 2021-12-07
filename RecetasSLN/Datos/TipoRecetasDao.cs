using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos
{
    internal class TipoRecetasDao 
    {
        private SqlDao sqlDao;

        public TipoRecetasDao()
        {
            sqlDao = SqlDao.GetDao();
        }

        public List<TipoReceta> getAll(string commandText)
        {
            DataTable dataTable = sqlDao.GetAll(commandText); 
            List<TipoReceta> lst = new List<TipoReceta>();
            foreach(DataRow dr in dataTable.Rows)
            {
                TipoReceta tipo = new TipoReceta(); 
                tipo.id = Convert.ToInt32(dr["id_tipo_receta"]);
                tipo.nombre = dr["n_tipo_receta"].ToString();
                lst.Add(tipo);
            }
            return lst;
        }

    }
}
