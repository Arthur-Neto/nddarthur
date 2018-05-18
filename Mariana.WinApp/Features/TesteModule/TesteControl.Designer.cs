namespace Mariana.WinApp.Features.ExercicioModule
{
    partial class TesteControl
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
            this.listTestes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listTestes
            // 
            this.listTestes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTestes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTestes.FormattingEnabled = true;
            this.listTestes.ItemHeight = 20;
            this.listTestes.Location = new System.Drawing.Point(0, 0);
            this.listTestes.Margin = new System.Windows.Forms.Padding(2);
            this.listTestes.Name = "listTestes";
            this.listTestes.Size = new System.Drawing.Size(812, 376);
            this.listTestes.TabIndex = 3;
            // 
            // TesteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTestes);
            this.Name = "TesteControl";
            this.Size = new System.Drawing.Size(812, 376);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTestes;
    }
}
