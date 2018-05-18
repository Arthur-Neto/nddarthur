namespace BancoWindowsApp1.Features.ClienteModule
{
    partial class ClienteControl
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
            this.listClientes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listClientes
            // 
            this.listClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClientes.FormattingEnabled = true;
            this.listClientes.Location = new System.Drawing.Point(0, 0);
            this.listClientes.Name = "listClientes";
            this.listClientes.Size = new System.Drawing.Size(150, 150);
            this.listClientes.TabIndex = 0;
            // 
            // ClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listClientes);
            this.Name = "ClienteControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listClientes;
    }
}
