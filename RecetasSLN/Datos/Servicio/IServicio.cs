using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal interface IServicio
    {
        IEnumerable<Object> GetRecetas();
        IEnumerable<Receta> GetAllRecetas();
    }
}
