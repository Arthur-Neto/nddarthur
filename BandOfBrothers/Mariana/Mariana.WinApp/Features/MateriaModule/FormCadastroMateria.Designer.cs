namespace Mariana.WinApp.Features.MateriaModule
{
    partial class FormCadastroMateria
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSerie = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Nome";
            // 
            // cmbSerie
            // 
            this.cmbSerie.FormattingEnabled = true;
            this.cmbSerie.Location = new System.Drawing.Point(92, 79);
            this.cmbSerie.Name = "cmbSerie";
            this.cmbSerie.Size = new System.Drawing.Size(198, 21);
            this.cmbSerie.TabIndex = 70;
            this.cmbSerie.SelectedIndexChanged += new System.EventHandler(this.cmbSerie_SelectedIndexChanged);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(92, 29);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(63, 20);
            this.txtId.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Id:";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(92, 54);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(198, 21);
            this.cmbDisciplina.TabIndex = 67;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Disciplina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Série:";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNome.Location = new System.Drawing.Point(92, 103);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(198, 20);
            this.txtNome.TabIndex = 64;
            // 
            // FormCadastroMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 200);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSerie);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Name = "FormCadastroMateria";
            this.Text = "Cadastro Materia";
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbDisciplina, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.cmbSerie, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSerie;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
    }
}