namespace PRUEBA_CLIENTES1
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBD = new System.Windows.Forms.Panel();
            this.dgvConfiguracionBD = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguracionBD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBD
            // 
            this.panelBD.Controls.Add(this.button3);
            this.panelBD.Controls.Add(this.button2);
            this.panelBD.Controls.Add(this.button1);
            this.panelBD.Controls.Add(this.dgvConfiguracionBD);
            this.panelBD.Location = new System.Drawing.Point(6, 23);
            this.panelBD.Name = "panelBD";
            this.panelBD.Size = new System.Drawing.Size(719, 263);
            this.panelBD.TabIndex = 0;
            // 
            // dgvConfiguracionBD
            // 
            this.dgvConfiguracionBD.AllowUserToDeleteRows = false;
            this.dgvConfiguracionBD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConfiguracionBD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvConfiguracionBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfiguracionBD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empresa,
            this.Ruta});
            this.dgvConfiguracionBD.Location = new System.Drawing.Point(19, 41);
            this.dgvConfiguracionBD.MultiSelect = false;
            this.dgvConfiguracionBD.Name = "dgvConfiguracionBD";
            this.dgvConfiguracionBD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfiguracionBD.Size = new System.Drawing.Size(681, 205);
            this.dgvConfiguracionBD.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(100, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(181, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelBD);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 306);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de datos";
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            // 
            // Ruta
            // 
            this.Ruta.DataPropertyName = "Ruta";
            this.Ruta.FillWeight = 200F;
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.Name = "Ruta";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(765, 332);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.panelBD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfiguracionBD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBD;
        private System.Windows.Forms.DataGridView dgvConfiguracionBD;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta;
    }
}