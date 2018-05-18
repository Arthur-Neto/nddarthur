using Mariana.Dominio;
using System;

namespace Mariana.WinApp.Features.QuestaoModule
{
    partial class FormCadastroQuestao
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.groupBoxRespostas = new System.Windows.Forms.GroupBox();
            this.panelResposta = new System.Windows.Forms.Panel();
            this.btnRemoveResponse = new System.Windows.Forms.Button();
            this.btnAddResponse = new System.Windows.Forms.Button();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.ckbCorreta = new System.Windows.Forms.CheckBox();
            this.txtEnunciado = new System.Windows.Forms.TextBox();
            this.cmbBimestre = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRespostas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(81, 11);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(55, 20);
            this.txtId.TabIndex = 80;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(20, 14);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(19, 13);
            this.lblID.TabIndex = 79;
            this.lblID.Text = "Id:";
            // 
            // groupBoxRespostas
            // 
            this.groupBoxRespostas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRespostas.Controls.Add(this.panelResposta);
            this.groupBoxRespostas.Controls.Add(this.btnRemoveResponse);
            this.groupBoxRespostas.Controls.Add(this.btnAddResponse);
            this.groupBoxRespostas.Controls.Add(this.txtResposta);
            this.groupBoxRespostas.Controls.Add(this.ckbCorreta);
            this.groupBoxRespostas.Location = new System.Drawing.Point(20, 225);
            this.groupBoxRespostas.Name = "groupBoxRespostas";
            this.groupBoxRespostas.Size = new System.Drawing.Size(373, 213);
            this.groupBoxRespostas.TabIndex = 78;
            this.groupBoxRespostas.TabStop = false;
            this.groupBoxRespostas.Text = "Respostas";
            // 
            // panelResposta
            // 
            this.panelResposta.Location = new System.Drawing.Point(12, 75);
            this.panelResposta.Name = "panelResposta";
            this.panelResposta.Size = new System.Drawing.Size(355, 132);
            this.panelResposta.TabIndex = 13;
            // 
            // btnRemoveResponse
            // 
            this.btnRemoveResponse.Enabled = false;
            this.btnRemoveResponse.Location = new System.Drawing.Point(77, 19);
            this.btnRemoveResponse.Name = "btnRemoveResponse";
            this.btnRemoveResponse.Size = new System.Drawing.Size(61, 23);
            this.btnRemoveResponse.TabIndex = 12;
            this.btnRemoveResponse.Text = "Remover";
            this.btnRemoveResponse.UseVisualStyleBackColor = true;
            this.btnRemoveResponse.Click += new System.EventHandler(this.btnRemoveResponse_Click);
            // 
            // btnAddResponse
            // 
            this.btnAddResponse.Enabled = false;
            this.btnAddResponse.Location = new System.Drawing.Point(12, 19);
            this.btnAddResponse.Name = "btnAddResponse";
            this.btnAddResponse.Size = new System.Drawing.Size(59, 23);
            this.btnAddResponse.TabIndex = 11;
            this.btnAddResponse.Text = "Adicionar";
            this.btnAddResponse.UseVisualStyleBackColor = true;
            this.btnAddResponse.Click += new System.EventHandler(this.btnAddResponse_Click);
            // 
            // txtResposta
            // 
            this.txtResposta.Enabled = false;
            this.txtResposta.Location = new System.Drawing.Point(12, 48);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(270, 20);
            this.txtResposta.TabIndex = 10;
            // 
            // ckbCorreta
            // 
            this.ckbCorreta.AutoSize = true;
            this.ckbCorreta.Enabled = false;
            this.ckbCorreta.Location = new System.Drawing.Point(288, 51);
            this.ckbCorreta.Name = "ckbCorreta";
            this.ckbCorreta.Size = new System.Drawing.Size(66, 17);
            this.ckbCorreta.TabIndex = 9;
            this.ckbCorreta.Text = "Correta?";
            this.ckbCorreta.UseVisualStyleBackColor = true;
            // 
            // txtEnunciado
            // 
            this.txtEnunciado.Enabled = false;
            this.txtEnunciado.Location = new System.Drawing.Point(81, 130);
            this.txtEnunciado.Multiline = true;
            this.txtEnunciado.Name = "txtEnunciado";
            this.txtEnunciado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEnunciado.Size = new System.Drawing.Size(293, 89);
            this.txtEnunciado.TabIndex = 77;
            // 
            // cmbBimestre
            // 
            this.cmbBimestre.Enabled = false;
            this.cmbBimestre.FormattingEnabled = true;
            this.cmbBimestre.Location = new System.Drawing.Point(81, 93);
            this.cmbBimestre.Name = "cmbBimestre";
            this.cmbBimestre.Size = new System.Drawing.Size(293, 21);
            this.cmbBimestre.TabIndex = 76;
            this.cmbBimestre.SelectedIndexChanged += new System.EventHandler(this.cmbBimestre_SelectedIndexChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(81, 63);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(293, 21);
            this.cmbMateria.TabIndex = 75;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.Location = new System.Drawing.Point(81, 36);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(293, 21);
            this.cmbDisciplina.TabIndex = 74;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Enunciado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Bimestre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Matéria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Disciplina:";
            // 
            // FormCadastroQuestao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 503);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.groupBoxRespostas);
            this.Controls.Add(this.txtEnunciado);
            this.Controls.Add(this.cmbBimestre);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastroQuestao";
            this.Text = "Cadastro Questao";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbDisciplina, 0);
            this.Controls.SetChildIndex(this.cmbMateria, 0);
            this.Controls.SetChildIndex(this.cmbBimestre, 0);
            this.Controls.SetChildIndex(this.txtEnunciado, 0);
            this.Controls.SetChildIndex(this.groupBoxRespostas, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.groupBoxRespostas.ResumeLayout(false);
            this.groupBoxRespostas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox groupBoxRespostas;
        private System.Windows.Forms.Panel panelResposta;
        private System.Windows.Forms.Button btnRemoveResponse;
        private System.Windows.Forms.Button btnAddResponse;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.CheckBox ckbCorreta;
        private System.Windows.Forms.TextBox txtEnunciado;
        private System.Windows.Forms.ComboBox cmbBimestre;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}