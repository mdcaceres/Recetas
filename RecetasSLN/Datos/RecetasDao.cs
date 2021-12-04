using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos
{
    internal class RecetasDao : IDao
    {
        private SqlDao sqlDao;

        public RecetasDao()
        {
            sqlDao = SqlDao.GetDao();
        }

        public IEnumerable<Object> Get(object filter, string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = sqlDao.Get(filter, commandText, parameters);
            List<Receta> lst = new List<Receta>();
            foreach (DataRow dr in dt.Rows)
            {
                Receta rec = new Receta();
                rec.nroReceta = Convert.ToInt32(dr[0]);
                rec.nombre = dr[1].ToString();
                rec.cheff = dr[2].ToString();
                TipoReceta tipo = new TipoReceta();
                tipo.id = Convert.ToInt32(dr[3]);
                rec.tipo = tipo;
                lst.Add(rec);
            }
            return lst;
        }

        public IEnumerable<Receta> GetAll(string commandText)
        {
            DataTable dt = sqlDao.GetAll(commandText);
            List<Receta> lst = new List<Receta>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Receta rec = new Receta();
                rec.nroReceta = Convert.ToInt32(dt.Rows[i][0]);
                rec.nombre = dt.Rows[i][1].ToString();
                rec.cheff = dt.Rows[i][2].ToString();
                TipoReceta tipo = new TipoReceta();
                tipo.id = Convert.ToInt32(dt.Rows[i][3]);
                rec.tipo = tipo;
                lst.Add(rec);
            }
            return lst;
        }
    }
}
