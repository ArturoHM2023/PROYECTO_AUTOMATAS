using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class IdentificadorEnRAM
    {
        public string Lexema { get; set; }
        // Constructor sin parámetros
        public IdentificadorEnRAM() { }

        // Constructor con parámetros (opcional)
        public IdentificadorEnRAM(string unLexema)
        {
            this.Lexema = unLexema;
        }
    }
}
