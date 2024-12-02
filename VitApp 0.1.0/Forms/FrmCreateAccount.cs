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
using VitApp_0._1._0.Models;

namespace VitApp_0._1._0.Otros_forms
{
    public partial class FrmCreateAccount : Form
    {
        public FrmCreateAccount()
        {
            InitializeComponent();
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
            Validations validation = new Validations();

            // Crear un objeto User con los datos necesarios
            User user = new User
            {
                Name=Tbname.Text,
                LastName = TbLastName.Text,
                Phone=Convert.ToInt32(TbPhone.Text),
                Password = TbPassword.Text,
                VerifyPassword = TbVerifyPassword.Text
            };


            string password = TbPassword.Text;
            string confirmPassword = TbVerifyPassword.Text;
            string lastNam = TbLastName.Text;
            string number = TbPhone.Text;




            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Phone.ToString()) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.VerifyPassword))
            {
                MessageBox.Show("Ningun campos puede estar vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Verifica si la contraseña es igual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validar y convertir el número de teléfono
            if (int.TryParse(TbPhone.Text, out int phone))
            {
                user.Phone = phone;
            }
            else
            {
                MessageBox.Show("El campo 'Teléfono' debe contener solo números.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Userregistration.SaveUser1(user);
            MessageBox.Show("Usuario guardado correctamente"); 

            try
            {
                // Pasar el objeto User al método SaveUserValidation
                validation.SaveUserValidation(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Navegar a otro formulario
            this.Hide();
            FrmTest1 frmTest1 = new FrmTest1();
            frmTest1.ShowDialog();
            this.Close();

            Userregistration.SaveUser1(user);
            MessageBox.Show("Usuario guardado correctamente");
        }

        private void DtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
           
            }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {

        }
    }
    }


