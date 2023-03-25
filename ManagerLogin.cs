using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using library_management_system.Services;

namespace library_management_system.forms
{
    public partial class homePage_ManagerLogin : Form
    {
        homePage hmp;
        private readonly ManagerService _managerService = new ManagerService();
        public homePage_ManagerLogin(homePage homePage)
        {
            this.hmp = homePage;
            InitializeComponent();

        }
        private void logincheck()
        {
            bool isExists = _managerService.IsExistsManager(idBoxManager.Text, passBoxManager.Text);
            if(isExists)
            {
                managerPage oform2 = new managerPage(hmp);
                oform2.Show();
                passBoxManager.Clear();
                hmp.Hide();
            }
            else
            {
                managerLoginInfo.Text = "Admin: username or password incorrect";
                passBoxManager.Clear();
            }        
        }

        private void HomePageManagerLogin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.logincheck();
        }
    }
}
