using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos
{
    internal interface IDao
    {
        IEnumerable<Receta> GetAll(string commandText);
        IEnumerable<Object> Get(object filter,string commandText, Dictionary<string,Object> parameters);
    }
}
