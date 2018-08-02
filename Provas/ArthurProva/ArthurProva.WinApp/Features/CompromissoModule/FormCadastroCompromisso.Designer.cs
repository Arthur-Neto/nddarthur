namespace ArthurProva.WinApp.Features.CompromissoModule
{
    partial class FormCadastroCompromisso
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAssunto = new System.Windows.Forms.TextBox();
            this.labelLocal = new System.Windows.Forms.Label();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.checkBoxDiaInteiro = new System.Windows.Forms.CheckBox();
            this.dateTimePickerDiaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDiaFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.groupBoxContatos = new System.Windows.Forms.GroupBox();
            this.listBoxContatos = new System.Windows.Forms.ListBox();
            this.groupBoxAdicionados = new System.Windows.Forms.GroupBox();
            this.listBoxAdicionarContatoCompromisso = new System.Windows.Forms.ListBox();
            this.groupBoxContatos.SuspendLayout();
            this.groupBoxAdicionados.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assunto:";
            // 
            // textBoxAssunto
            // 
            this.textBoxAssunto.Location = new System.Drawing.Point(106, 37);
            this.textBoxAssunto.Multiline = true;
            this.textBoxAssunto.Name = "textBoxAssunto";
            this.textBoxAssunto.Size = new System.Drawing.Size(300, 61);
            this.textBoxAssunto.TabIndex = 4;
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(12, 122);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(36, 13);
            this.labelLocal.TabIndex = 5;
            this.labelLocal.Text = "Local:";
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(106, 119);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(300, 20);
            this.textBoxLocal.TabIndex = 6;
            // 
            // checkBoxDiaInteiro
            // 
            this.checkBoxDiaInteiro.AutoSize = true;
            this.checkBoxDiaInteiro.Location = new System.Drawing.Point(31, 196);
            this.checkBoxDiaInteiro.Name = "checkBoxDiaInteiro";
            this.checkBoxDiaInteiro.Size = new System.Drawing.Size(96, 17);
            this.checkBoxDiaInteiro.TabIndex = 7;
            this.checkBoxDiaInteiro.Text = "É o dia inteiro?";
            this.checkBoxDiaInteiro.UseVisualStyleBackColor = true;
            this.checkBoxDiaInteiro.CheckedChanged += new System.EventHandler(this.checkBoxDiaInteiro_CheckedChanged);
            // 
            // dateTimePickerDiaInicio
            // 
            this.dateTimePickerDiaInicio.CustomFormat = "dd/MM/yyyy HH:MM";
            this.dateTimePickerDiaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDiaInicio.Location = new System.Drawing.Point(199, 173);
            this.dateTimePickerDiaInicio.Name = "dateTimePickerDiaInicio";
            this.dateTimePickerDiaInicio.Size = new System.Drawing.Size(207, 20);
            this.dateTimePickerDiaInicio.TabIndex = 8;
            // 
            // dateTimePickerDiaFim
            // 
            this.dateTimePickerDiaFim.CustomFormat = "dd/MM/yyyy HH:MM";
            this.dateTimePickerDiaFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDiaFim.Location = new System.Drawing.Point(199, 211);
            this.dateTimePickerDiaFim.Name = "dateTimePickerDiaFim";
            this.dateTimePickerDiaFim.Size = new System.Drawing.Size(207, 20);
            this.dateTimePickerDiaFim.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fim:";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(190, 309);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(48, 34);
            this.buttonAdicionar.TabIndex = 15;
            this.buttonAdicionar.Text = ">>";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(190, 349);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(48, 34);
            this.buttonRemove.TabIndex = 16;
            this.buttonRemove.Text = "<<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // groupBoxContatos
            // 
            this.groupBoxContatos.Controls.Add(this.listBoxContatos);
            this.groupBoxContatos.Location = new System.Drawing.Point(12, 237);
            this.groupBoxContatos.Name = "groupBoxContatos";
            this.groupBoxContatos.Size = new System.Drawing.Size(172, 203);
            this.groupBoxContatos.TabIndex = 18;
            this.groupBoxContatos.TabStop = false;
            this.groupBoxContatos.Text = "Contatos";
            // 
            // listBoxContatos
            // 
            this.listBoxContatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxContatos.FormattingEnabled = true;
            this.listBoxContatos.Location = new System.Drawing.Point(3, 16);
            this.listBoxContatos.Name = "listBoxContatos";
            this.listBoxContatos.Size = new System.Drawing.Size(166, 184);
            this.listBoxContatos.TabIndex = 1;
            this.listBoxContatos.SelectedIndexChanged += new System.EventHandler(this.listBoxContatos_SelectedIndexChanged);
            // 
            // groupBoxAdicionados
            // 
            this.groupBoxAdicionados.Controls.Add(this.listBoxAdicionarContatoCompromisso);
            this.groupBoxAdicionados.Location = new System.Drawing.Point(244, 237);
            this.groupBoxAdicionados.Name = "groupBoxAdicionados";
            this.groupBoxAdicionados.Size = new System.Drawing.Size(162, 203);
            this.groupBoxAdicionados.TabIndex = 20;
            this.groupBoxAdicionados.TabStop = false;
            this.groupBoxAdicionados.Text = "Contatos a adicionar";
            // 
            // listBoxAdicionarContatoCompromisso
            // 
            this.listBoxAdicionarContatoCompromisso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAdicionarContatoCompromisso.FormattingEnabled = true;
            this.listBoxAdicionarContatoCompromisso.Location = new System.Drawing.Point(3, 16);
            this.listBoxAdicionarContatoCompromisso.Name = "listBoxAdicionarContatoCompromisso";
            this.listBoxAdicionarContatoCompromisso.Size = new System.Drawing.Size(156, 184);
            this.listBoxAdicionarContatoCompromisso.TabIndex = 0;
            this.listBoxAdicionarContatoCompromisso.SelectedIndexChanged += new System.EventHandler(this.listBoxAdicionarContatoCompromisso_SelectedIndexChanged);
            // 
            // FormCadastroCompromisso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 526);
            this.Controls.Add(this.groupBoxAdicionados);
            this.Controls.Add(this.groupBoxContatos);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerDiaFim);
            this.Controls.Add(this.dateTimePickerDiaInicio);
            this.Controls.Add(this.checkBoxDiaInteiro);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.labelLocal);
            this.Controls.Add(this.textBoxAssunto);
            this.Controls.Add(this.label2);
            this.Name = "FormCadastroCompromisso";
            this.Text = "Cadastro Compromisso";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxAssunto, 0);
            this.Controls.SetChildIndex(this.labelLocal, 0);
            this.Controls.SetChildIndex(this.textBoxLocal, 0);
            this.Controls.SetChildIndex(this.checkBoxDiaInteiro, 0);
            this.Controls.SetChildIndex(this.dateTimePickerDiaInicio, 0);
            this.Controls.SetChildIndex(this.dateTimePickerDiaFim, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.buttonAdicionar, 0);
            this.Controls.SetChildIndex(this.buttonRemove, 0);
            this.Controls.SetChildIndex(this.groupBoxContatos, 0);
            this.Controls.SetChildIndex(this.groupBoxAdicionados, 0);
            this.groupBoxContatos.ResumeLayout(false);
            this.groupBoxAdicionados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAssunto;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.CheckBox checkBoxDiaInteiro;
        private System.Windows.Forms.DateTimePicker dateTimePickerDiaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerDiaFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.GroupBox groupBoxContatos;
        private System.Windows.Forms.GroupBox groupBoxAdicionados;
        private System.Windows.Forms.ListBox listBoxAdicionarContatoCompromisso;
        private System.Windows.Forms.ListBox listBoxContatos;
    }
}