using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal interface IServicio
    {
        IEnumerable<Receta> GetRecetas(Dictionary<string,object> parameters);
        IEnumerable<Receta> GetAllRecetas();
        List<TipoReceta> GetTipos();
        string PutFecha(Receta receta);

        DateTime GetFecha(int Value);
    }
}
