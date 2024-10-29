using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class OperadorAritmetico
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Operador Aritmetico";

        // Constructor sin parámetros
        public OperadorAritmetico() { }

        // Constructor con parámetros (opcional)
        public OperadorAritmetico(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
