using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal class Servicio : IServicio
    {
        private IDao RecetasDao;
        private TipoRecetasDao TipoRecetaDao; 

        public Servicio(AbstractFactory factory)
        {
            RecetasDao = factory.FactoryRecetasDao();
            TipoRecetaDao = factory.FactoryTipoRecetasDao(); 
        }
        public IEnumerable<Receta> GetAllRecetas()
        {
            return RecetasDao.GetAll("SP_CONSULTAR_RECETAS_SIN_FILTRO"); 
        }

        public IEnumerable<Receta> GetRecetas(Dictionary<string, object> parameters)
        {
            return RecetasDao.Get("SP_CONSULTAR_RECETAS",parameters);
        }

        public List<TipoReceta> GetTipos()
        {
            return TipoRecetaDao.getAll("SP_CONSULTAR_TIPO");
        }

        public string PutFecha(Receta receta)
        {
            RecetasDao.PutFecha(receta);
            return "se ha dado de baja el item";
        }

        public DateTime GetFecha(int idValue)
        {
            return RecetasDao.GetFecha(idValue); 
        }
    }
}
