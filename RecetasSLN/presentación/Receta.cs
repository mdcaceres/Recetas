using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.presentación
{
    internal class Receta
    {
        public int nroReceta { get; set; }
        public string nombre { get; set; }
        public TipoReceta tipo { get; set; }
        public string cheff { get; set; }

    }
}
