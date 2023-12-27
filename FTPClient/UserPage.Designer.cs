namespace FTPClient
{
    partial class UserPage
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
            this.ViewFiles = new System.Windows.Forms.Button();
            this.ServerDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Console = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ViewFiles
            // 
            this.ViewFiles.Location = new System.Drawing.Point(318, 82);
            this.ViewFiles.Name = "ViewFiles";
            this.ViewFiles.Size = new System.Drawing.Size(113, 31);
            this.ViewFiles.TabIndex = 1;
            this.ViewFiles.Text = "ViewFiles";
            this.ViewFiles.UseVisualStyleBackColor = true;
            this.ViewFiles.Click += new System.EventHandler(this.ViewFiles_Click);
            // 
            // ServerDirectory
            // 
            this.ServerDirectory.Location = new System.Drawing.Point(48, 84);
            this.ServerDirectory.Name = "ServerDirectory";
            this.ServerDirectory.Size = new System.Drawing.Size(255, 22);
            this.ServerDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ServerDirectory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "------------------------------ViewFiles------------------------------";
            // 
            // Console
            // 
            this.Console.FormattingEnabled = true;
            this.Console.ItemHeight = 16;
            this.Console.Location = new System.Drawing.Point(48, 264);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(383, 164);
            this.Console.TabIndex = 5;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerDirectory);
            this.Controls.Add(this.ViewFiles);
            this.Name = "UserPage";
            this.Text = "UserPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ViewFiles;
        private System.Windows.Forms.TextBox ServerDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Console;
    }
}