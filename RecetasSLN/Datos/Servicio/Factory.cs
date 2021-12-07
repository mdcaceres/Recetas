using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal class Factory : AbstractFactory
    {
        public override IDao FactoryRecetasDao()
        {
            return new RecetasDao();
        }

        public override TipoRecetasDao FactoryTipoRecetasDao()
        {
            return new TipoRecetasDao();
        }
    }
}
