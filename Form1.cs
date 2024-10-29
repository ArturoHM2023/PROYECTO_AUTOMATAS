using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Threading;
using static System.Windows.Forms.LinkLabel;



namespace Lenguaje
{
    public partial class Form1 : Form
    {
        static Lenguaje miLenguaje;
        private string tokenSeleccionado = string.Empty;
        private string lexemaSeleccionado = string.Empty;
        private CancellationTokenSource _cancellationTokenSource;
        public DataGridView DTGErrores
        {
            get { return dtgErrores; }
        }


        public Form1()
        {
            InitializeComponent();
            CargarLenguajeDesdeArchivo();
            InicializarComboBoxes();
            ActualizarTablaAlfabeto(cboMostrarTipoDeLexema.SelectedIndex);

        }

        private void InicializarComboBoxes()
        {
            cboAccionLexema.SelectedIndex = 0;
            cboTipoDeLexema.SelectedIndex = 0;
            cboMostrarTipoDeLexema.SelectedIndex = 0;
            btnAccion.Text = "Agregar";
            dtgAlfabeto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgAlfabeto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (cboTipoDeLexema.SelectedIndex == 8 || cboTipoDeLexema.SelectedIndex == 9 || cboTipoDeLexema.SelectedIndex == 10 || cboTipoDeLexema.SelectedIndex == 12 || cboTipoDeLexema.SelectedIndex == 13 || cboTipoDeLexema.SelectedIndex == 14)
            {
                if (string.IsNullOrEmpty(txtToken.Text))
                {
                    MessageBox.Show("Por favor ingresa el token");
                    return;
                }


            }
            else
            {
                if (string.IsNullOrEmpty(txtToken.Text) || string.IsNullOrEmpty(txtLexema.Text))
                {
                    MessageBox.Show("Por favor ingresa el token y el lexema.");
                    return;
                }
            }


            switch (cboAccionLexema.SelectedIndex)
            {
                case 0: // Agregar
                    AgregarLexema();
                    break;
                case 1: // Modificar
                    ModificarLexema();
                    break;
                case 2: // Eliminar
                    EliminarLexema();
                    break;
            }

            GuardarLenguajeEnArchivo();
            ActualizarTablaAlfabeto(cboMostrarTipoDeLexema.SelectedIndex);
            LimpiarCampos();
        }
        private void AgregarLexema()
        {
            if (cboTipoDeLexema.SelectedIndex == 0) // Palabras Reservadas
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevaPalabra = new PalabraReservada(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.PalabrasReservadas.Add(nuevaPalabra);
                    MessageBox.Show("Palabra reservada agregada correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 1) // Tipos de Datos
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoTipoDeDato = new TipoDeDato(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.TiposDeDatos.Add(nuevoTipoDeDato);
                    MessageBox.Show("Tipo de dato agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 2) // Operador Arimetico
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoOperadorAritmetico = new OperadorAritmetico(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.OperadoresAritmeticos.Add(nuevoOperadorAritmetico);
                    MessageBox.Show("Operador aritmetico agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 3)// Operador Logico
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoOperadorLogico = new OperadorLogico(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.OperadoresLogicos.Add(nuevoOperadorLogico);
                    MessageBox.Show("Operador Logico agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 4)// Operador Relacional
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoOperadorRelacional = new OperadorRelacional(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.OperadoresRelacionales.Add(nuevoOperadorRelacional);
                    MessageBox.Show("Operador relacional agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 5)// Letrero
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoLetrero = new Letrero(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.Letreros.Add(nuevoLetrero);
                    MessageBox.Show("Letrero agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 6)// Comentario
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoComentario = new Comentario(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.Comentarios.Add(nuevoComentario);
                    MessageBox.Show("Comentario agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 7)// Caracter Especial
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoCaracterEspecial = new CaracterEspecial(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.CaracteresEspeciales.Add(nuevoCaracterEspecial);
                    MessageBox.Show("Caracter especial agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 8) //Variable
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevaVariable = new Variable(txtToken.Text.ToUpper().Trim());
                    miLenguaje.Variables.Add(nuevaVariable);
                    MessageBox.Show("Variable agregada correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 9)//Coeficiente
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevoCoeficiente = new Coeficiente(txtToken.Text.ToUpper().Trim());
                    miLenguaje.Coeficientes.Add(nuevoCoeficiente);
                    MessageBox.Show("Coeficiente agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 10) // Identificador
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevoIdentificador = new Identificador(txtToken.Text.ToUpper().Trim());
                    miLenguaje.Identificadores.Add(nuevoIdentificador);
                    MessageBox.Show("Identificador agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 11) // Valor Booleano
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoValorBooleano = new ValorBooleano(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.ValoresBooleanos.Add(nuevoValorBooleano);
                    MessageBox.Show("Valor booleano agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 12) // Cadena
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevaCadena = new ContenidoCadena(txtToken.Text.ToUpper().Trim());
                    miLenguaje.ContenidoDeCadenas.Add(nuevaCadena);
                    MessageBox.Show("Cadena agregada correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 13) // Caracter 
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevoCarater = new ContenidoDeCaracter(txtToken.Text.ToUpper().Trim());
                    miLenguaje.ContenidoDeCaracteres.Add(nuevoCarater);
                    MessageBox.Show("Caracter agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 14) // Contenido Comentario
            {
                if (ValidarExistencia(txtToken.Text, ""))
                {
                    var nuevoContenidoDeComentario = new ContenidoDeComentario(txtToken.Text.ToUpper().Trim());
                    miLenguaje.ContenidoDeComentarios.Add(nuevoContenidoDeComentario);
                    MessageBox.Show("Contenido de comentario agregado correctamente.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 15) // Valor Booleano
            {
                if (ValidarExistencia(txtToken.Text, txtLexema.Text))
                {
                    var nuevoNulo = new Nulo(txtToken.Text.ToUpper().Trim(), txtLexema.Text.ToUpper().Trim());
                    miLenguaje.Nulos.Add(nuevoNulo);
                    MessageBox.Show("Nulo agregado correctamente.");
                }
            }

        }
        private void ModificarLexema()
        {
            if (cboTipoDeLexema.SelectedIndex == 0) // Palabras Reservadas
            {
                var palabraExistente = miLenguaje.PalabrasReservadas.Find(p => p.Token == tokenSeleccionado);
                if (palabraExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    palabraExistente.Token = txtToken.Text.ToUpper().Trim();
                    palabraExistente.Lexema = txtLexema.Text.ToUpper().Trim();

                    MessageBox.Show("Palabra reservada modificada correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 1)
            {
                var TipoDeDatoExistente = miLenguaje.TiposDeDatos.Find(p => p.Token == tokenSeleccionado);
                if (TipoDeDatoExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    TipoDeDatoExistente.Token = txtToken.Text.ToUpper().Trim();
                    TipoDeDatoExistente.Lexema = txtLexema.Text.ToUpper().Trim();

                    MessageBox.Show("Tipo de dato modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 2)
            {
                var OperadorAritmeticoExistente = miLenguaje.OperadoresAritmeticos.Find(p => p.Token == tokenSeleccionado);
                if (OperadorAritmeticoExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    OperadorAritmeticoExistente.Token = txtToken.Text.ToUpper().Trim();
                    OperadorAritmeticoExistente.Lexema = txtLexema.Text.ToUpper().Trim();

                    MessageBox.Show("Operador aritmetico modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }

            }
            else if (cboTipoDeLexema.SelectedIndex == 3)
            {
                var OperadorLogicoExistente = miLenguaje.OperadoresLogicos.Find(p => p.Token == tokenSeleccionado);
                if (OperadorLogicoExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    OperadorLogicoExistente.Token = txtToken.Text.ToUpper().Trim();
                    OperadorLogicoExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Operador Logico modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 4)
            {
                var OperadorRelacionalExistente = miLenguaje.OperadoresRelacionales.Find(p => p.Token == tokenSeleccionado);
                if (OperadorRelacionalExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    OperadorRelacionalExistente.Token = txtToken.Text.ToUpper().Trim();
                    OperadorRelacionalExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Operador relacional modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 5)
            {
                var LetreroExistente = miLenguaje.Letreros.Find(p => p.Token == tokenSeleccionado);
                if (LetreroExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    LetreroExistente.Token = txtToken.Text.ToUpper().Trim();
                    LetreroExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Letrero modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 6)
            {
                var ComentarioExistente = miLenguaje.Comentarios.Find(p => p.Token == tokenSeleccionado);
                if (ComentarioExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    ComentarioExistente.Token = txtToken.Text.ToUpper().Trim();
                    ComentarioExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Comentario modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 7)
            {
                var CaracterEspecialExistente = miLenguaje.CaracteresEspeciales.Find(p => p.Token == tokenSeleccionado);
                if (CaracterEspecialExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    CaracterEspecialExistente.Token = txtToken.Text.ToUpper().Trim();
                    CaracterEspecialExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Caracter especial modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 8)
            {
                var VariableExistente = miLenguaje.Variables.Find(p => p.Token == tokenSeleccionado);
                if (VariableExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    VariableExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Variable modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }

            }
            else if (cboTipoDeLexema.SelectedIndex == 9)
            {
                var CoeficienteExistente = miLenguaje.Coeficientes.Find(p => p.Token == tokenSeleccionado);
                if (CoeficienteExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    CoeficienteExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Coeficiente modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }

            }
            else if (cboTipoDeLexema.SelectedIndex == 10)
            {
                var IdentificadorExistente = miLenguaje.Identificadores.Find(p => p.Token == tokenSeleccionado);
                if (IdentificadorExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    IdentificadorExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Identificador modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 11)
            {
                var ValorBooleanoExistente = miLenguaje.ValoresBooleanos.Find(p => p.Token == tokenSeleccionado);
                if (ValorBooleanoExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    ValorBooleanoExistente.Token = txtToken.Text.ToUpper().Trim();
                    ValorBooleanoExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Valor booleano modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 12) //Cadena
            {
                var CadenaExistente = miLenguaje.ContenidoDeCadenas.Find(p => p.Token == tokenSeleccionado);
                if (CadenaExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    CadenaExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Cadena modificada correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 13) //Caracater
            {
                var CaracterExistente = miLenguaje.ContenidoDeCaracteres.Find(p => p.Token == tokenSeleccionado);
                if (CaracterExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    CaracterExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Caracter modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 14) //Contenido de comentario
            {
                var ContenidoDeComentarioExistente = miLenguaje.ContenidoDeComentarios.Find(p => p.Token == tokenSeleccionado);
                if (ContenidoDeComentarioExistente != null && ValidarExistencia(txtToken.Text.Trim(), ""))
                {
                    ContenidoDeComentarioExistente.Token = txtToken.Text.ToUpper();
                    MessageBox.Show("Contenido de comentario modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 15) // Nulo
            {
                var NuloExistente = miLenguaje.Nulos.Find(p => p.Token == tokenSeleccionado);
                if (NuloExistente != null && ValidarExistencia(txtToken.Text.Trim(), txtLexema.Text.Trim()))
                {
                    NuloExistente.Token = txtToken.Text.ToUpper().Trim();
                    NuloExistente.Lexema = txtLexema.Text.ToUpper().Trim();
                    MessageBox.Show("Nulo modificado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
            }

        }
        private void EliminarLexema()
        {
            if (string.IsNullOrEmpty(tokenSeleccionado))
            {
                MessageBox.Show("Por favor, selecciona una palabra o caracter para eliminar.");
                return;
            }

            if (cboTipoDeLexema.SelectedIndex == 0) // Palabras Reservadas
            {
                var palabraParaEliminar = miLenguaje.PalabrasReservadas.Find(p => p.Token == tokenSeleccionado);
                if (palabraParaEliminar != null)
                {
                    miLenguaje.PalabrasReservadas.Remove(palabraParaEliminar);
                    MessageBox.Show("Palabra reservada eliminada correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar la palabra a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 1)
            {
                var TipoDeDatoParaEliminar = miLenguaje.TiposDeDatos.Find(p => p.Token == tokenSeleccionado);
                if (TipoDeDatoParaEliminar != null)
                {
                    miLenguaje.TiposDeDatos.Remove(TipoDeDatoParaEliminar);
                    MessageBox.Show("Tipo de dato eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el tipo de dato a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 2)
            {
                var OperadorAritmeticoParaEliminar = miLenguaje.OperadoresAritmeticos.Find(p => p.Token == tokenSeleccionado);
                if (OperadorAritmeticoParaEliminar != null)
                {
                    miLenguaje.OperadoresAritmeticos.Remove(OperadorAritmeticoParaEliminar);
                    MessageBox.Show("Operador aritmetico eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el operador aritmetico a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 3)
            {
                var OperadorLogicoParaEliminar = miLenguaje.OperadoresLogicos.Find(p => p.Token == tokenSeleccionado);
                if (OperadorLogicoParaEliminar != null)
                {
                    miLenguaje.OperadoresLogicos.Remove(OperadorLogicoParaEliminar);
                    MessageBox.Show("Operador logico eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el operador logico a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 4)
            {
                var OperadorRelacionalParaEliminar = miLenguaje.OperadoresRelacionales.Find(p => p.Token == tokenSeleccionado);
                if (OperadorRelacionalParaEliminar != null)
                {
                    miLenguaje.OperadoresRelacionales.Remove(OperadorRelacionalParaEliminar);
                    MessageBox.Show("Operador relacional eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el operador relacional a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 5)
            {
                var LetreroParaEliminar = miLenguaje.Letreros.Find(p => p.Token == tokenSeleccionado);
                if (LetreroParaEliminar != null)
                {
                    miLenguaje.Letreros.Remove(LetreroParaEliminar);
                    MessageBox.Show("Letrero eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar letrero a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 6)
            {
                var ComentarioParaEliminar = miLenguaje.Comentarios.Find(p => p.Token == tokenSeleccionado);
                if (ComentarioParaEliminar != null)
                {
                    miLenguaje.Comentarios.Remove(ComentarioParaEliminar);
                    MessageBox.Show("Comentario eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar comentario a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 7)
            {
                var CaracterEspecialParaEliminar = miLenguaje.CaracteresEspeciales.Find(p => p.Token == tokenSeleccionado);
                if (CaracterEspecialParaEliminar != null)
                {
                    miLenguaje.CaracteresEspeciales.Remove(CaracterEspecialParaEliminar);
                    MessageBox.Show("Caracter especial eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar caracter especial a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 8)
            {
                var VariableParaEliminar = miLenguaje.Variables.Find(p => p.Token == tokenSeleccionado);
                if (VariableParaEliminar != null)
                {
                    miLenguaje.Variables.Remove(VariableParaEliminar);
                    MessageBox.Show("Variable eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar la variable a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 9)
            {
                var CoeficienteParaEliminar = miLenguaje.Coeficientes.Find(p => p.Token == tokenSeleccionado);
                if (CoeficienteParaEliminar != null)
                {
                    miLenguaje.Coeficientes.Remove(CoeficienteParaEliminar);
                    MessageBox.Show("Coeficiente eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el Coeficiente a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 10)
            {
                var IdentificadorParaEliminar = miLenguaje.Identificadores.Find(p => p.Token == tokenSeleccionado);
                if (IdentificadorParaEliminar != null)
                {
                    miLenguaje.Identificadores.Remove(IdentificadorParaEliminar);
                    MessageBox.Show("Identificador eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el Identificador a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 11)
            {
                var ValorBooleanoParaEliminar = miLenguaje.ValoresBooleanos.Find(p => p.Token == tokenSeleccionado);
                if (ValorBooleanoParaEliminar != null)
                {
                    miLenguaje.ValoresBooleanos.Remove(ValorBooleanoParaEliminar);
                    MessageBox.Show("Valor booleano eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el valor booleano a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 12) //Cadena
            {
                var CadenaParaEliminar = miLenguaje.ContenidoDeCadenas.Find(p => p.Token == tokenSeleccionado);
                if (CadenaParaEliminar != null)
                {
                    miLenguaje.ContenidoDeCadenas.Remove(CadenaParaEliminar);
                    MessageBox.Show("Cadena eliminada correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar la cadena a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 13) //Caracter
            {
                var CaracterParaEliminar = miLenguaje.ContenidoDeCaracteres.Find(p => p.Token == tokenSeleccionado);
                if (CaracterParaEliminar != null)
                {
                    miLenguaje.ContenidoDeCaracteres.Remove(CaracterParaEliminar);
                    MessageBox.Show("Caracter eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el caracter a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 14) //Contenido de comentario
            {
                var ContenidoDeComentariosParaEliminar = miLenguaje.ContenidoDeComentarios.Find(p => p.Token == tokenSeleccionado);
                if (ContenidoDeComentariosParaEliminar != null)
                {
                    miLenguaje.ContenidoDeComentarios.Remove(ContenidoDeComentariosParaEliminar);
                    MessageBox.Show("Contenido de comentario eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el contenido de comentario a eliminar.");
                }
            }
            else if (cboTipoDeLexema.SelectedIndex == 15) //Nulo
            {
                var NuloParaEliminar = miLenguaje.Nulos.Find(p => p.Token == tokenSeleccionado);
                if (NuloParaEliminar != null)
                {
                    miLenguaje.Nulos.Remove(NuloParaEliminar);
                    MessageBox.Show("Nulo eliminado correctamente.");
                    tokenSeleccionado = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar Nulo a eliminar.");
                }
            }


        }
        private bool ValidarExistencia(string token, string lexema, string tokenExistente = null)
        {
            // Convertir a min sculas para que las comparaciones no distingan entre may sculas y min sculas
            token = token.ToLower();
            lexema = lexema.ToLower();

            // Si el token ya existe, mostrar el mensaje de error y retornar false
            if (BuscarTokenDuplicado(token))
            {
                MessageBox.Show("Error: El token ya existe (sin distinci n de may sculas). Por favor, elige uno diferente.");
                return false;
            }

            if (cboTipoDeLexema.SelectedIndex != 8 || cboTipoDeLexema.SelectedIndex != 9 || cboTipoDeLexema.SelectedIndex != 10)
            {

                // Si el lexema ya existe, mostrar el mensaje de error y retornar false
                if (BuscarLexemaDuplicado(lexema))
                {
                    MessageBox.Show("Error: El lexema ya existe (sin distinci n de may sculas). Por favor, elige uno diferente.");
                    return false;
                }

            }

            // Si no hay duplicados, retornar true
            return true;
        }
        public bool BuscarTokenDuplicado(string token)
        {
            bool Existe = false;

            if (cboAccionLexema.SelectedIndex == 1)
            {

                if (ContarToken(token) == 1 && token == tokenSeleccionado.ToLower())
                {
                    Existe = false;
                }
                else
                {
                    Existe = miLenguaje.PalabrasReservadas.Exists(p => p.Token.ToLower() == token)
                            || miLenguaje.TiposDeDatos.Exists(t => t.Token.ToLower() == token)
                            || miLenguaje.OperadoresAritmeticos.Exists(OPA => OPA.Token.ToLower() == token)
                            || miLenguaje.OperadoresLogicos.Exists(OPL => OPL.Token.ToLower() == token)
                            || miLenguaje.OperadoresRelacionales.Exists(OPR => OPR.Token.ToLower() == token)
                            || miLenguaje.Letreros.Exists(LT => LT.Token.ToLower() == token)
                            || miLenguaje.Comentarios.Exists(CM => CM.Token.ToLower() == token)
                            || miLenguaje.CaracteresEspeciales.Exists(CS => CS.Token.ToLower() == token)
                            || miLenguaje.Variables.Exists(V => V.Token.ToLower() == token)
                            || miLenguaje.Coeficientes.Exists(C => C.Token.ToLower() == token)
                            || miLenguaje.Identificadores.Exists(ID => ID.Token.ToLower() == token)
                            || miLenguaje.ValoresBooleanos.Exists(VB => VB.Token.ToLower() == token)
                            || miLenguaje.ContenidoDeCadenas.Exists(CD => CD.Token.ToLower() == token)
                            || miLenguaje.ContenidoDeCaracteres.Exists(CC => CC.Token.ToLower() == token)
                            || miLenguaje.ContenidoDeComentarios.Exists(CCT => CCT.Token.ToLower() == token)
                            || miLenguaje.Nulos.Exists(NL => NL.Token.ToLower() == token);
                }

                tokenSeleccionado = string.Empty;
                return Existe;
            }
            else
            {
                Existe = miLenguaje.PalabrasReservadas.Exists(p => p.Token.ToLower() == token)
                             || miLenguaje.TiposDeDatos.Exists(t => t.Token.ToLower() == token)
                             || miLenguaje.OperadoresAritmeticos.Exists(OPA => OPA.Token.ToLower() == token)
                             || miLenguaje.OperadoresLogicos.Exists(OPL => OPL.Token.ToLower() == token)
                             || miLenguaje.OperadoresRelacionales.Exists(OPR => OPR.Token.ToLower() == token)
                             || miLenguaje.Letreros.Exists(LT => LT.Token.ToLower() == token)
                             || miLenguaje.Comentarios.Exists(CM => CM.Token.ToLower() == token)
                             || miLenguaje.CaracteresEspeciales.Exists(CS => CS.Token.ToLower() == token)
                             || miLenguaje.Variables.Exists(V => V.Token.ToLower() == token)
                             || miLenguaje.Coeficientes.Exists(C => C.Token.ToLower() == token)
                             || miLenguaje.Identificadores.Exists(ID => ID.Token.ToLower() == token)
                             || miLenguaje.ValoresBooleanos.Exists(VB => VB.Token.ToLower() == token)
                             || miLenguaje.ContenidoDeCadenas.Exists(CD => CD.Token.ToLower() == token)
                             || miLenguaje.ContenidoDeCaracteres.Exists(CC => CC.Token.ToLower() == token)
                             || miLenguaje.ContenidoDeComentarios.Exists(CCT => CCT.Token.ToLower() == token)
                             || miLenguaje.Nulos.Exists(NL => NL.Token.ToLower() == token);

                return Existe;
            }


        }
        public bool BuscarLexemaDuplicado(string lexema)
        {
            bool Existe = false;
            if (cboAccionLexema.SelectedIndex == 1)
            {
                if (ContarLexema(lexema) == 1 && lexema == lexemaSeleccionado.ToLower())
                {
                    Existe = false;
                }
                else
                {
                    Existe = miLenguaje.PalabrasReservadas.Exists(p => p.Lexema.ToLower() == lexema)
                             || miLenguaje.TiposDeDatos.Exists(t => t.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresAritmeticos.Exists(OPA => OPA.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresLogicos.Exists(OPL => OPL.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresRelacionales.Exists(OPR => OPR.Lexema.ToLower() == lexema)
                             || miLenguaje.Letreros.Exists(LT => LT.Lexema.ToLower() == lexema)
                             || miLenguaje.Comentarios.Exists(CM => CM.Lexema.ToLower() == lexema)
                             || miLenguaje.CaracteresEspeciales.Exists(CS => CS.Lexema.ToLower() == lexema)
                             || miLenguaje.ValoresBooleanos.Exists(VB => VB.Lexema.ToLower() == lexema)
                             || miLenguaje.Nulos.Exists(NL => NL.Lexema.ToLower() == lexema);
                }
                lexemaSeleccionado = string.Empty;
                return Existe;

            }
            else
            {
                Existe = miLenguaje.PalabrasReservadas.Exists(p => p.Lexema.ToLower() == lexema)
                             || miLenguaje.TiposDeDatos.Exists(t => t.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresAritmeticos.Exists(OPA => OPA.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresLogicos.Exists(OPL => OPL.Lexema.ToLower() == lexema)
                             || miLenguaje.OperadoresRelacionales.Exists(OPR => OPR.Lexema.ToLower() == lexema)
                             || miLenguaje.Letreros.Exists(LT => LT.Lexema.ToLower() == lexema)
                             || miLenguaje.Comentarios.Exists(CM => CM.Lexema.ToLower() == lexema)
                             || miLenguaje.CaracteresEspeciales.Exists(CS => CS.Lexema.ToLower() == lexema)
                             || miLenguaje.ValoresBooleanos.Exists(VB => VB.Lexema.ToLower() == lexema)
                             || miLenguaje.Nulos.Exists(NL => NL.Lexema.ToLower() == lexema);
                return Existe;
            }

        }
        public int ContarToken(string token)
        {
            token = token.ToLower(); // Convertir a min sculas para la comparaci n
            int contador = 0;

            contador += miLenguaje.PalabrasReservadas.Count(p => p.Token.ToLower() == token);
            contador += miLenguaje.TiposDeDatos.Count(t => t.Token.ToLower() == token);
            contador += miLenguaje.OperadoresAritmeticos.Count(OPA => OPA.Token.ToLower() == token);
            contador += miLenguaje.OperadoresLogicos.Count(OPL => OPL.Token.ToLower() == token);
            contador += miLenguaje.OperadoresRelacionales.Count(OPR => OPR.Token.ToLower() == token);
            contador += miLenguaje.Letreros.Count(LT => LT.Token.ToLower() == token);
            contador += miLenguaje.Comentarios.Count(CM => CM.Token.ToLower() == token);
            contador += miLenguaje.CaracteresEspeciales.Count(CS => CS.Token.ToLower() == token);
            contador += miLenguaje.Variables.Count(V => V.Token.ToLower() == token);
            contador += miLenguaje.Coeficientes.Count(C => C.Token.ToLower() == token);
            contador += miLenguaje.Identificadores.Count(ID => ID.Token.ToLower() == token);
            contador += miLenguaje.ValoresBooleanos.Count(VB => VB.Token.ToLower() == token);
            contador += miLenguaje.ContenidoDeCadenas.Count(CD => CD.Token.ToLower() == token);
            contador += miLenguaje.ContenidoDeCaracteres.Count(CC => CC.Token.ToLower() == token);
            contador += miLenguaje.ContenidoDeComentarios.Count(CCT => CCT.Token.ToLower() == token);
            contador += miLenguaje.Nulos.Count(NL => NL.Token.ToLower() == token);
            return contador;
        } // M todo para contar cu ntas veces se repite un token en todas las listas
        public int ContarLexema(string lexema)
        {
            lexema = lexema.ToLower(); // Convertir a min sculas para la comparaci n
            int contador = 0;

            contador += miLenguaje.PalabrasReservadas.Count(p => p.Lexema.ToLower() == lexema);
            contador += miLenguaje.TiposDeDatos.Count(t => t.Lexema.ToLower() == lexema);
            contador += miLenguaje.OperadoresAritmeticos.Count(OPA => OPA.Lexema.ToLower() == lexema);
            contador += miLenguaje.OperadoresLogicos.Count(OPL => OPL.Lexema.ToLower() == lexema);
            contador += miLenguaje.OperadoresRelacionales.Count(OPR => OPR.Lexema.ToLower() == lexema);
            contador += miLenguaje.Letreros.Count(LT => LT.Lexema.ToLower() == lexema);
            contador += miLenguaje.Comentarios.Count(CM => CM.Lexema.ToLower() == lexema);
            contador += miLenguaje.CaracteresEspeciales.Count(CS => CS.Lexema.ToLower() == lexema);
            contador += miLenguaje.ValoresBooleanos.Count(VB => VB.Lexema.ToLower() == lexema);
            contador += miLenguaje.Nulos.Count(NL => NL.Lexema.ToLower() == lexema);

            return contador;
        }// M todo para contar cu ntas veces se repite un lexema en todas las listas
        public void GuardarLenguajeEnArchivo()
        {
            string archivoJson = "Lenguaje.json";
            string json = JsonSerializer.Serialize(miLenguaje);
            File.WriteAllText(archivoJson, json);
        }
        public void CargarLenguajeDesdeArchivo()
        {
            string archivoJson = "Lenguaje.json";

            if (File.Exists(archivoJson))
            {
                string json = File.ReadAllText(archivoJson);
                miLenguaje = JsonSerializer.Deserialize<Lenguaje>(json) ?? new Lenguaje();
                miLenguaje.PalabrasReservadas ??= new List<PalabraReservada>();
                miLenguaje.TiposDeDatos ??= new List<TipoDeDato>();
                miLenguaje.OperadoresAritmeticos ??= new List<OperadorAritmetico>();
                miLenguaje.OperadoresLogicos ??= new List<OperadorLogico>();
                miLenguaje.OperadoresRelacionales ??= new List<OperadorRelacional>();
                miLenguaje.Letreros ??= new List<Letrero>();
                miLenguaje.Comentarios ??= new List<Comentario>();
                miLenguaje.CaracteresEspeciales ??= new List<CaracterEspecial>();
                miLenguaje.Variables ??= new List<Variable>();
                miLenguaje.Coeficientes ??= new List<Coeficiente>();
                miLenguaje.Identificadores ??= new List<Identificador>();
                miLenguaje.ValoresBooleanos ??= new List<ValorBooleano>();
                miLenguaje.ContenidoDeCadenas ??= new List<ContenidoCadena>();
                miLenguaje.ContenidoDeCaracteres ??= new List<ContenidoDeCaracter>();
                miLenguaje.ContenidoDeComentarios ??= new List<ContenidoDeComentario>();
                miLenguaje.Nulos ??= new List<Nulo>();
            }
            else
            {
                miLenguaje = new Lenguaje
                {
                    PalabrasReservadas = new List<PalabraReservada>(),
                    TiposDeDatos = new List<TipoDeDato>(),
                    OperadoresAritmeticos = new List<OperadorAritmetico>(),
                    OperadoresLogicos = new List<OperadorLogico>(),
                    OperadoresRelacionales = new List<OperadorRelacional>(),
                    Letreros = new List<Letrero>(),
                    Comentarios = new List<Comentario>(),
                    CaracteresEspeciales = new List<CaracterEspecial>(),
                    Variables = new List<Variable>(),
                    Coeficientes = new List<Coeficiente>(),
                    Identificadores = new List<Identificador>(),
                    ValoresBooleanos = new List<ValorBooleano>(),
                    ContenidoDeCadenas = new List<ContenidoCadena>(),
                    ContenidoDeCaracteres = new List<ContenidoDeCaracter>(),
                    ContenidoDeComentarios = new List<ContenidoDeComentario>(),
                    Nulos = new List<Nulo>()

                };
                GuardarLenguajeEnArchivo();
            }
        }
        public void ActualizarTablaAlfabeto(int tipoDeLexema)
        {
            dtgAlfabeto.Rows.Clear();
            if (tipoDeLexema == 0)
            {
                MostrarPalabrasReservadas();
                MostrarTiposDeDatos();
                MostrarOperadoresAritmeticos();
                MostrarOperadoresLogicos();
                MostrarOperadoresRelacionales();
                MostrarLetreros();
                MostrarComentarios();
                MostrarCarateresEspeciales();
                MostrarVariables();
                MostrarCoeficientes();
                MostrarIdentificadores();
                MostrarValoresBooleano();
                MostrarCadenas();
                MostrarCaracteres();
                MostrarContenidoDeComentarios();
                MostrarNulos();

            }
            else if (tipoDeLexema == 1)
            {
                MostrarPalabrasReservadas();
            }
            else if (tipoDeLexema == 2)
            {
                MostrarTiposDeDatos();
            }
            else if (tipoDeLexema == 3)
            {
                MostrarOperadoresAritmeticos();
            }
            else if (tipoDeLexema == 4)
            {
                MostrarOperadoresLogicos();
            }
            else if (tipoDeLexema == 5)
            {
                MostrarOperadoresRelacionales();
            }
            else if (tipoDeLexema == 6)
            {
                MostrarLetreros();
            }
            else if (tipoDeLexema == 7)
            {
                MostrarComentarios();
            }
            else if (tipoDeLexema == 8)
            {
                MostrarCarateresEspeciales();
            }
            else if (tipoDeLexema == 9)
            {
                MostrarVariables();
            }
            else if (tipoDeLexema == 10)
            {
                MostrarCoeficientes();
            }
            else if (tipoDeLexema == 11)
            {
                MostrarIdentificadores();
            }
            else if (tipoDeLexema == 12)
            {
                MostrarValoresBooleano();
            }
            else if (tipoDeLexema == 13)
            {
                MostrarCadenas();
            }
            else if (tipoDeLexema == 14)
            {
                MostrarCaracteres();
            }
            else if (tipoDeLexema == 15)
            {
                MostrarContenidoDeComentarios();

            }
            else if (tipoDeLexema == 16)
            {
                MostrarNulos();
            }

        }
        public void MostrarPalabrasReservadas()
        {
            foreach (var palabra in miLenguaje.PalabrasReservadas)
            {
                dtgAlfabeto.Rows.Add(palabra.Token, palabra.Lexema, palabra.TipoDeLexema);
            }
        }
        public void MostrarTiposDeDatos()
        {
            foreach (var tipo in miLenguaje.TiposDeDatos)
            {
                dtgAlfabeto.Rows.Add(tipo.Token, tipo.Lexema, tipo.TipoDeLexema);
            }
        }
        public void MostrarOperadoresAritmeticos()
        {
            foreach (var miOperadorAritmetico in miLenguaje.OperadoresAritmeticos)
            {
                dtgAlfabeto.Rows.Add(miOperadorAritmetico.Token, miOperadorAritmetico.Lexema, miOperadorAritmetico.TipoDeLexema);
            }
        }
        public void MostrarOperadoresLogicos()
        {
            foreach (var miOperadorLogico in miLenguaje.OperadoresLogicos)
            {
                dtgAlfabeto.Rows.Add(miOperadorLogico.Token, miOperadorLogico.Lexema, miOperadorLogico.TipoDeLexema);
            }
        }
        public void MostrarOperadoresRelacionales()
        {
            foreach (var miOperadorRelacional in miLenguaje.OperadoresRelacionales)
            {
                dtgAlfabeto.Rows.Add(miOperadorRelacional.Token, miOperadorRelacional.Lexema, miOperadorRelacional.TipoDeLexema);
            }
        }
        public void MostrarLetreros()
        {
            foreach (var miLetrero in miLenguaje.Letreros)
            {
                dtgAlfabeto.Rows.Add(miLetrero.Token, miLetrero.Lexema, miLetrero.TipoDeLexema);
            }
        }
        public void MostrarComentarios()
        {
            foreach (var miComentario in miLenguaje.Comentarios)
            {
                dtgAlfabeto.Rows.Add(miComentario.Token, miComentario.Lexema, miComentario.TipoDeLexema);
            }
        }
        public void MostrarCarateresEspeciales()
        {
            foreach (var miCaracterEspecial in miLenguaje.CaracteresEspeciales)
            {
                dtgAlfabeto.Rows.Add(miCaracterEspecial.Token, miCaracterEspecial.Lexema, miCaracterEspecial.TipoDeLexema);
            }
        }
        public void MostrarVariables()
        {
            foreach (var miVariable in miLenguaje.Variables)
            {
                dtgAlfabeto.Rows.Add(miVariable.Token, "", miVariable.TipoDeLexema);
            }
        }
        public void MostrarCoeficientes()
        {
            foreach (var miCoeficiente in miLenguaje.Coeficientes)
            {
                dtgAlfabeto.Rows.Add(miCoeficiente.Token, "", miCoeficiente.TipoDeLexema);
            }
        }
        public void MostrarIdentificadores()
        {
            if (miLenguaje.Identificadores != null)
            {
                foreach (var miIdentificador in miLenguaje.Identificadores)
                {
                    dtgAlfabeto.Rows.Add(miIdentificador.Token, "", miIdentificador.TipoDeLexema);
                }
            }
        }
        public void MostrarValoresBooleano()
        {
            if (miLenguaje.ValoresBooleanos != null)
            {
                foreach (var miValorBooleano in miLenguaje.ValoresBooleanos)
                {
                    dtgAlfabeto.Rows.Add(miValorBooleano.Token, miValorBooleano.Lexema, miValorBooleano.TipoDeLexema);
                }
            }
        }
        public void MostrarCadenas()
        {
            if (miLenguaje.ContenidoDeCadenas != null)
            {
                foreach (var miCadena in miLenguaje.ContenidoDeCadenas)
                {
                    dtgAlfabeto.Rows.Add(miCadena.Token, "", miCadena.TipoDeLexema);
                }
            }
        }

        public void MostrarCaracteres()
        {
            if (miLenguaje.ContenidoDeCaracteres != null)
            {
                foreach (var miCaracter in miLenguaje.ContenidoDeCaracteres)
                {
                    dtgAlfabeto.Rows.Add(miCaracter.Token, "", miCaracter.TipoDeLexema);
                }
            }
        }

        public void MostrarNulos()
        {
            if (miLenguaje.Nulos != null)
            {
                foreach (var miNulo in miLenguaje.Nulos)
                {
                    dtgAlfabeto.Rows.Add(miNulo.Token, miNulo.Lexema, miNulo.TipoDeLexema);
                }
            }
        }

        public void MostrarContenidoDeComentarios()
        {
            if (miLenguaje.ContenidoDeComentarios != null)
            {
                foreach (var miContenidoDeComentario in miLenguaje.ContenidoDeComentarios)
                {
                    dtgAlfabeto.Rows.Add(miContenidoDeComentario.Token, "", miContenidoDeComentario.TipoDeLexema);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtToken.Clear();
            txtLexema.Clear();
        }
        private void dtgAlfabeto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dtgAlfabeto.Rows[e.RowIndex];
                txtToken.Text = filaSeleccionada.Cells[0].Value.ToString().Trim();
                txtLexema.Text = filaSeleccionada.Cells[1].Value.ToString().Trim();
                tokenSeleccionado = filaSeleccionada.Cells[0].Value.ToString().Trim();
                cboTipoDeLexema.Text = filaSeleccionada.Cells[2].Value.ToString().Trim();
                lexemaSeleccionado = filaSeleccionada.Cells[1].Value.ToString().Trim();
            }
        }
        private void cboMostrarTipoDeLexema_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTablaAlfabeto(cboMostrarTipoDeLexema.SelectedIndex);
        }
        private void cboAccionLexema_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAccion.Text = cboAccionLexema.Text;

            if (cboAccionLexema.SelectedIndex == 1 || cboAccionLexema.SelectedIndex == 2)
            {
                cboTipoDeLexema.Enabled = false;

            }
            else
            {
                cboTipoDeLexema.Enabled = true;
            }
        }
        private void cboTipoDeLexema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDeLexema.SelectedIndex == 8 || cboTipoDeLexema.SelectedIndex == 9 || cboTipoDeLexema.SelectedIndex == 10 || cboTipoDeLexema.SelectedIndex == 12 || cboTipoDeLexema.SelectedIndex == 13 || cboTipoDeLexema.SelectedIndex == 14)
            {
                lblLexema.Enabled = false;
                txtLexema.Text = "";
                txtLexema.Enabled = false;
            }
            else
            {
                lblLexema.Enabled = true;
                txtLexema.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void txtCodigoAnalizadorLexico_TextChanged(object sender, EventArgs e)
        {
            AnalizadorLexico(txtTokens, txtCodigoAnalizadorLexico, true);
           txtCodigoFuenteSintactico.Text = txtCodigoAnalizadorLexico.Text;

        }


        public void AnalizadorLexico(TextBox ARGTokens, TextBox CodigoFuente, bool VentanaLexico)
        {
            // Limpiar el TextBox de tokens
            this.Invoke((MethodInvoker)delegate
            {
                ARGTokens.Clear();
            });
            // Leer el contenido del TextBox
            string texto = CodigoFuente.Text;

            // Dividir el contenido en líneas
            string[] lineas = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Listas para almacenar las variables, coeficientes e identificadores encontrados en el código
            List<VariableEnRAMLexico> misVariablesLexico = new List<VariableEnRAMLexico>();
            List<CoeficienteEnRAMLexico> misCoeficientesLexico = new List<CoeficienteEnRAMLexico>();
            List<IdentificadorEnRAM> misIdentificadoresEnRAM = new List<IdentificadorEnRAM>();


            bool ComentarioMultilineaActivo = false;

            bool ComentarioMultilinea = false;


            // Recorrer cada línea
            foreach (var linea in lineas)
            {

                // Dividir cada línea en palabras
                string[] palabras = linea.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Crear una lista para almacenar los tokens correspondientes
                List<string> tokens = new List<string>();

                // Variables para almacenar la palabra anterior y la penúltima
                string palabraAnterior = null;
                string palabraAnteAnterior = null;
                bool CadenaActiva = false;
                bool CadenaUnToken = false;
                bool CaracterActivo = false;
                bool ComentarioSimpleActivo = false;
                bool ComentarioSimpleUnToken = false;
                bool ComentarioMultilineaUnToken = false;
                bool ComillaAbierta = false;
                bool ComillaSimpleAbierta = false;
                bool ComentarioDeUnaLinea = false;


                // Recorrer cada palabra
                for (int j = 0; j < palabras.Length; j++)
                {
                    string palabra = palabras[j];
                    string palabraLower = palabra.ToLower();
                    bool BLNERROR = true;

                    // Verificar si la palabra ya está registrada como una variable o identificador
                    bool existeEnVariablesRAM = misVariablesLexico.Any(v => v.Lexema.ToLower() == palabraLower);
                    bool existeEnIdentificadoresRAM = misIdentificadoresEnRAM.Any(v => v.Lexema.ToLower() == palabraLower);

                    // Buscar en las listas de tokens y obtener el token correspondiente
                    var tokenEncontrado = miLenguaje.PalabrasReservadas.FirstOrDefault(p => p.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.TiposDeDatos.FirstOrDefault(t => t.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.OperadoresAritmeticos.FirstOrDefault(opa => opa.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.OperadoresLogicos.FirstOrDefault(opl => opl.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.OperadoresRelacionales.FirstOrDefault(opr => opr.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.Letreros.FirstOrDefault(lt => lt.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.Comentarios.FirstOrDefault(cm => cm.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.CaracteresEspeciales.FirstOrDefault(cs => cs.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.ValoresBooleanos.FirstOrDefault(VB => VB.Lexema.ToLower() == palabraLower)?.Token ??
                                          miLenguaje.Nulos.FirstOrDefault(NL => NL.Lexema.ToLower() == palabraLower)?.Token;

                    // Si se encontró un token, lo añadimos a la lista
                    if (tokenEncontrado != null && CaracterActivo == false && CadenaActiva == false && ComentarioSimpleActivo == false && ComentarioMultilineaActivo == false || palabraLower == "'" || palabraLower == "\"" || palabraLower == "¬" || palabraLower == "¬¬")
                    {


                        // Convertir Identificador a variable si está entre un tipo de dato y ;
                        if ((palabraLower == "=" || palabraLower == ";") && j > 0 && tokens.Count > j - 1 && tokens[j - 1].ToUpper() == "ID01" && palabraAnteAnterior != null && miLenguaje.TiposDeDatos.Any(t => t.Token.ToLower() == palabraAnteAnterior.ToLower()))
                        {
                            if (miLenguaje.Variables.Count > 0)
                            {
                                int numeroDetipoDeDato = 0;
                                foreach (var miTipoDeDato in miLenguaje.TiposDeDatos)
                                {
                                    numeroDetipoDeDato++;

                                    if (miTipoDeDato.Token.ToUpper() == palabraAnteAnterior.ToUpper())
                                    {
                                        misVariablesLexico.Add(new VariableEnRAMLexico(palabras[j - 1].ToUpper(), $"VAR{numeroDetipoDeDato}"));
                                    }
                                }





                            }
                        }

                        // Manejo de comillas simples
                        if (palabraLower == "'")
                        {

                            ComillaSimpleAbierta = !ComillaSimpleAbierta;
                            CaracterActivo = ComillaSimpleAbierta;


                        }

                        // Manejo de comillas dobles (cadena)
                        if (palabraLower == "\"")
                        {

                            ComillaAbierta = !ComillaAbierta;
                            CadenaActiva = ComillaAbierta;
                        }

                        // Manejo de comentario de una sola linea
                        if (palabraLower == "¬")
                        {
                            ComentarioDeUnaLinea = true;
                            ComentarioSimpleActivo = ComentarioDeUnaLinea;
                        }

                        // Manejo de comentario de una sola linea
                        if (palabraLower == "¬¬")
                        {
                            ComentarioMultilinea = !ComentarioMultilinea;
                            ComentarioMultilineaActivo = ComentarioMultilinea;


                        }


                        tokens.Add(tokenEncontrado);



                    }
                    else
                    {

                        if (CadenaActiva == false && CaracterActivo == false && ComentarioMultilineaActivo == false && ComentarioSimpleActivo == false)
                        {
                            if (existeEnVariablesRAM)
                            {

                                foreach (var miVariable in misVariablesLexico)
                                {

                                    if (miVariable.Lexema.ToUpper() == palabraLower.ToUpper())
                                    {

                                        tokens.Add(miVariable.Token);
                                        BLNERROR = false;
                                    }
                                }

                            }
                        }


                        // Si es un Identificador
                        if (palabraAnterior != null && miLenguaje.TiposDeDatos.Any(t => t.Token.ToLower() == palabraAnterior.ToLower()) && !existeEnVariablesRAM)
                        {
                            if (miLenguaje.ValidarNombreDeIdentificador(palabraLower, misIdentificadoresEnRAM))
                            {
                                tokens.Add(miLenguaje.Identificadores[0].Token);

                                misIdentificadoresEnRAM.Add(new IdentificadorEnRAM(palabraLower));
                                BLNERROR = false;
                            }
                        }

                        bool EsEntero = int.TryParse(palabraLower, out int result);
                        if (!existeEnVariablesRAM && !existeEnIdentificadoresRAM && EsEntero)
                        {
                            // Solo agregar coeficiente si no existe como variable o identificador
                            var coeficiente = new CoeficienteEnRAMLexico(palabraLower);
                            misCoeficientesLexico.Add(coeficiente);
                            tokens.Add(miLenguaje.Coeficientes[0].Token);
                            BLNERROR = false;
                        }

                        if (ComillaAbierta == true)
                        {
                            if (CadenaUnToken == false)
                            {
                                tokens.Add(miLenguaje.ContenidoDeCadenas[0].Token);
                                CadenaUnToken = true;
                            }


                            BLNERROR = false;
                        }



                        if (ComillaSimpleAbierta == true)//
                        {

                            if (palabraLower.Length == 1)
                            {
                                tokens.Add(miLenguaje.ContenidoDeCaracteres[0].Token);
                                BLNERROR = false;
                            }

                        }

                        if (ComentarioSimpleActivo == true)//
                        {
                            if (ComentarioSimpleUnToken == false)
                            {
                                tokens.Add(miLenguaje.ContenidoDeComentarios[0].Token);
                                ComentarioSimpleUnToken = true;
                            }
                            BLNERROR = false;

                        }

                        if (ComentarioMultilineaActivo)
                        {
                            if (ComentarioMultilineaUnToken == false)
                            {
                                tokens.Add(miLenguaje.ContenidoDeComentarios[0].Token);
                                ComentarioMultilineaUnToken = true;
                            }



                            BLNERROR = false;
                        }

                        if (BLNERROR == true)
                        {
                            tokens.Add("ERROR");
                        }

                    }

                    // Actualizar las palabras anteriores
                    palabraAnteAnterior = palabraAnterior;
                    palabraAnterior = tokenEncontrado; // Guarda el token actual en palabraAnterior
                }

                // Unir los tokens en una sola línea y añadir al TextBox de tokens
                this.Invoke((MethodInvoker)delegate
                {
                    ARGTokens.AppendText(string.Join(" ", tokens) + Environment.NewLine);
                });

            }

            if (VentanaLexico)
            {
                // Actualizar la tabla de símbolos léxicos
                ActualizarTablaDeSimbolosLexico(misVariablesLexico, misCoeficientesLexico);
            }
        }

        public void ActualizarTablaDeSimbolosLexico(List<VariableEnRAMLexico> misVariablesLexico, List<CoeficienteEnRAMLexico> misCoeficientesLexico)
        {
            dtgTablaDeSimbolosLexico.Rows.Clear();

            foreach (var miVariable in misVariablesLexico)
            {

                dtgTablaDeSimbolosLexico.Rows.Add(miVariable.Token, miVariable.Lexema, miLenguaje.Variables[0].TipoDeLexema);
            }
            foreach (var miCoeficiente in misCoeficientesLexico)
            {
                dtgTablaDeSimbolosLexico.Rows.Add(miLenguaje.Coeficientes[0].Token, miCoeficiente.Lexema, miLenguaje.Coeficientes[0].TipoDeLexema);
            }
        }
        private void lblCodigoAnalizadorLexico_Click(object sender, EventArgs e)
        {

        }
        private void tabPAnalizadorLexico_Click(object sender, EventArgs e)
        {

        }
        private void btnGuardarArchivoLexico_Click(object sender, EventArgs e)
        {
            GuardarArchivoLexico(txtCodigoAnalizadorLexico);
        }

        public void GuardarArchivoLexico(TextBox CodigoFuente)
        {
            // Crear una instancia de SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Filtros para el tipo de archivo
                saveFileDialog.Title = "Guardar archivo como"; // T tulo del di logo

                // Mostrar el di logo y verificar si el usuario seleccion  un archivo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtener el texto del TextBox
                        string texto = CodigoFuente.Text;

                        // Guardar el contenido del TextBox en el archivo seleccionado
                        File.WriteAllText(saveFileDialog.FileName, texto);
                        MessageBox.Show("El archivo se ha guardado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el archivo: {ex.Message}");
                    }
                }
            }
        }
        private void btnCargarArchivoLexico_Click(object sender, EventArgs e)
        {
            CargarArchivoLexico(txtCodigoAnalizadorLexico);

        }

        public void CargarArchivoLexico(TextBox CodigoFuente)
        {
            // Crear una instancia de OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Filtros para el tipo de archivo
                openFileDialog.Title = "Seleccionar archivo a cargar"; // T tulo del di logo

                // Mostrar el di logo y verificar si el usuario seleccion  un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Leer el contenido del archivo y cargarlo en el TextBox
                        string texto = File.ReadAllText(openFileDialog.FileName);
                        CodigoFuente.Text = texto;
                        MessageBox.Show("El archivo se ha cargado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el archivo: {ex.Message}");
                    }
                }
            }
        }
        private void txtTokensAnalizadorLexico_TextChanged(object sender, EventArgs e)
        {


        }




        // Método para obtener una línea específica del TextBox
        public string ObtenerLineaEspecifica(System.Windows.Forms.TextBox textBox, int lineIndex)
        {
            // Verifica si el TextBox tiene líneas
            if (textBox.Lines.Length > lineIndex && lineIndex >= 0)
            {
                return textBox.Lines[lineIndex]; // Devuelve la línea específica
            }

            return null; // Retorna null si el índice es inválido
        }
        private void txtPrueba_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTokens_TextChanged(object sender, EventArgs e)
        {


        }

        private void dtgAlfabeto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void txtCodigoFuenteSintactico_TextChanged(object sender, EventArgs e)
        {

            // Cancela el token de la operación anterior
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                // Espera 1000 milisegundos (ajusta según sea necesario) antes de ejecutar los métodos
                await Task.Delay(2000, _cancellationTokenSource.Token);

                // Ejecuta el análisis léxico y sintáctico
                AnalizadorLexico(txtTokensSintactico, txtCodigoFuenteSintactico, false);
                // Crear el parser
                AnalizadorSintactico miAnalizadorSintactico = new AnalizadorSintactico();
                txtArbolDerivacion.Text = miAnalizadorSintactico.ReduccionesAnalizadorSintactico(txtCodigoFuenteSintactico, txtTokensSintactico);
                miAnalizadorSintactico.MostrarListaDeEstadosDeLinea(dtgErrores);
                txtCodigoAnalizadorLexico.Text = txtCodigoFuenteSintactico.Text;
            }
            catch (TaskCanceledException)
            {
                // La tarea fue cancelada, no se realiza ninguna acción adicional
            }


        }



        private void btnGuardarSintactico_Click(object sender, EventArgs e)
        {
            GuardarArchivoLexico(txtCodigoFuenteSintactico);
        }

        private void btnCargarSintactico_Click(object sender, EventArgs e)
        {
            CargarArchivoLexico(txtCodigoFuenteSintactico);
        }

        private void txtTokensSintactico_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dtgErrores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgErrores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Suponiendo que el campo 2 es el índice 1 (segunda columna)
            if (e.ColumnIndex == 1) // Cambia este índice según la columna correspondiente
            {
                string value = e.Value?.ToString();

                if (value == "No Aceptado")
                {
                    // Cambiar el color de fondo a rojo
                    dtgErrores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (value == "Aceptado")
                {
                    // Cambiar el color de fondo a verde
                    dtgErrores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
    




