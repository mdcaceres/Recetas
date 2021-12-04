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

        public Servicio(AbstractFactory factory)
        {
            RecetasDao = factory.CreateRecetasDao(); 
        }
        public IEnumerable<Receta> GetAllRecetas()
        {
            return RecetasDao.GetAll("SP_CONSULTAR_RECETAS_SIN_FILTRO"); 
        }

        public IEnumerable<Object> GetRecetas()
        {
            throw new NotImplementedException();
        }
    }
}
