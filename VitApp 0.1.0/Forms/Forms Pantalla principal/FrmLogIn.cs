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
            FrmCreateAccount frmCreateAccount = new FrmCreateAccount();
            frmCreateAccount.ShowDialog();
            this.Close();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            var user = Userregistration.UplaundUser();
            foreach (var user in user)
            {
                if (user.Name == TbUser && user.Password == TbUserPassword)
                {
                    PrincipalScreen principalScreen = new PrincipalScreen();
                    principalScreen.ShowDialog();

                    return true;
                }

            }
            return false;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string User = TbUsuario.Text;
            string Pasword = TbPasword.Text;

            if (string.IsNullOrWhiteSpace(User) | string.IsNullOrWhiteSpace(Pasword))
            {
                MessageBox.Show("Diguita tus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Login(User, Pasword))
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado o contraseña incorrecta.");
            }
        }
    }
    
}
