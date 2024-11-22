using Microsoft.Office.Interop.Excel;
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

namespace VitApp_0._1._0.Otros_forms.forms_cuestionarios
{
    public partial class FrmTest1 : Form
    {
        

        public FrmTest1()
        {
            InitializeComponent();
            
        }

        User user = new User();
        Userregistration userregistration = new Userregistration();
        private void BtnNext_Click(object sender, EventArgs e)
        {
            AssignPhysicStatus assignPhysicStatus = new AssignPhysicStatus();
            if (Btncalories1.Checked)
            {
                assignPhysicStatus.Calories = 4;
            }
            else if (Btncalories2.Checked)
            {
                assignPhysicStatus.Calories = 3;
            }
            else if (Btncalories3.Checked)
            {
                assignPhysicStatus.Calories = 2;
            }
            else if (Btncalories4.Checked) // Este condicional parece duplicado; deberías usar otro botón o corregir el nombre.
            {
                assignPhysicStatus.Calories = 1;
            }
            else
            {
                // Si ningún botón está seleccionado, mostrar un mensaje de error.
                MessageBox.Show("Debe seleccionar una opción de calorías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar peso y altura
            try
            {
                user.Weight = Convert.ToInt32(TbWeight.Text);
                user.Hight = Convert.ToInt32(TbHight.Text);

                if (user.Weight <= 0)
                {
                    MessageBox.Show("El peso no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.Hight <= 0)
                { MessageBox.Show("La altura no puede ser negativa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            catch (FormatException)
            { MessageBox.Show("Debe ingresar un valor numérico válido para el peso y la altura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            catch (OverflowException)
            { MessageBox.Show("El valor ingresado es demasiado grande o demasiado pequeño.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  return; }

 
            userregistration.SaveUser1(user);

            this.Hide();
            FormEstadoFisico formEstadoFisico = new FormEstadoFisico();
            formEstadoFisico.ShowDialog();
            this.Close();

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            user.Hight = Convert.ToInt32(TbHight.Text);
            this.Hide();
            FrmCreateAccount frmCreateAccount = new FrmCreateAccount();
            frmCreateAccount.ShowDialog();
            this.Close();
        }
    }
}
