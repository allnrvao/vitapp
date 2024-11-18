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

namespace VitApp_0._1._0.Otros_forms
{
    public partial class FrmCreateAccount : Form
    {
        User newUser = new User();
        string VerifyPassword = null;
        public FrmCreateAccount()
        {
            InitializeComponent();
           
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormCrearCuenta_Load(object sender, EventArgs e)
        {
           
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (Tbname != null && TbLastName != null && TbPassword != null && TbPhone != null && TbVerifyPassword != null)
            {

                newUser.Name = Tbname.Text;
                newUser.Password = TbPassword.Text;
                newUser.LastName = TbLastName.Text;
                newUser.BornDate = DtpBirthDate;
               VerifyPassword = TbVerifyPassword.Text;
                
                if (newUser.Password == VerifyPassword)
                {
                    this.Hide();
                    PrincipalScreen principalScreen = new PrincipalScreen();
                    principalScreen.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseñas son diferentes, vuelva a escribir.");
                }


            }
            else
            {
                MessageBox.Show("Revise que todas las casillas tengan información.");

            }
        }
    }
}
