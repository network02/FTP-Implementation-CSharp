namespace FTP
{
    partial class Admin
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
            this.Username_Input = new System.Windows.Forms.TextBox();
            this.Password_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username_Input
            // 
            this.Username_Input.Location = new System.Drawing.Point(44, 80);
            this.Username_Input.Name = "Username_Input";
            this.Username_Input.Size = new System.Drawing.Size(242, 22);
            this.Username_Input.TabIndex = 0;
            // 
            // Password_Input
            // 
            this.Password_Input.Location = new System.Drawing.Point(44, 136);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Size = new System.Drawing.Size(242, 22);
            this.Password_Input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "---------------------------Add new User------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // AddUser
            // 
            this.AddUser.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddUser.Location = new System.Drawing.Point(80, 186);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(171, 43);
            this.AddUser.TabIndex = 5;
            this.AddUser.Text = "Add User";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 257);
            this.Controls.Add(this.AddUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.Username_Input);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username_Input;
        private System.Windows.Forms.TextBox Password_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddUser;
    }
}