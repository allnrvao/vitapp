using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using System.Runtime.InteropServices;
using VitApp_0._1._0.Clases;
using VitApp_0._1._0.Otros_forms.forms_cuestionarios;
using static VitApp_0._1._0.Classes.Userregistration;
using VitApp_0._1._0.Classes;

namespace VitApp_0._1._0.Otros_forms
{
    public partial class FrmCreateAccount : Form
    {

        public FrmCreateAccount()
        {
            InitializeComponent();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoging formLogin = new FormLoging();
            formLogin.ShowDialog();
            this.Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            // Validar si el número de teléfono es numérico
            int phoneNumber;
            if (!int.TryParse(TbPhone.Text, out phoneNumber))
            {
                MessageBox.Show("El número de teléfono debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User
            {
                Name = Tbname.Text,
                LastName = TbLastName.Text,
                Phone = phoneNumber,
                BornDate = DtpBirthDate.Value,
                Password = TbPassword.Text,
                VerifyPassword = TbVerifyPassword.Text,
            };

            string password = TbPassword.Text;
            string confirmPassword = TbVerifyPassword.Text;
            string lastNam = TbLastName.Text;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(lastNam) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Ningún campo puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar contraseñas
            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (user.Password.Length > 12 || user.Password.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener entre 5 y 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud del nombre y apellido
            if (user.Name.Length > 15)
            {
                MessageBox.Show("El nombre debe tener un máximo de 15 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (user.LastName.Length > 12)
            {
                MessageBox.Show("El apellido debe tener un máximo de 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar número de teléfono
            if (phoneNumber.ToString().Length != 8)
            {
                MessageBox.Show("El número de teléfono en Nicaragua debe tener exactamente 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar el usuario (asegúrate de que RegistroUsuarios esté definido)
            Userregistration userregistration = new Userregistration();
            userregistration.SaveUser(user);
            MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navegar a otro formulario
            this.Hide();
            FrmTest1 frmTest1 = new FrmTest1();
            frmTest1.ShowDialog();
            this.Close();
        }
    }
}