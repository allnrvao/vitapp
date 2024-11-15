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
using VitApp_0._1._0.Otros_forms;

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
           FormCrearCuenta crearCuenta = new FormCrearCuenta();
            crearCuenta.ShowDialog();
            this.Close();
        }
        public static bool Login(string nombre, string contrasena)
        {
            var usuarios = RegistroUsuarios.CargarUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.Name == nombre && usuario.Password == contrasena)
                {
                    return true;
                }
            }
            return false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nombre = TbUsuario.Text;
            string contrasena = TbPasword.Text;

            if (Login(nombre, contrasena))
            {
                MessageBox.Show("Usuario válido. Bienvenido.");
            }
            else
            {
                MessageBox.Show("Usuario no encontrado o contraseña incorrecta.");
            }

            FormLoging pantallaPrincipal = new FormLoging();
            pantallaPrincipal.ShowDialog();

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
