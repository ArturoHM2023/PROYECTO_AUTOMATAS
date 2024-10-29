using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class VariableEnRAMLexico
    {
        

        public string Lexema { get; set; }

        public string Token { get; set; }
        // Constructor sin parámetros
        public VariableEnRAMLexico() { }

        // Constructor con parámetros (opcional)
        public VariableEnRAMLexico(string unLexema, string token)
        {
            this.Lexema = unLexema;
            Token = token;
        }

    }
}
