namespace PRUEBA_CLIENTES1
{
    partial class Clientes
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbFecha = new System.Windows.Forms.ComboBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCveFinCliente = new System.Windows.Forms.PictureBox();
            this.txtCveFinCliente = new System.Windows.Forms.TextBox();
            this.pbCveIniCliente = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCveIniCliente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.CboEmpresa = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvSaldos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCargos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAbono30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAbono3160 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblAbono6190 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbl90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCveFinCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCveIniCliente)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LblEmpresa);
            this.panel1.Controls.Add(this.CboEmpresa);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 163);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cmbEstatus);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel6.Location = new System.Drawing.Point(593, 62);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(232, 81);
            this.panel6.TabIndex = 6;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "ESTATUS";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "             Todos ",
            "             Activos ",
            "             Suspendidos",
            "             Morosos "});
            this.cmbEstatus.Location = new System.Drawing.Point(81, 34);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(128, 21);
            this.cmbEstatus.TabIndex = 35;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.cmbFecha);
            this.panel5.Controls.Add(this.dateTimePicker3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.dateTimePicker2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel5.Location = new System.Drawing.Point(304, 62);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 81);
            this.panel5.TabIndex = 5;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // cmbFecha
            // 
            this.cmbFecha.FormattingEnabled = true;
            this.cmbFecha.Items.AddRange(new object[] {
            "No filtrar fechas ",
            "Fechas seleccionadas",
            "Hoy ",
            "Ayer",
            "Este semana",
            "Este mes",
            "Mes anterior"});
            this.cmbFecha.Location = new System.Drawing.Point(79, 3);
            this.cmbFecha.Name = "cmbFecha";
            this.cmbFecha.Size = new System.Drawing.Size(126, 21);
            this.cmbFecha.TabIndex = 36;
            this.cmbFecha.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarForeColor = System.Drawing.SystemColors.ControlLight;
            this.dateTimePicker3.CalendarMonthBackground = System.Drawing.SystemColors.MenuHighlight;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(114, 30);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker3.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "FECHA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Hasta";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarForeColor = System.Drawing.SystemColors.ControlLight;
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.MenuHighlight;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(114, 53);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(91, 20);
            this.dateTimePicker2.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Desde";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pbCveFinCliente);
            this.panel4.Controls.Add(this.txtCveFinCliente);
            this.panel4.Controls.Add(this.pbCveIniCliente);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtCveIniCliente);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel4.Location = new System.Drawing.Point(11, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 81);
            this.panel4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "CLIENTE";
            // 
            // pbCveFinCliente
            // 
            this.pbCveFinCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCveFinCliente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCveFinCliente.Image = global::PRUEBA_CLIENTES1.Properties.Resources.Buscar;
            this.pbCveFinCliente.Location = new System.Drawing.Point(214, 43);
            this.pbCveFinCliente.Name = "pbCveFinCliente";
            this.pbCveFinCliente.Size = new System.Drawing.Size(17, 19);
            this.pbCveFinCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCveFinCliente.TabIndex = 35;
            this.pbCveFinCliente.TabStop = false;
            this.pbCveFinCliente.Click += new System.EventHandler(this.pbCveFinCliente_Click);
            // 
            // txtCveFinCliente
            // 
            this.txtCveFinCliente.Location = new System.Drawing.Point(174, 42);
            this.txtCveFinCliente.Name = "txtCveFinCliente";
            this.txtCveFinCliente.Size = new System.Drawing.Size(56, 20);
            this.txtCveFinCliente.TabIndex = 34;
            // 
            // pbCveIniCliente
            // 
            this.pbCveIniCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCveIniCliente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCveIniCliente.Image = global::PRUEBA_CLIENTES1.Properties.Resources.Buscar;
            this.pbCveIniCliente.Location = new System.Drawing.Point(101, 42);
            this.pbCveIniCliente.Name = "pbCveIniCliente";
            this.pbCveIniCliente.Size = new System.Drawing.Size(17, 19);
            this.pbCveIniCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCveIniCliente.TabIndex = 31;
            this.pbCveIniCliente.TabStop = false;
            this.pbCveIniCliente.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Desde";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Hasta";
            // 
            // txtCveIniCliente
            // 
            this.txtCveIniCliente.Location = new System.Drawing.Point(61, 41);
            this.txtCveIniCliente.Name = "txtCveIniCliente";
            this.txtCveIniCliente.Size = new System.Drawing.Size(56, 20);
            this.txtCveIniCliente.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(874, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 33);
            this.button1.TabIndex = 25;
            this.button1.Text = "Testing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(313, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "ANTIGÜEDAD DE SALDOS";
            this.label3.UseCompatibleTextRendering = true;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.AutoSize = true;
            this.LblEmpresa.BackColor = System.Drawing.SystemColors.Window;
            this.LblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEmpresa.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmpresa.ForeColor = System.Drawing.Color.Black;
            this.LblEmpresa.Location = new System.Drawing.Point(11, 13);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(67, 17);
            this.LblEmpresa.TabIndex = 10;
            this.LblEmpresa.Text = "EMPRESA";
            this.LblEmpresa.Click += new System.EventHandler(this.label5_Click);
            // 
            // CboEmpresa
            // 
            this.CboEmpresa.FormattingEnabled = true;
            this.CboEmpresa.Items.AddRange(new object[] {
            "LAN SERVICIOS Y COMERCIO SAPI DE CV (1)",
            "LAN SERVICIOS Y COMERCIO SAPI DE CV (2)",
            "VECA LLANTAS Y SERVICIOS SA DE CV (MATRIZ)",
            "VECA LLANTAS Y SERVICIOS SA DE CV (EJIDAL)",
            "VECA LLANTAS Y SERVICIOS SA DE CV (POZA RICA)"});
            this.CboEmpresa.Location = new System.Drawing.Point(82, 11);
            this.CboEmpresa.Name = "CboEmpresa";
            this.CboEmpresa.Size = new System.Drawing.Size(189, 21);
            this.CboEmpresa.TabIndex = 8;
            this.CboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(850, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 33);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvSaldos);
            this.panel2.Location = new System.Drawing.Point(12, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 364);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dgvSaldos
            // 
            this.dgvSaldos.AllowUserToAddRows = false;
            this.dgvSaldos.AllowUserToDeleteRows = false;
            this.dgvSaldos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaldos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.clmNombre,
            this.Column2,
            this.clmCargos,
            this.clmAbono30,
            this.tblAbono3160,
            this.tblAbono6190,
            this.tbl90,
            this.Column3,
            this.Column4});
            this.dgvSaldos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvSaldos.Location = new System.Drawing.Point(15, 38);
            this.dgvSaldos.Name = "dgvSaldos";
            this.dgvSaldos.ReadOnly = true;
            this.dgvSaldos.Size = new System.Drawing.Size(929, 313);
            this.dgvSaldos.TabIndex = 0;
            this.dgvSaldos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(12, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 40);
            this.panel3.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1023, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ClaveInicial";
            this.Column1.HeaderText = "Clave";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 81;
            // 
            // clmNombre
            // 
            this.clmNombre.DataPropertyName = "Nombre";
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            this.clmNombre.Width = 82;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Saldo inicial ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 81;
            // 
            // clmCargos
            // 
            this.clmCargos.DataPropertyName = "Cargos";
            this.clmCargos.HeaderText = "Cargos";
            this.clmCargos.Name = "clmCargos";
            this.clmCargos.ReadOnly = true;
            this.clmCargos.Width = 82;
            // 
            // clmAbono30
            // 
            this.clmAbono30.DataPropertyName = "Abono30";
            this.clmAbono30.HeaderText = "Abono 30";
            this.clmAbono30.Name = "clmAbono30";
            this.clmAbono30.ReadOnly = true;
            this.clmAbono30.Width = 81;
            // 
            // tblAbono3160
            // 
            this.tblAbono3160.DataPropertyName = "Abono60";
            this.tblAbono3160.HeaderText = "Abono 31-60 ";
            this.tblAbono3160.Name = "tblAbono3160";
            this.tblAbono3160.ReadOnly = true;
            this.tblAbono3160.Width = 81;
            // 
            // tblAbono6190
            // 
            this.tblAbono6190.DataPropertyName = "Abono90";
            this.tblAbono6190.HeaderText = "Abono 61-90";
            this.tblAbono6190.Name = "tblAbono6190";
            this.tblAbono6190.ReadOnly = true;
            this.tblAbono6190.Width = 82;
            // 
            // tbl90
            // 
            this.tbl90.DataPropertyName = "AbonoPlus90";
            this.tbl90.HeaderText = "Abono + 90";
            this.tbl90.Name = "tbl90";
            this.tbl90.ReadOnly = true;
            this.tbl90.Width = 81;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Saldo final";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 82;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Status";
            this.Column4.HeaderText = "Estatus";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 81;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 657);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Clientes";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Clientes_FormClosed);
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCveFinCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCveIniCliente)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSaldos;
        private System.Windows.Forms.ComboBox CboEmpresa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label LblEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbCveIniCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCveIniCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCveFinCliente;
        private System.Windows.Forms.TextBox txtCveFinCliente;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCargos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAbono30;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblAbono3160;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblAbono6190;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbl90;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

