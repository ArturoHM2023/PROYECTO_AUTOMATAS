using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Variable
    {
        public string Token{ get; set; }
        
        public string TipoDeLexema { get; set; } = "Variable";

        // Constructor sin parámetros
        public Variable() { }

        // Constructor con parámetros (opcional)
        public Variable(string unToken)
        {
            this.Token = unToken;
        }
    }
}
