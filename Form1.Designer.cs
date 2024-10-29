namespace Lenguaje
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabMenus = new TabControl();
            tabPAnalizadorLexico = new TabPage();
            btnCargarArchivoLexico = new Button();
            btnGuardarArchivoLexico = new Button();
            dtgTablaDeSimbolosLexico = new DataGridView();
            colTokenTablaSimbolos = new DataGridViewTextBoxColumn();
            colLexemaTablaDeSimbolosLexico = new DataGridViewTextBoxColumn();
            colTipoLexemaTablaDeSimbolosLexico = new DataGridViewTextBoxColumn();
            lblTablaDeSimbolosLexico = new Label();
            txtTokens = new TextBox();
            lblTokenAnalizadorLexico = new Label();
            lblCodigoAnalizadorLexico = new Label();
            txtCodigoAnalizadorLexico = new TextBox();
            tabAnalizadorSintactico = new TabPage();
            txtArbolDerivacion = new TextBox();
            dtgErrores = new DataGridView();
            btnCargarSintactico = new Button();
            btnGuardarSintactico = new Button();
            txtTokensSintactico = new TextBox();
            lblTokensSintactico = new Label();
            txtCodigoFuenteSintactico = new TextBox();
            lblCodigoFuenteSintactico = new Label();
            tabPConfAlfabeto = new TabPage();
            cboMostrarTipoDeLexema = new ComboBox();
            lblMostrarAlfabeto = new Label();
            dtgAlfabeto = new DataGridView();
            colToken = new DataGridViewTextBoxColumn();
            colLexema = new DataGridViewTextBoxColumn();
            colTipoDeLexema = new DataGridViewTextBoxColumn();
            grpConfLexema = new GroupBox();
            btnAccion = new Button();
            txtToken = new TextBox();
            label2 = new Label();
            lblToken = new Label();
            txtLexema = new TextBox();
            lblLexema = new Label();
            cboAccionLexema = new ComboBox();
            lblAccionConfLexema = new Label();
            cboTipoDeLexema = new ComboBox();
            lblTipoDeLexema = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tabMenus.SuspendLayout();
            tabPAnalizadorLexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgTablaDeSimbolosLexico).BeginInit();
            tabAnalizadorSintactico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgErrores).BeginInit();
            tabPConfAlfabeto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAlfabeto).BeginInit();
            grpConfLexema.SuspendLayout();
            SuspendLayout();
            // 
            // tabMenus
            // 
            tabMenus.Controls.Add(tabPAnalizadorLexico);
            tabMenus.Controls.Add(tabAnalizadorSintactico);
            tabMenus.Controls.Add(tabPConfAlfabeto);
            tabMenus.Location = new Point(12, 12);
            tabMenus.Name = "tabMenus";
            tabMenus.SelectedIndex = 0;
            tabMenus.Size = new Size(1346, 426);
            tabMenus.TabIndex = 0;
            // 
            // tabPAnalizadorLexico
            // 
            tabPAnalizadorLexico.Controls.Add(btnCargarArchivoLexico);
            tabPAnalizadorLexico.Controls.Add(btnGuardarArchivoLexico);
            tabPAnalizadorLexico.Controls.Add(dtgTablaDeSimbolosLexico);
            tabPAnalizadorLexico.Controls.Add(lblTablaDeSimbolosLexico);
            tabPAnalizadorLexico.Controls.Add(txtTokens);
            tabPAnalizadorLexico.Controls.Add(lblTokenAnalizadorLexico);
            tabPAnalizadorLexico.Controls.Add(lblCodigoAnalizadorLexico);
            tabPAnalizadorLexico.Controls.Add(txtCodigoAnalizadorLexico);
            tabPAnalizadorLexico.Location = new Point(4, 24);
            tabPAnalizadorLexico.Name = "tabPAnalizadorLexico";
            tabPAnalizadorLexico.Padding = new Padding(3);
            tabPAnalizadorLexico.Size = new Size(1338, 398);
            tabPAnalizadorLexico.TabIndex = 0;
            tabPAnalizadorLexico.Text = "Analizador Lexico";
            tabPAnalizadorLexico.UseVisualStyleBackColor = true;
            tabPAnalizadorLexico.Click += tabPAnalizadorLexico_Click;
            // 
            // btnCargarArchivoLexico
            // 
            btnCargarArchivoLexico.Location = new Point(125, 355);
            btnCargarArchivoLexico.Name = "btnCargarArchivoLexico";
            btnCargarArchivoLexico.Size = new Size(116, 37);
            btnCargarArchivoLexico.TabIndex = 7;
            btnCargarArchivoLexico.Text = "Cargar";
            btnCargarArchivoLexico.UseVisualStyleBackColor = true;
            btnCargarArchivoLexico.Click += btnCargarArchivoLexico_Click;
            // 
            // btnGuardarArchivoLexico
            // 
            btnGuardarArchivoLexico.Location = new Point(16, 355);
            btnGuardarArchivoLexico.Name = "btnGuardarArchivoLexico";
            btnGuardarArchivoLexico.Size = new Size(103, 37);
            btnGuardarArchivoLexico.TabIndex = 6;
            btnGuardarArchivoLexico.Text = "Guardar";
            btnGuardarArchivoLexico.UseVisualStyleBackColor = true;
            btnGuardarArchivoLexico.Click += btnGuardarArchivoLexico_Click;
            // 
            // dtgTablaDeSimbolosLexico
            // 
            dtgTablaDeSimbolosLexico.AllowUserToAddRows = false;
            dtgTablaDeSimbolosLexico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgTablaDeSimbolosLexico.Columns.AddRange(new DataGridViewColumn[] { colTokenTablaSimbolos, colLexemaTablaDeSimbolosLexico, colTipoLexemaTablaDeSimbolosLexico });
            dtgTablaDeSimbolosLexico.Location = new Point(688, 50);
            dtgTablaDeSimbolosLexico.Name = "dtgTablaDeSimbolosLexico";
            dtgTablaDeSimbolosLexico.Size = new Size(345, 150);
            dtgTablaDeSimbolosLexico.TabIndex = 5;
            // 
            // colTokenTablaSimbolos
            // 
            colTokenTablaSimbolos.Frozen = true;
            colTokenTablaSimbolos.HeaderText = "TOKEN";
            colTokenTablaSimbolos.Name = "colTokenTablaSimbolos";
            colTokenTablaSimbolos.ReadOnly = true;
            // 
            // colLexemaTablaDeSimbolosLexico
            // 
            colLexemaTablaDeSimbolosLexico.Frozen = true;
            colLexemaTablaDeSimbolosLexico.HeaderText = "LEXEMA";
            colLexemaTablaDeSimbolosLexico.Name = "colLexemaTablaDeSimbolosLexico";
            colLexemaTablaDeSimbolosLexico.ReadOnly = true;
            // 
            // colTipoLexemaTablaDeSimbolosLexico
            // 
            colTipoLexemaTablaDeSimbolosLexico.Frozen = true;
            colTipoLexemaTablaDeSimbolosLexico.HeaderText = "TIPO";
            colTipoLexemaTablaDeSimbolosLexico.Name = "colTipoLexemaTablaDeSimbolosLexico";
            colTipoLexemaTablaDeSimbolosLexico.ReadOnly = true;
            // 
            // lblTablaDeSimbolosLexico
            // 
            lblTablaDeSimbolosLexico.AutoSize = true;
            lblTablaDeSimbolosLexico.Location = new Point(688, 16);
            lblTablaDeSimbolosLexico.Name = "lblTablaDeSimbolosLexico";
            lblTablaDeSimbolosLexico.Size = new Size(101, 15);
            lblTablaDeSimbolosLexico.TabIndex = 4;
            lblTablaDeSimbolosLexico.Text = "Tabla de simbolos";
            // 
            // txtTokens
            // 
            txtTokens.Location = new Point(359, 32);
            txtTokens.Multiline = true;
            txtTokens.Name = "txtTokens";
            txtTokens.ReadOnly = true;
            txtTokens.ScrollBars = ScrollBars.Both;
            txtTokens.Size = new Size(323, 317);
            txtTokens.TabIndex = 3;
            txtTokens.TextChanged += txtTokens_TextChanged;
            // 
            // lblTokenAnalizadorLexico
            // 
            lblTokenAnalizadorLexico.AutoSize = true;
            lblTokenAnalizadorLexico.Location = new Point(359, 14);
            lblTokenAnalizadorLexico.Name = "lblTokenAnalizadorLexico";
            lblTokenAnalizadorLexico.Size = new Size(43, 15);
            lblTokenAnalizadorLexico.TabIndex = 2;
            lblTokenAnalizadorLexico.Text = "Tokens";
            // 
            // lblCodigoAnalizadorLexico
            // 
            lblCodigoAnalizadorLexico.AutoSize = true;
            lblCodigoAnalizadorLexico.Location = new Point(16, 16);
            lblCodigoAnalizadorLexico.Name = "lblCodigoAnalizadorLexico";
            lblCodigoAnalizadorLexico.Size = new Size(85, 15);
            lblCodigoAnalizadorLexico.TabIndex = 1;
            lblCodigoAnalizadorLexico.Text = "Codigo Fuente";
            lblCodigoAnalizadorLexico.Click += lblCodigoAnalizadorLexico_Click;
            // 
            // txtCodigoAnalizadorLexico
            // 
            txtCodigoAnalizadorLexico.Location = new Point(16, 34);
            txtCodigoAnalizadorLexico.Multiline = true;
            txtCodigoAnalizadorLexico.Name = "txtCodigoAnalizadorLexico";
            txtCodigoAnalizadorLexico.ScrollBars = ScrollBars.Both;
            txtCodigoAnalizadorLexico.Size = new Size(337, 315);
            txtCodigoAnalizadorLexico.TabIndex = 0;
            txtCodigoAnalizadorLexico.TextChanged += txtCodigoAnalizadorLexico_TextChanged;
            // 
            // tabAnalizadorSintactico
            // 
            tabAnalizadorSintactico.Controls.Add(txtArbolDerivacion);
            tabAnalizadorSintactico.Controls.Add(dtgErrores);
            tabAnalizadorSintactico.Controls.Add(btnCargarSintactico);
            tabAnalizadorSintactico.Controls.Add(btnGuardarSintactico);
            tabAnalizadorSintactico.Controls.Add(txtTokensSintactico);
            tabAnalizadorSintactico.Controls.Add(lblTokensSintactico);
            tabAnalizadorSintactico.Controls.Add(txtCodigoFuenteSintactico);
            tabAnalizadorSintactico.Controls.Add(lblCodigoFuenteSintactico);
            tabAnalizadorSintactico.Location = new Point(4, 24);
            tabAnalizadorSintactico.Name = "tabAnalizadorSintactico";
            tabAnalizadorSintactico.Size = new Size(1338, 398);
            tabAnalizadorSintactico.TabIndex = 2;
            tabAnalizadorSintactico.Text = "Analizador Sintactico";
            tabAnalizadorSintactico.UseVisualStyleBackColor = true;
            // 
            // txtArbolDerivacion
            // 
            txtArbolDerivacion.Location = new Point(586, 43);
            txtArbolDerivacion.Multiline = true;
            txtArbolDerivacion.Name = "txtArbolDerivacion";
            txtArbolDerivacion.ReadOnly = true;
            txtArbolDerivacion.ScrollBars = ScrollBars.Vertical;
            txtArbolDerivacion.Size = new Size(732, 167);
            txtArbolDerivacion.TabIndex = 10;
            // 
            // dtgErrores
            // 
            dtgErrores.AllowUserToAddRows = false;
            dtgErrores.AllowUserToDeleteRows = false;
            dtgErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgErrores.Location = new Point(586, 217);
            dtgErrores.Name = "dtgErrores";
            dtgErrores.ReadOnly = true;
            dtgErrores.Size = new Size(732, 120);
            dtgErrores.TabIndex = 9;
            dtgErrores.CellContentClick += dtgErrores_CellContentClick;
            dtgErrores.CellFormatting += dtgErrores_CellFormatting;
            // 
            // btnCargarSintactico
            // 
            btnCargarSintactico.Location = new Point(126, 343);
            btnCargarSintactico.Name = "btnCargarSintactico";
            btnCargarSintactico.Size = new Size(116, 37);
            btnCargarSintactico.TabIndex = 8;
            btnCargarSintactico.Text = "Cargar";
            btnCargarSintactico.UseVisualStyleBackColor = true;
            btnCargarSintactico.Click += btnCargarSintactico_Click;
            // 
            // btnGuardarSintactico
            // 
            btnGuardarSintactico.Location = new Point(17, 343);
            btnGuardarSintactico.Name = "btnGuardarSintactico";
            btnGuardarSintactico.Size = new Size(103, 37);
            btnGuardarSintactico.TabIndex = 7;
            btnGuardarSintactico.Text = "Guardar";
            btnGuardarSintactico.UseVisualStyleBackColor = true;
            btnGuardarSintactico.Click += btnGuardarSintactico_Click;
            // 
            // txtTokensSintactico
            // 
            txtTokensSintactico.Location = new Point(295, 43);
            txtTokensSintactico.Multiline = true;
            txtTokensSintactico.Name = "txtTokensSintactico";
            txtTokensSintactico.ReadOnly = true;
            txtTokensSintactico.ScrollBars = ScrollBars.Both;
            txtTokensSintactico.Size = new Size(285, 294);
            txtTokensSintactico.TabIndex = 5;
            txtTokensSintactico.TextChanged += txtTokensSintactico_TextChanged;
            // 
            // lblTokensSintactico
            // 
            lblTokensSintactico.AutoSize = true;
            lblTokensSintactico.Location = new Point(295, 25);
            lblTokensSintactico.Name = "lblTokensSintactico";
            lblTokensSintactico.Size = new Size(43, 15);
            lblTokensSintactico.TabIndex = 4;
            lblTokensSintactico.Text = "Tokens";
            // 
            // txtCodigoFuenteSintactico
            // 
            txtCodigoFuenteSintactico.Location = new Point(17, 43);
            txtCodigoFuenteSintactico.Multiline = true;
            txtCodigoFuenteSintactico.Name = "txtCodigoFuenteSintactico";
            txtCodigoFuenteSintactico.ScrollBars = ScrollBars.Both;
            txtCodigoFuenteSintactico.Size = new Size(261, 294);
            txtCodigoFuenteSintactico.TabIndex = 3;
            txtCodigoFuenteSintactico.TextChanged += txtCodigoFuenteSintactico_TextChanged;
            // 
            // lblCodigoFuenteSintactico
            // 
            lblCodigoFuenteSintactico.AutoSize = true;
            lblCodigoFuenteSintactico.Location = new Point(17, 25);
            lblCodigoFuenteSintactico.Name = "lblCodigoFuenteSintactico";
            lblCodigoFuenteSintactico.Size = new Size(85, 15);
            lblCodigoFuenteSintactico.TabIndex = 2;
            lblCodigoFuenteSintactico.Text = "Codigo Fuente";
            // 
            // tabPConfAlfabeto
            // 
            tabPConfAlfabeto.Controls.Add(cboMostrarTipoDeLexema);
            tabPConfAlfabeto.Controls.Add(lblMostrarAlfabeto);
            tabPConfAlfabeto.Controls.Add(dtgAlfabeto);
            tabPConfAlfabeto.Controls.Add(grpConfLexema);
            tabPConfAlfabeto.Location = new Point(4, 24);
            tabPConfAlfabeto.Name = "tabPConfAlfabeto";
            tabPConfAlfabeto.Padding = new Padding(3);
            tabPConfAlfabeto.Size = new Size(1338, 398);
            tabPConfAlfabeto.TabIndex = 1;
            tabPConfAlfabeto.Text = "Configuracion de Alfabeto";
            tabPConfAlfabeto.UseVisualStyleBackColor = true;
            // 
            // cboMostrarTipoDeLexema
            // 
            cboMostrarTipoDeLexema.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMostrarTipoDeLexema.FormattingEnabled = true;
            cboMostrarTipoDeLexema.Items.AddRange(new object[] { "Todo", "Palabra Reservadas", "Tipos De Datos", "Operadores Aritmeticos", "Operadores Logicos", "Operadores Relacionales", "Letreros", "Comentarios", "Caracteres Especiales", "Variable", "Coeficiente", "Identificador", "Valores Booleanos", "Cadena", "Caracter", "Contenido De Comentario", "Nulo" });
            cboMostrarTipoDeLexema.Location = new Point(343, 9);
            cboMostrarTipoDeLexema.Name = "cboMostrarTipoDeLexema";
            cboMostrarTipoDeLexema.Size = new Size(121, 23);
            cboMostrarTipoDeLexema.TabIndex = 7;
            cboMostrarTipoDeLexema.SelectedIndexChanged += cboMostrarTipoDeLexema_SelectedIndexChanged;
            // 
            // lblMostrarAlfabeto
            // 
            lblMostrarAlfabeto.AutoSize = true;
            lblMostrarAlfabeto.Location = new Point(286, 17);
            lblMostrarAlfabeto.Name = "lblMostrarAlfabeto";
            lblMostrarAlfabeto.Size = new Size(51, 15);
            lblMostrarAlfabeto.TabIndex = 6;
            lblMostrarAlfabeto.Text = "Mostrar:";
            // 
            // dtgAlfabeto
            // 
            dtgAlfabeto.AllowUserToAddRows = false;
            dtgAlfabeto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgAlfabeto.Columns.AddRange(new DataGridViewColumn[] { colToken, colLexema, colTipoDeLexema });
            dtgAlfabeto.Location = new Point(286, 35);
            dtgAlfabeto.Name = "dtgAlfabeto";
            dtgAlfabeto.Size = new Size(461, 346);
            dtgAlfabeto.TabIndex = 5;
            dtgAlfabeto.CellClick += dtgAlfabeto_CellClick;
            dtgAlfabeto.CellContentClick += dtgAlfabeto_CellContentClick;
            // 
            // colToken
            // 
            colToken.Frozen = true;
            colToken.HeaderText = "TOKEN";
            colToken.Name = "colToken";
            colToken.ReadOnly = true;
            // 
            // colLexema
            // 
            colLexema.Frozen = true;
            colLexema.HeaderText = "LEXEMA";
            colLexema.Name = "colLexema";
            colLexema.ReadOnly = true;
            // 
            // colTipoDeLexema
            // 
            colTipoDeLexema.Frozen = true;
            colTipoDeLexema.HeaderText = "TIPO DE LEXEMA";
            colTipoDeLexema.Name = "colTipoDeLexema";
            colTipoDeLexema.ReadOnly = true;
            // 
            // grpConfLexema
            // 
            grpConfLexema.Controls.Add(btnAccion);
            grpConfLexema.Controls.Add(txtToken);
            grpConfLexema.Controls.Add(label2);
            grpConfLexema.Controls.Add(lblToken);
            grpConfLexema.Controls.Add(txtLexema);
            grpConfLexema.Controls.Add(lblLexema);
            grpConfLexema.Controls.Add(cboAccionLexema);
            grpConfLexema.Controls.Add(lblAccionConfLexema);
            grpConfLexema.Controls.Add(cboTipoDeLexema);
            grpConfLexema.Controls.Add(lblTipoDeLexema);
            grpConfLexema.Location = new Point(6, 6);
            grpConfLexema.Name = "grpConfLexema";
            grpConfLexema.Size = new Size(248, 375);
            grpConfLexema.TabIndex = 4;
            grpConfLexema.TabStop = false;
            grpConfLexema.Text = "Configuracion de Lexema";
            // 
            // btnAccion
            // 
            btnAccion.Location = new Point(6, 330);
            btnAccion.Name = "btnAccion";
            btnAccion.Size = new Size(227, 23);
            btnAccion.TabIndex = 11;
            btnAccion.Text = "Accion";
            btnAccion.UseVisualStyleBackColor = true;
            btnAccion.Click += btnAccion_Click;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(103, 178);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(131, 23);
            txtToken.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 139);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 7;
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(6, 181);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(41, 15);
            lblToken.TabIndex = 6;
            lblToken.Text = "Token:";
            // 
            // txtLexema
            // 
            txtLexema.Location = new Point(103, 256);
            txtLexema.Name = "txtLexema";
            txtLexema.Size = new Size(131, 23);
            txtLexema.TabIndex = 5;
            // 
            // lblLexema
            // 
            lblLexema.AutoSize = true;
            lblLexema.Location = new Point(12, 264);
            lblLexema.Name = "lblLexema";
            lblLexema.Size = new Size(51, 15);
            lblLexema.TabIndex = 4;
            lblLexema.Text = "Lexema:";
            // 
            // cboAccionLexema
            // 
            cboAccionLexema.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAccionLexema.FormattingEnabled = true;
            cboAccionLexema.Items.AddRange(new object[] { "Agregar", "Modificar", "Eliminar" });
            cboAccionLexema.Location = new Point(103, 22);
            cboAccionLexema.Name = "cboAccionLexema";
            cboAccionLexema.Size = new Size(131, 23);
            cboAccionLexema.TabIndex = 3;
            cboAccionLexema.SelectedIndexChanged += cboAccionLexema_SelectedIndexChanged;
            // 
            // lblAccionConfLexema
            // 
            lblAccionConfLexema.AutoSize = true;
            lblAccionConfLexema.Location = new Point(7, 25);
            lblAccionConfLexema.Name = "lblAccionConfLexema";
            lblAccionConfLexema.Size = new Size(50, 15);
            lblAccionConfLexema.TabIndex = 2;
            lblAccionConfLexema.Text = "Accion: ";
            // 
            // cboTipoDeLexema
            // 
            cboTipoDeLexema.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoDeLexema.FormattingEnabled = true;
            cboTipoDeLexema.Items.AddRange(new object[] { "Palabra Reservada", "Tipo De Dato", "Operador Aritmetico", "Operador Logico", "Operador Relacional", "Letrero", "Comentario", "Caracter Especial", "Variable", "Coeficiente", "Identificador", "Booleano", "Cadena", "Caracter", "Contenido De Comentario", "Nulo" });
            cboTipoDeLexema.Location = new Point(103, 113);
            cboTipoDeLexema.Name = "cboTipoDeLexema";
            cboTipoDeLexema.Size = new Size(131, 23);
            cboTipoDeLexema.TabIndex = 1;
            cboTipoDeLexema.SelectedIndexChanged += cboTipoDeLexema_SelectedIndexChanged;
            // 
            // lblTipoDeLexema
            // 
            lblTipoDeLexema.AutoSize = true;
            lblTipoDeLexema.Location = new Point(7, 116);
            lblTipoDeLexema.Name = "lblTipoDeLexema";
            lblTipoDeLexema.Size = new Size(90, 15);
            lblTipoDeLexema.TabIndex = 0;
            lblTipoDeLexema.Text = "Tipo de lexema:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 450);
            Controls.Add(tabMenus);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabMenus.ResumeLayout(false);
            tabPAnalizadorLexico.ResumeLayout(false);
            tabPAnalizadorLexico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgTablaDeSimbolosLexico).EndInit();
            tabAnalizadorSintactico.ResumeLayout(false);
            tabAnalizadorSintactico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgErrores).EndInit();
            tabPConfAlfabeto.ResumeLayout(false);
            tabPConfAlfabeto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgAlfabeto).EndInit();
            grpConfLexema.ResumeLayout(false);
            grpConfLexema.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMenus;
        private TabPage tabPAnalizadorLexico;
        private TabPage tabPConfAlfabeto;
        private GroupBox grpConfLexema;
        private TextBox txtToken;
        private Label label2;
        private Label lblToken;
        private TextBox txtLexema;
        private Label lblLexema;
        private ComboBox cboAccionLexema;
        private Label lblAccionConfLexema;
        private ComboBox cboTipoDeLexema;
        private Label lblTipoDeLexema;
        private Button btnAccion;
        private ComboBox cboMostrarTipoDeLexema;
        private Label lblMostrarAlfabeto;
        private DataGridView dtgAlfabeto;
        private DataGridViewTextBoxColumn colToken;
        private DataGridViewTextBoxColumn colLexema;
        private DataGridViewTextBoxColumn colTipoDeLexema;
        private TextBox txtCodigoAnalizadorLexico;
        private Label lblCodigoAnalizadorLexico;
        private Label lblTokenAnalizadorLexico;
        private Label lblTablaDeSimbolosLexico;
        private DataGridView dtgTablaDeSimbolosLexico;
        private DataGridViewTextBoxColumn colTokenTablaSimbolos;
        private DataGridViewTextBoxColumn colLexemaTablaDeSimbolosLexico;
        private DataGridViewTextBoxColumn colTipoLexemaTablaDeSimbolosLexico;
        private Button btnGuardarArchivoLexico;
        private Button btnCargarArchivoLexico;
        private TextBox txtTokens;
        private TabPage tabAnalizadorSintactico;
        private Button btnGuardarSintactico;
        private TextBox txtTokensSintactico;
        private Label lblTokensSintactico;
        private Label lblCodigoFuenteSintactico;
        private Button btnCargarSintactico;
        private TextBox txtArbolDerivacion;
        private System.Windows.Forms.Timer timer1;
        public DataGridView dtgErrores;
        public TextBox txtCodigoFuenteSintactico;
    }
}
