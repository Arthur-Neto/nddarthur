namespace Mariana.WinApp.Features.TesteModule
{
    partial class FormCadastroTeste
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
            this.btnCaminho = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCaminhoDestino = new System.Windows.Forms.TextBox();
            this.nupNumeroQuestoes = new System.Windows.Forms.NumericUpDown();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblNumeroQuestoes = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNomeTeste = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumeroQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCaminho
            // 
            this.btnCaminho.Location = new System.Drawing.Point(349, 186);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(29, 23);
            this.btnCaminho.TabIndex = 91;
            this.btnCaminho.Text = "...";
            this.btnCaminho.UseVisualStyleBackColor = true;
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Destino:";
            // 
            // txtCaminhoDestino
            // 
            this.txtCaminhoDestino.Enabled = false;
            this.txtCaminhoDestino.Location = new System.Drawing.Point(105, 188);
            this.txtCaminhoDestino.Name = "txtCaminhoDestino";
            this.txtCaminhoDestino.Size = new System.Drawing.Size(238, 20);
            this.txtCaminhoDestino.TabIndex = 89;
            // 
            // nupNumeroQuestoes
            // 
            this.nupNumeroQuestoes.Location = new System.Drawing.Point(105, 162);
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
            this.nupNumeroQuestoes.TabIndex = 88;
            this.nupNumeroQuestoes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbMateria
            // 
            this.cmbMateria.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(105, 135);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(273, 21);
            this.cmbMateria.TabIndex = 87;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(21, 138);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(45, 13);
            this.lblMateria.TabIndex = 86;
            this.lblMateria.Text = "Matéria:";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.Enabled = false;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(105, 108);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(273, 21);
            this.cmbDisciplina.TabIndex = 85;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(105, 31);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(55, 20);
            this.txtId.TabIndex = 84;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(21, 34);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(19, 13);
            this.lblID.TabIndex = 83;
            this.lblID.Text = "Id:";
            // 
            // cmbSerie
            // 
            this.cmbSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(106, 82);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(272, 21);
            this.cmbSerie.TabIndex = 82;
            this.cmbSerie.SelectedIndexChanged += new System.EventHandler(this.cmbSerie_SelectedIndexChanged);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(21, 111);
            this.lblDisciplina.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lblDisciplina.TabIndex = 81;
            this.lblDisciplina.Text = "Disciplina:";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(21, 85);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 80;
            this.lblSerie.Text = "Série:";
            // 
            // lblNumeroQuestoes
            // 
            this.lblNumeroQuestoes.AutoSize = true;
            this.lblNumeroQuestoes.Location = new System.Drawing.Point(21, 167);
            this.lblNumeroQuestoes.Name = "lblNumeroQuestoes";
            this.lblNumeroQuestoes.Size = new System.Drawing.Size(73, 13);
            this.lblNumeroQuestoes.TabIndex = 79;
            this.lblNumeroQuestoes.Text = "Nº Questões :";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(105, 56);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(273, 20);
            this.txtNome.TabIndex = 78;
            // 
            // lblNomeTeste
            // 
            this.lblNomeTeste.AutoSize = true;
            this.lblNomeTeste.Location = new System.Drawing.Point(21, 59);
            this.lblNomeTeste.Name = "lblNomeTeste";
            this.lblNomeTeste.Size = new System.Drawing.Size(41, 13);
            this.lblNomeTeste.TabIndex = 77;
            this.lblNomeTeste.Text = "Nome :";
            // 
            // FormCadastroTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 293);
            this.Controls.Add(this.btnCaminho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCaminhoDestino);
            this.Controls.Add(this.nupNumeroQuestoes);
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
            this.Name = "FormCadastroTeste";
            this.Text = "Cadastro Teste";
            this.Controls.SetChildIndex(this.lblNomeTeste, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblNumeroQuestoes, 0);
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblDisciplina, 0);
            this.Controls.SetChildIndex(this.cmbSerie, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.cmbDisciplina, 0);
            this.Controls.SetChildIndex(this.lblMateria, 0);
            this.Controls.SetChildIndex(this.cmbMateria, 0);
            this.Controls.SetChildIndex(this.nupNumeroQuestoes, 0);
            this.Controls.SetChildIndex(this.txtCaminhoDestino, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnCaminho, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nupNumeroQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCaminho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCaminhoDestino;
        private System.Windows.Forms.NumericUpDown nupNumeroQuestoes;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblNumeroQuestoes;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNomeTeste;
    }
}