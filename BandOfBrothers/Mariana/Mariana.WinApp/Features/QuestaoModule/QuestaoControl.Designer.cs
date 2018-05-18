namespace Mariana.WinApp.Features.QuestaoModule
{
    partial class QuestaoControl
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
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listQuestoes
            // 
            this.listQuestoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQuestoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 20;
            this.listQuestoes.Location = new System.Drawing.Point(0, 0);
            this.listQuestoes.Margin = new System.Windows.Forms.Padding(2);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(755, 479);
            this.listQuestoes.TabIndex = 3;
            // 
            // QuestaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listQuestoes);
            this.Name = "QuestaoControl";
            this.Size = new System.Drawing.Size(755, 479);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listQuestoes;
    }
}
