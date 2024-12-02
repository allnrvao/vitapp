using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitApp_0._1._0.Clases;
using VitApp_0._1._0.Classes;
using VitApp_0._1._0.Otros_forms;

namespace VitApp_0._1._0.Models
{
    internal class LogIn
    {
        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            var user = Userregistration.UplaundUser();
            foreach (var singleUser in user) // Cambiamos el nombre en el bucle
            {
                if (singleUser.Name == "example")
                {
                    PrincipalScreen principalScreen = new PrincipalScreen();
                    principalScreen.ShowDialog();
                }
            }

        }
    }
}
