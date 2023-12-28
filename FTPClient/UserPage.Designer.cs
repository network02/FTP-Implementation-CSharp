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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SeverGetFileDir = new System.Windows.Forms.TextBox();
            this.GetFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewFiles
            // 
            this.ViewFiles.Location = new System.Drawing.Point(318, 82);
            this.ViewFiles.Name = "ViewFiles";
            this.ViewFiles.Size = new System.Drawing.Size(113, 31);
            this.ViewFiles.TabIndex = 1;
            this.ViewFiles.Text = "View Files";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "------------------------------GetFiles------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "ServerDirectory";
            // 
            // SeverGetFileDir
            // 
            this.SeverGetFileDir.Location = new System.Drawing.Point(48, 176);
            this.SeverGetFileDir.Name = "SeverGetFileDir";
            this.SeverGetFileDir.Size = new System.Drawing.Size(255, 22);
            this.SeverGetFileDir.TabIndex = 7;
            // 
            // GetFileButton
            // 
            this.GetFileButton.Location = new System.Drawing.Point(318, 167);
            this.GetFileButton.Name = "GetFileButton";
            this.GetFileButton.Size = new System.Drawing.Size(113, 31);
            this.GetFileButton.TabIndex = 9;
            this.GetFileButton.Text = "Get File";
            this.GetFileButton.UseVisualStyleBackColor = true;
            this.GetFileButton.Click += new System.EventHandler(this.GetFileButton_Click);
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.GetFileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SeverGetFileDir);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SeverGetFileDir;
        private System.Windows.Forms.Button GetFileButton;
    }
}