using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class CoeficienteEnRAMLexico
    {

        public string Lexema { get; set; }
        // Constructor sin parámetros
        public CoeficienteEnRAMLexico() { }

        // Constructor con parámetros (opcional)
        public CoeficienteEnRAMLexico(string unLexema)
        {
            this.Lexema = unLexema;
        }
    }
}
