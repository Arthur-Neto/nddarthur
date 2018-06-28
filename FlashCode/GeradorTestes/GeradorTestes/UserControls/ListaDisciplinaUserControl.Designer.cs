namespace GeradorTestes.UserControls
{
    partial class ListaDisciplinaUserControl
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
            this.group = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // group
            // 
            this.group.Controls.Add(this.listBox);
            this.group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group.Location = new System.Drawing.Point(0, 0);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(820, 492);
            this.group.TabIndex = 1;
            this.group.TabStop = false;
            this.group.Text = "Lista de Disciplinas";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 17;
            this.listBox.Location = new System.Drawing.Point(3, 28);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(814, 461);
            this.listBox.TabIndex = 2;
            // 
            // ListaDisciplinaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group);
            this.Name = "ListaDisciplinaUserControl";
            this.Size = new System.Drawing.Size(820, 492);
            this.group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.ListBox listBox;
    }
}
