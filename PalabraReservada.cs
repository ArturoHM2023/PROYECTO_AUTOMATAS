using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace Lenguaje
{
    public class PalabraReservada
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public string TipoDeLexema { get; set; } = "Palabra Reservada";

        // Constructor sin parámetros
        public PalabraReservada() { }

        // Constructor con parámetros (opcional)
        public PalabraReservada(string unToken, string unLexema)
        {
            this.Token = unToken;
            this.Lexema = unLexema;
        }
    }
}
