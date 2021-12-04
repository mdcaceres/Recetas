using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Servicio
{
    internal class Factory : AbstractFactory
    {
        public override IDao CreateRecetasDao()
        {
            return new RecetasDao();
        }
    }
}
