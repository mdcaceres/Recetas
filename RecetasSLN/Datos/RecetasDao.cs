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

        public IEnumerable<Receta> Get(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = sqlDao.Get(commandText, parameters);
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
                rec.fecha_baja = Convert.ToDateTime(dr[4]);
                lst.Add(rec);
            }
            return lst;
        }


        public IEnumerable<Receta> Get(object filter, string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
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

        public void PutFecha(Receta receta)
        {
            int id = receta.nroReceta; 
            sqlDao.Put($"update recetas set fecha_baja = getdate() where id_receta = {id}");
        }

        public DateTime GetFecha(int value)
        {
            return sqlDao.GetFecha("SP_CONSULTAR_FECHA","@id", value); 
        }
    }
}
