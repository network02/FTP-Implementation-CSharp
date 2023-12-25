using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    
    public partial class Admin : Form
    {
        public string dataJson { get; private set; }
        Dictionary<string, UserInfo> users;
        public Admin()
        {
            InitializeComponent();
            

            try
            {
                string usersData= System.IO.File.ReadAllText("E:\\CPP\\FTP\\Data\\Users.json");
                users=JsonSerializer.Deserialize<Dictionary<string, UserInfo>>(usersData);
            }
            catch
            {
                users= new Dictionary<string, UserInfo>();
            }
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            if(Username_Input.Text == "" || Password_Input.Text =="")
            {
                MessageBox.Show("Invalid Entries");
                return;
            }
            UserInfo newUser = new UserInfo();
            newUser.username=Username_Input.Text;
            newUser.password=Password_Input.Text;
            this.users.Add(newUser.username, newUser);
            string usersData = JsonSerializer.Serialize(this.users);
            System.IO.File.WriteAllText("E:\\CPP\\FTP\\Data\\Users.json", usersData);
            this.dataJson = usersData;
            MessageBox.Show("New user addded");
            this.Close();
            Form1 form= new Form1();
            form.Show();
        }
    }
}
