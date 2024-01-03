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
            this.Console = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SeverGetFileDir = new System.Windows.Forms.TextBox();
            this.GetFileButton = new System.Windows.Forms.Button();
            this.Brows = new System.Windows.Forms.Button();
            this.ServerSendFileDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SendFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClientDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerDirectory = new System.Windows.Forms.TextBox();
            this.ViewFiles = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.NewDir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GetCurrentDirectory = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.FormattingEnabled = true;
            this.Console.ItemHeight = 16;
            this.Console.Location = new System.Drawing.Point(48, 414);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(383, 164);
            this.Console.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "------------------------------GetFiles------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "ServerDirectory";
            // 
            // SeverGetFileDir
            // 
            this.SeverGetFileDir.Location = new System.Drawing.Point(50, 212);
            this.SeverGetFileDir.Name = "SeverGetFileDir";
            this.SeverGetFileDir.Size = new System.Drawing.Size(255, 22);
            this.SeverGetFileDir.TabIndex = 7;
            // 
            // GetFileButton
            // 
            this.GetFileButton.Location = new System.Drawing.Point(320, 207);
            this.GetFileButton.Name = "GetFileButton";
            this.GetFileButton.Size = new System.Drawing.Size(113, 31);
            this.GetFileButton.TabIndex = 9;
            this.GetFileButton.Text = "Get File";
            this.GetFileButton.UseVisualStyleBackColor = true;
            this.GetFileButton.Click += new System.EventHandler(this.GetFileButton_Click);
            // 
            // Brows
            // 
            this.Brows.Location = new System.Drawing.Point(326, 79);
            this.Brows.Name = "Brows";
            this.Brows.Size = new System.Drawing.Size(113, 31);
            this.Brows.TabIndex = 12;
            this.Brows.Text = "Browse";
            this.Brows.UseVisualStyleBackColor = true;
            this.Brows.Click += new System.EventHandler(this.Brows_Click);
            // 
            // ServerSendFileDir
            // 
            this.ServerSendFileDir.Location = new System.Drawing.Point(54, 134);
            this.ServerSendFileDir.Name = "ServerSendFileDir";
            this.ServerSendFileDir.Size = new System.Drawing.Size(255, 22);
            this.ServerSendFileDir.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "------------------------------SendFiles------------------------------";
            // 
            // SendFile
            // 
            this.SendFile.Location = new System.Drawing.Point(326, 131);
            this.SendFile.Name = "SendFile";
            this.SendFile.Size = new System.Drawing.Size(113, 31);
            this.SendFile.TabIndex = 13;
            this.SendFile.Text = "Send";
            this.SendFile.UseVisualStyleBackColor = true;
            this.SendFile.Click += new System.EventHandler(this.SendFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "ServerDirectory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Path";
            // 
            // ClientDir
            // 
            this.ClientDir.Location = new System.Drawing.Point(54, 83);
            this.ClientDir.Name = "ClientDir";
            this.ClientDir.Size = new System.Drawing.Size(255, 22);
            this.ClientDir.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "------------------------------Files------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "ServerDirectory";
            // 
            // ServerDirectory
            // 
            this.ServerDirectory.Location = new System.Drawing.Point(50, 330);
            this.ServerDirectory.Name = "ServerDirectory";
            this.ServerDirectory.Size = new System.Drawing.Size(255, 22);
            this.ServerDirectory.TabIndex = 18;
            // 
            // ViewFiles
            // 
            this.ViewFiles.Location = new System.Drawing.Point(320, 286);
            this.ViewFiles.Name = "ViewFiles";
            this.ViewFiles.Size = new System.Drawing.Size(113, 31);
            this.ViewFiles.TabIndex = 17;
            this.ViewFiles.Text = "Open";
            this.ViewFiles.UseVisualStyleBackColor = true;
            this.ViewFiles.Click += new System.EventHandler(this.ViewFiles_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewDir
            // 
            this.NewDir.Location = new System.Drawing.Point(320, 365);
            this.NewDir.Name = "NewDir";
            this.NewDir.Size = new System.Drawing.Size(113, 31);
            this.NewDir.TabIndex = 22;
            this.NewDir.Text = "New Folder";
            this.NewDir.UseVisualStyleBackColor = true;
            this.NewDir.Click += new System.EventHandler(this.NewDir_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 31);
            this.button2.TabIndex = 23;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GetCurrentDirectory
            // 
            this.GetCurrentDirectory.Location = new System.Drawing.Point(50, 365);
            this.GetCurrentDirectory.Name = "GetCurrentDirectory";
            this.GetCurrentDirectory.Size = new System.Drawing.Size(255, 30);
            this.GetCurrentDirectory.TabIndex = 24;
            this.GetCurrentDirectory.Text = "Get Current Directory";
            this.GetCurrentDirectory.UseVisualStyleBackColor = true;
            this.GetCurrentDirectory.Click += new System.EventHandler(this.GetCurrentDirectory_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(12, 618);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(113, 31);
            this.QuitButton.TabIndex = 25;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 661);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.GetCurrentDirectory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NewDir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerDirectory);
            this.Controls.Add(this.ViewFiles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ClientDir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SendFile);
            this.Controls.Add(this.Brows);
            this.Controls.Add(this.ServerSendFileDir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GetFileButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SeverGetFileDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Console);
            this.Name = "UserPage";
            this.Text = "UserPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SeverGetFileDir;
        private System.Windows.Forms.Button GetFileButton;
        private System.Windows.Forms.Button Brows;
        private System.Windows.Forms.TextBox ServerSendFileDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SendFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ClientDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerDirectory;
        private System.Windows.Forms.Button ViewFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button NewDir;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button GetCurrentDirectory;
        private System.Windows.Forms.Button QuitButton;
    }
}