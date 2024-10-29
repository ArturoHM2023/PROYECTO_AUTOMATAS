using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class OperadorRelacional
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Operador Relacional";

        // Constructor sin parámetros
        public OperadorRelacional() { }

        // Constructor con parámetros (opcional)
        public OperadorRelacional(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
