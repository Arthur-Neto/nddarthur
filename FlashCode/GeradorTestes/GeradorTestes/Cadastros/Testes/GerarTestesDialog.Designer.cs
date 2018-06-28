namespace GeradorTestes.Cadastros.Testes
{
    partial class GerarTestesDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.lblDisciplinna = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cmbBimestre = new System.Windows.Forms.ComboBox();
            this.lblBimestre = new System.Windows.Forms.Label();
            this.btnGerarTeste = new System.Windows.Forms.Button();
            this.quantidadeQuestoes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.cmbSerie);
            this.groupBox1.Controls.Add(this.lblSerie);
            this.groupBox1.Controls.Add(this.cmbDisciplina);
            this.groupBox1.Controls.Add(this.lblDisciplinna);
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 164);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cmbSerie
            // 
            this.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(14, 47);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(113, 21);
            this.cmbSerie.TabIndex = 1;
            this.cmbSerie.SelectedIndexChanged += new System.EventHandler(this.cmbSerie_SelectedIndexChanged);
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(14, 30);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(31, 13);
            this.lblSerie.TabIndex = 0;
            this.lblSerie.Text = "Série";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(17, 103);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(110, 21);
            this.cmbDisciplina.TabIndex = 3;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // lblDisciplinna
            // 
            this.lblDisciplinna.AutoSize = true;
            this.lblDisciplinna.Location = new System.Drawing.Point(14, 83);
            this.lblDisciplinna.Name = "lblDisciplinna";
            this.lblDisciplinna.Size = new System.Drawing.Size(52, 13);
            this.lblDisciplinna.TabIndex = 4;
            this.lblDisciplinna.Text = "Disciplina";
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(186, 114);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(143, 21);
            this.cmbMateria.TabIndex = 29;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(183, 93);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 32;
            this.lblMateria.Text = "Matéria";
            // 
            // cmbBimestre
            // 
            this.cmbBimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBimestre.FormattingEnabled = true;
            this.cmbBimestre.Location = new System.Drawing.Point(186, 58);
            this.cmbBimestre.Name = "cmbBimestre";
            this.cmbBimestre.Size = new System.Drawing.Size(143, 21);
            this.cmbBimestre.TabIndex = 31;
            // 
            // lblBimestre
            // 
            this.lblBimestre.AutoSize = true;
            this.lblBimestre.Location = new System.Drawing.Point(183, 41);
            this.lblBimestre.Name = "lblBimestre";
            this.lblBimestre.Size = new System.Drawing.Size(47, 13);
            this.lblBimestre.TabIndex = 30;
            this.lblBimestre.Text = "Bimestre";
            // 
            // btnGerarTeste
            // 
            this.btnGerarTeste.Location = new System.Drawing.Point(254, 258);
            this.btnGerarTeste.Name = "btnGerarTeste";
            this.btnGerarTeste.Size = new System.Drawing.Size(75, 23);
            this.btnGerarTeste.TabIndex = 34;
            this.btnGerarTeste.Text = "Gerar Teste";
            this.btnGerarTeste.UseVisualStyleBackColor = true;
            this.btnGerarTeste.Click += new System.EventHandler(this.btnGerarTeste_Click);
            // 
            // quantidadeQuestoes
            // 
            this.quantidadeQuestoes.Location = new System.Drawing.Point(22, 194);
            this.quantidadeQuestoes.Name = "quantidadeQuestoes";
            this.quantidadeQuestoes.Size = new System.Drawing.Size(75, 20);
            this.quantidadeQuestoes.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantidade de questões";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(52, 130);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 36;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // GerarTestesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quantidadeQuestoes);
            this.Controls.Add(this.btnGerarTeste);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.cmbBimestre);
            this.Controls.Add(this.lblBimestre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GerarTestesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label lblDisciplinna;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbBimestre;
        private System.Windows.Forms.Label lblBimestre;
        private System.Windows.Forms.Button btnGerarTeste;
        private System.Windows.Forms.NumericUpDown quantidadeQuestoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpar;
    }
}