namespace GeradorTestes.Cadastros.Questões
{
    partial class QuestoesUSerControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxQuestoes = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxQuestoes);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Questões Cadastradas";
            // 
            // lbxQuestoes
            // 
            this.lbxQuestoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxQuestoes.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.lbxQuestoes.FormattingEnabled = true;
            this.lbxQuestoes.ItemHeight = 17;
            this.lbxQuestoes.Location = new System.Drawing.Point(3, 28);
            this.lbxQuestoes.Name = "lbxQuestoes";
            this.lbxQuestoes.Size = new System.Drawing.Size(769, 408);
            this.lbxQuestoes.TabIndex = 1;
            // 
            // QuestoesUSerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "QuestoesUSerControl";
            this.Size = new System.Drawing.Size(775, 439);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxQuestoes;
    }
}
