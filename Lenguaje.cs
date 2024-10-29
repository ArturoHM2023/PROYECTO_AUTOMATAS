using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lenguaje
{
    public class Lenguaje
    {
        public List<PalabraReservada> PalabrasReservadas { get; set; }
        public List<TipoDeDato> TiposDeDatos { get; set; }
        public List<OperadorAritmetico> OperadoresAritmeticos { get; set; }

        public List<OperadorLogico> OperadoresLogicos { get; set; }

        public List<OperadorRelacional> OperadoresRelacionales { get; set; }

        public List<Letrero> Letreros { get; set; }

        public List<Comentario> Comentarios { get; set; }

        public List<CaracterEspecial> CaracteresEspeciales { get; set; }

        public List<Variable> Variables { get; set; }

        public List<Coeficiente> Coeficientes { get; set; }

        public List<Identificador> Identificadores { get; set; }

        public List<ValorBooleano> ValoresBooleanos { get; set; }

        public List<ContenidoCadena> ContenidoDeCadenas { get; set; }

        public List<ContenidoDeCaracter> ContenidoDeCaracteres { get; set; }

        public List<ContenidoDeComentario> ContenidoDeComentarios  { get; set; }

        public List<Nulo> Nulos { get; set; }

        public bool ValidarNombreDeIdentificador(string strNombreDeIdentificador , List<IdentificadorEnRAM> misIdentificadoresEnRAM)
        {
            

           
            // Expresión regular que verifica:
            // - Inicia con letra (mayúscula o minúscula) o guion bajo (_)
            // - Puede contener letras, dígitos o guiones bajos
            // - No permite espacios ni caracteres especiales
            string patron = @"^[a-zA-Z_][a-zA-Z0-9_]*$";

            // Validar la sintaxis del identificador
            if (!Regex.IsMatch(strNombreDeIdentificador, patron))
            {
                return false;
            }

            // Verificar que el identificador no esté en ninguna de las listas
            if (PalabrasReservadas.Any(p => p.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                TiposDeDatos.Any(t => t.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                OperadoresAritmeticos.Any(o => o.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                OperadoresLogicos.Any(o => o.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                OperadoresRelacionales.Any(o => o.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                Letreros.Any(l => l.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                Comentarios.Any(c => c.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                CaracteresEspeciales.Any(c => c.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                Nulos.Any(n => n.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)) ||
                misIdentificadoresEnRAM.Any(ID => ID.Lexema.Equals(strNombreDeIdentificador, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // El identificador ya existe en alguna de las listas
            }

            return true; // El identificador es válido y no existe en las listas
        }





    }
}
