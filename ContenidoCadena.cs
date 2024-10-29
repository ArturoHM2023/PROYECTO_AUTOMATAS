using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class ContenidoCadena
    {
        public string Token { get; set; }

        public string TipoDeLexema { get; set; } = "Cadena";

        // Constructor sin parámetros
        public ContenidoCadena() { }

        // Constructor con parámetros (opcional)
        public ContenidoCadena(string unToken)
        {
            this.Token = unToken;
        }
    }
}
