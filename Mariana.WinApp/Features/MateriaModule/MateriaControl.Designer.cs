namespace Mariana.WinApp.Features.MateriaModule
{
    partial class MateriaControl
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
            this.listMaterias = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listMaterias
            // 
            this.listMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMaterias.FormattingEnabled = true;
            this.listMaterias.ItemHeight = 20;
            this.listMaterias.Location = new System.Drawing.Point(0, 0);
            this.listMaterias.Margin = new System.Windows.Forms.Padding(2);
            this.listMaterias.Name = "listMaterias";
            this.listMaterias.Size = new System.Drawing.Size(593, 360);
            this.listMaterias.Sorted = true;
            this.listMaterias.TabIndex = 3;
            // 
            // MateriaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listMaterias);
            this.Name = "MateriaControl";
            this.Size = new System.Drawing.Size(593, 360);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listMaterias;
    }
}
