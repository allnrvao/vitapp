using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitApp_0._1._0.Clases;
using VitApp_0._1._0.Classes;
using VitApp_0._1._0.Otros_forms;
using static VitApp_0._1._0.Classes.Userregistration;

namespace VitApp_0._1._0
{
    public partial class FormLoging : Form
    {
        public FormLoging()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2ShadowForm shadowForm = new Guna.UI2.WinForms.Guna2ShadowForm();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCreateAccount crearCuenta = new FrmCreateAccount();
            crearCuenta.ShowDialog();
            this.Close();
        }

            private void TbUserPassword_TextChanged(object sender, EventArgs e)
            {

            }

        private void TbUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoging pantallaPrincipal = new FormLoging();
            pantallaPrincipal.ShowDialog();
            this.Close();
        }
    }
}
