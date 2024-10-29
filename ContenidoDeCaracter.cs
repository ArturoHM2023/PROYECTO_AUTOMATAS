using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class ContenidoDeCaracter
    {
        public string Token { get; set; }

        public string TipoDeLexema { get; set; } = "Caracter";

        // Constructor sin parámetros
        public ContenidoDeCaracter() { }

        // Constructor con parámetros (opcional)
        public ContenidoDeCaracter(string unToken)
        {
            this.Token = unToken;
        }
    }
}
