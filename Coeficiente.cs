using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Coeficiente
    {
        public string Token { get; set; }

        public string TipoDeLexema { get; set; } = "Coeficiente";

        // Constructor sin parámetros
        public Coeficiente() { }

        // Constructor con parámetros (opcional)
        public Coeficiente(string unToken)
        {
            this.Token = unToken;
        }
    }
}
