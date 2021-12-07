using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal abstract class AbstractFactory
    {
        public abstract IDao FactoryRecetasDao(); 

        public abstract TipoRecetasDao FactoryTipoRecetasDao();
    }
}
