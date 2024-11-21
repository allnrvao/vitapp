using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitApp_0._1._0.Otros_forms.forms_cuestionarios
{
    public partial class FrmTest1 : Form
    {

        public FrmTest1()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormEstadoFisico formEstadoFisico = new FormEstadoFisico();
            formEstadoFisico.ShowDialog();
            this.Close();

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCreateAccount frmCreateAccount = new FrmCreateAccount();
            frmCreateAccount.ShowDialog();
            this.Close();
        }
    }
}
