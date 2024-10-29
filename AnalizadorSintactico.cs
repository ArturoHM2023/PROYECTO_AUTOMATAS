using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Lenguaje
{
    public class AnalizadorSintactico
    {
       

        
       
  
        Gramatica miGramatica;
        private Dictionary<string, HashSet<string>> _gramatica;
        List<string> tokens;
        // Inicializar una lista para almacenar las reducciones
        List<string> reducciones = new List<string>();
        DataTable DTListaEstadoDeLineas = new DataTable();

        public AnalizadorSintactico()
        {

           
            miGramatica = new Gramatica();
            _gramatica = miGramatica.ObtenerGrammatica();

            

            
            DTListaEstadoDeLineas.Columns.Add("No.Linea", typeof(int));
            DTListaEstadoDeLineas.Columns.Add("Estado", typeof(string));
            DTListaEstadoDeLineas.Columns.Add("Linea de codigo", typeof(string));
        }


        public void BottomUp(TextBox txtCodigoFuenteSintactico, TextBox txtTokens)
        {
            // Captura el texto del TextBox
            string inputText = txtTokens.Text.TrimEnd();

            // Separa el texto en líneas (o puedes usar Split para separar por espacios, comas, etc.)
            tokens = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            // Encontrar la última línea no vacía
            int lastNonEmptyIndex = tokens.FindLastIndex(token => !string.IsNullOrWhiteSpace(token));

            // Si hay líneas no vacías, eliminar las líneas vacías después de la última línea no vacía
            if (lastNonEmptyIndex >= 0)
            {
                tokens = tokens.Take(lastNonEmptyIndex + 1).ToList();
            }

            int numeroDeLinea = 0;
           
            DTListaEstadoDeLineas.Clear();
            // Lógica de análisis sintáctico
            foreach (var tokenOriginal in tokens)
            {
               
                numeroDeLinea++;
               

                // Definir una copia mutable de token para trabajar
                var token = tokenOriginal;
                // Agregar el token original a la lista de reducciones
                reducciones.Add(token);
                bool blnHuboReduccion;

                do
                {
                    // Separar la cadena de entrada en un array de elementos
                    var elementos = token.Split(' ').ToArray();
                    blnHuboReduccion = false; // Indicador para verificar si ocurrió alguna reducción.

                    // Recorrer diferentes longitudes de subcadenas
                    for (int longitud = elementos.Length; longitud > 0; longitud--)
                    {
                        for (int inicio = 0; inicio <= elementos.Length - longitud; inicio++)
                        {
                            string subcadena = string.Join(" ", elementos, inicio, longitud);

                            // Comprobar si la subcadena está en la gramática
                            if (_gramatica.ContainsKey(subcadena))
                            {
                                var producciones = _gramatica[subcadena];

                                foreach (var produccion in producciones)
                                {
                                    // Generar el nuevo token reemplazando la subcadena con la producción
                                    var nuevoToken = token.Replace(subcadena, produccion);

                                    // Verificar si hubo un cambio
                                    if (nuevoToken != token) // Si se produce una reducción
                                    {
                                        token = nuevoToken; // Actualizar el token
                                        reducciones.Add(token); // Agregar el nuevo token a la lista de reducciones
                                        blnHuboReduccion = true; // Marcar que ocurrió una reducción

                                        // Reiniciar elementos para procesar el nuevo token
                                        elementos = token.Split(' ').ToArray();

                                        // Salir de los bucles y reiniciar
                                        break; // Salir del foreach
                                    }
                                }
                            }

                            // Verificar si hubo una reducción para salir del bucle interno
                            if (blnHuboReduccion) break; // Salir del bucle de longitudes
                        }

                        // Si hubo una reducción, salir del bucle de longitud
                        if (blnHuboReduccion) break; // Salir del bucle de longitudes
                    }

                } while (blnHuboReduccion);

                // Dividir la cadena en palabras y eliminar los espacios vacíos
                string[] palabrasSeparadas = token.Split(' ').ToArray();
                if (palabrasSeparadas.Length == 1 && ( txtCodigoFuenteSintactico.Lines.Count() > 0 ))
                {
                    if (string.IsNullOrWhiteSpace(tokenOriginal) && txtCodigoFuenteSintactico.Lines.Length >= numeroDeLinea && txtCodigoFuenteSintactico.Lines.Length > 0)
                    {
                        string textoLineaEspecifica = txtCodigoFuenteSintactico.Lines[numeroDeLinea - 1];
                        DTListaEstadoDeLineas.Rows.Add(numeroDeLinea, "Línea vacía", textoLineaEspecifica);
                        continue; // Saltar al siguiente token
                    }
                    else {

                        if (palabrasSeparadas[0] == "S")
                        {
                            string textoLineaEspecifica = txtCodigoFuenteSintactico.Lines[numeroDeLinea - 1];
                            DTListaEstadoDeLineas.Rows.Add(numeroDeLinea, "Aceptado", textoLineaEspecifica);
                        }
                        else
                        {
                            string textoLineaEspecifica = txtCodigoFuenteSintactico.Lines[numeroDeLinea - 1];
                            DTListaEstadoDeLineas.Rows.Add(numeroDeLinea, "No Aceptado", textoLineaEspecifica);
                        }
                     }
                    }
                else
                {
                   
                    
                    if ( txtCodigoFuenteSintactico.Lines.Count() > 0)
                    {
                        string textoLineaEspecifica = txtCodigoFuenteSintactico.Lines[numeroDeLinea - 1];
                        DTListaEstadoDeLineas.Rows.Add(numeroDeLinea, "No Aceptado", textoLineaEspecifica);
                    }
                }
                    // Agregar una línea vacía después de procesar cada token original
                    reducciones.Add("");
            }

            
        }

        public string ReduccionesAnalizadorSintactico( TextBox txtCodigoFuenteSintactico, TextBox txtTokens)
        {
            BottomUp(txtCodigoFuenteSintactico, txtTokens);

            // Retornar todas las reducciones como un solo string, separando por nueva línea
            return string.Join(Environment.NewLine, reducciones);
        }

        public void MostrarListaDeEstadosDeLinea(DataGridView dtgErrores)
        {
            dtgErrores.DataSource = DTListaEstadoDeLineas;
        }
    }
}




