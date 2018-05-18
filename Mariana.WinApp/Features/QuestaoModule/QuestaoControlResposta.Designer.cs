namespace Mariana.WinApp.Features.QuestaoModule
{
    partial class QuestaoControlResposta
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxRespostas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxRespostas
            // 
            this.listBoxRespostas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRespostas.FormattingEnabled = true;
            this.listBoxRespostas.Location = new System.Drawing.Point(0, 0);
            this.listBoxRespostas.Name = "listBoxRespostas";
            this.listBoxRespostas.Size = new System.Drawing.Size(150, 150);
            this.listBoxRespostas.TabIndex = 0;
            // 
            // QuestaoControlResposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxRespostas);
            this.Name = "QuestaoControlResposta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRespostas;
    }
}
