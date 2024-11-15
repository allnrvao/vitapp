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
using System.Xml.Linq;

namespace VitApp_0._1._0.Otros_forms
{
    public partial class FormCrearCuenta : Form
    {
        public FormCrearCuenta()
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

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Name = TbNombre.Text,
                LastName = TbApellido.Text,
                Number = TbEdad.Text,
                BornDate = DtpFechNac.Value,
                Password = TbContraseña.Text,
                VerifyPassword = TbVerificarContra.Text,

            };

            RegistroUsuarios.GuardarUsuario(usuario);
            MessageBox.Show("Usuario registrado exitosamente.");


        }

        private void DtpFechNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TbVerificarContra_TextChanged(object sender, EventArgs e)
        {
            
        }
    }

}
