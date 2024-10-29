using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Nulo
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Nulo";

        // Constructor sin parámetros
        public Nulo() { }

        // Constructor con parámetros (opcional)
        public Nulo(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
