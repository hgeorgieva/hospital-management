using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospitalmanagement
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //String username = usernameTextBox.Text.ToString();
            //String password = passwordTextBox.Text.ToString();
            //if(username == "admin" && password == "123456")
            //{
                this.Hide();
                HomeScreen homescreen = new HomeScreen();
                homescreen.Show();
           // }
          //  else
          //  {
          //      MessageBox.Show("Please enter correct username and password.");
          //  }
        }

        private void xButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
