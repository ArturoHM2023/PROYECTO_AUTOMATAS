using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class ContenidoDeComentario
    {
        public string Token { get; set; }

        public string TipoDeLexema { get; set; } = "Contenido De Comentario";

        // Constructor sin parámetros
        public ContenidoDeComentario() { }

        // Constructor con parámetros (opcional)
        public ContenidoDeComentario(string unToken)
        {
            this.Token = unToken;
        }
    }
}
