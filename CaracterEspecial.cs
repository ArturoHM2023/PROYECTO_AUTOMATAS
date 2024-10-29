using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class CaracterEspecial
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Caracter Especial";

        // Constructor sin parámetros
        public CaracterEspecial() { }

        // Constructor con parámetros (opcional)
        public CaracterEspecial(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
