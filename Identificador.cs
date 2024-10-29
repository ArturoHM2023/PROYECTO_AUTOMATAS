using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Identificador
    {
        public string Token { get; set; }

        public string TipoDeLexema { get; set; } = "Identificador";

        // Constructor sin parámetros
        public Identificador() { }

        // Constructor con parámetros (opcional)
        public Identificador(string unToken)
        {
            this.Token = unToken;
        }
    }
}
