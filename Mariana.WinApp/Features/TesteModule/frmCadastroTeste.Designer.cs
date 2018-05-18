namespace Mariana.WinApp.Features.TesteModule
{
    partial class frmCadastroTeste
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
            this.lblNomeTeste = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNumeroQuestoes = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.nupNumeroQuestoes = new System.Windows.Forms.NumericUpDown();
            this.txtCaminhoDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCaminho = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumeroQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeTeste
            // 
            this.lblNomeTeste.AutoSize = true;
            this.lblNomeTeste.Location = new System.Drawing.Point(84, 57);
            this.lblNomeTeste.Name = "lblNomeTeste";
            this.lblNomeTeste.Size = new System.Drawing.Size(41, 13);
            this.lblNomeTeste.TabIndex = 0;
            this.lblNomeTeste.Text = "Nome :";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(131, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(273, 20);
            this.txtNome.TabIndex = 1;
            // 
            // lblNumeroQuestoes
            // 
            this.lblNumeroQuestoes.AutoSize = true;
            this.lblNumeroQuestoes.Location = new System.Drawing.Point(51, 156);
            this.lblNumeroQuestoes.Name = "lblNumeroQuestoes";
            this.lblNumeroQuestoes.Size = new System.Drawing.Size(76, 13);
            this.lblNumeroQuestoes.TabIndex = 2;
            this.lblNumeroQuestoes.Text = " Nº Questões :";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDisciplina.Enabled = false;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(131, 102);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(273, 21);
            this.cmbDisciplina.TabIndex = 68;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(131, 25);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(55, 20);
            this.txtId.TabIndex = 67;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(106, 29);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(19, 13);
            this.lblID.TabIndex = 66;
            this.lblID.Text = "Id:";
            // 
            // cmbSerie
            // 
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(132, 76);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(272, 21);
            this.cmbSerie.TabIndex = 65;
            this.cmbSerie.SelectedIndexChanged += new System.EventHandler(this.cmbSerie_SelectedIndexChanged);
            this.cmbSerie.SelectedValueChanged += new System.EventHandler(this.cmbSerie_SelectedIndexChanged);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(72, 105);
            this.lblDisciplina.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lblDisciplina.TabIndex = 64;
            this.lblDisciplina.Text = "Disciplina:";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(93, 78);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 63;
            this.lblSerie.Text = "Série:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(131, 129);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(273, 21);
            this.cmbMateria.TabIndex = 70;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(82, 130);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(45, 13);
            this.lblMateria.TabIndex = 69;
            this.lblMateria.Text = "Matéria:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(243, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 43);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCadastrar.Location = new System.Drawing.Point(131, 222);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(96, 43);
            this.btnCadastrar.TabIndex = 71;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // nupNumeroQuestoes
            // 
            this.nupNumeroQuestoes.Location = new System.Drawing.Point(131, 156);
            this.nupNumeroQuestoes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupNumeroQuestoes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupNumeroQuestoes.Name = "nupNumeroQuestoes";
            this.nupNumeroQuestoes.ReadOnly = true;
            this.nupNumeroQuestoes.Size = new System.Drawing.Size(55, 20);
            this.nupNumeroQuestoes.TabIndex = 73;
            this.nupNumeroQuestoes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupNumeroQuestoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            // 
            // txtCaminhoDestino
            // 
            this.txtCaminhoDestino.Enabled = false;
            this.txtCaminhoDestino.Location = new System.Drawing.Point(131, 182);
            this.txtCaminhoDestino.Name = "txtCaminhoDestino";
            this.txtCaminhoDestino.Size = new System.Drawing.Size(238, 20);
            this.txtCaminhoDestino.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Destino:";
            // 
            // btnCaminho
            // 
            this.btnCaminho.Location = new System.Drawing.Point(375, 179);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(29, 23);
            this.btnCaminho.TabIndex = 76;
            this.btnCaminho.Text = "...";
            this.btnCaminho.UseVisualStyleBackColor = true;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // frmCadastroTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 290);
            this.Controls.Add(this.btnCaminho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCaminhoDestino);
            this.Controls.Add(this.nupNumeroQuestoes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.cmbSerie);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.lblNumeroQuestoes);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNomeTeste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastroTeste";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Testes";
            ((System.ComponentModel.ISupportInitialize)(this.nupNumeroQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeTeste;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNumeroQuestoes;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.NumericUpDown nupNumeroQuestoes;
        private System.Windows.Forms.TextBox txtCaminhoDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCaminho;
    }
}