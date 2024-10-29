using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public  class OperadorLogico
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Operador Logico";

        // Constructor sin parámetros
        public OperadorLogico() { }

        // Constructor con parámetros (opcional)
        public OperadorLogico(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
