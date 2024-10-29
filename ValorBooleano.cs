using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class ValorBooleano
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Valor Booleano";

        // Constructor sin parámetros
        public ValorBooleano() { }

        // Constructor con parámetros (opcional)
        public ValorBooleano(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
