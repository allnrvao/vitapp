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
            validation.SaveUserValidation();

            // Navegar a otro formulario
            this.Hide();
            FrmTest1 frmTest1 = new FrmTest1();
            frmTest1.ShowDialog();
            this.Close();
        }


    }
}