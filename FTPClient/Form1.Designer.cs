namespace FTPClient
{
    partial class Client
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
            this.Port_Input = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.IP_Input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Username_Input
            // 
            this.Username_Input.Location = new System.Drawing.Point(39, 81);
            this.Username_Input.Name = "Username_Input";
            this.Username_Input.Size = new System.Drawing.Size(282, 22);
            this.Username_Input.TabIndex = 0;
            // 
            // Password_Input
            // 
            this.Password_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_Input.Location = new System.Drawing.Point(39, 132);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Size = new System.Drawing.Size(282, 22);
            this.Password_Input.TabIndex = 1;
            this.Password_Input.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "------------------------------USER Info------------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // Port_Input
            // 
            this.Port_Input.Location = new System.Drawing.Point(234, 204);
            this.Port_Input.Multiline = true;
            this.Port_Input.Name = "Port_Input";
            this.Port_Input.Size = new System.Drawing.Size(87, 27);
            this.Port_Input.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(106, 250);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(152, 28);
            this.Connect.TabIndex = 7;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "IP Address";
            // 
            // IP_Input
            // 
            this.IP_Input.Location = new System.Drawing.Point(41, 204);
            this.IP_Input.Multiline = true;
            this.IP_Input.Name = "IP_Input";
            this.IP_Input.Size = new System.Drawing.Size(170, 27);
            this.IP_Input.TabIndex = 8;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 293);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IP_Input);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Port_Input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.Username_Input);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username_Input;
        private System.Windows.Forms.TextBox Password_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Port_Input;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IP_Input;
    }
}

