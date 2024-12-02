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
using VitApp_0._1._0.Models;
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
            FrmCreateAccount frmCreateAccount = new FrmCreateAccount();
            frmCreateAccount.ShowDialog();
            this.Close();
        }


        private void BtnLogIn_Click(object sender, EventArgs e)
        {


            string userName = TbUser.Text;
            string password = TbUserPassword.Text;

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingresa tus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método Login y verificar credenciales
            string name = TbUser.Text; // Asumiendo que txtName es el TextBox para el nombre
            string pasword = TbUserPassword.Text; // Asumiendo que txtPassword es el TextBox para la contraseña

            bool loginSuccess = LogIn.Login(name, pasword);

            if (loginSuccess)
            {
                // Si el login es exitoso, puedes cerrar el formulario de login
                this.Hide(); // Oculta el formulario de login
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

