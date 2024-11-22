using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitApp_0._1._0.Clases;
using VitApp_0._1._0.Classes;

namespace VitApp_0._1._0.Models
{
    internal class Validations
    {
        public bool SaveUserValidation(User user)
        {
                       
            if (!long.TryParse(user.Phone.ToString(), out _))
            {
                MessageBox.Show("El número de teléfono debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    
            }
            //validar numero no es negativo
            if (user.Phone < 0)
            {
                MessageBox.Show("El número de teléfono no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.VerifyPassword))
            {
                MessageBox.Show("Ningún campo puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         
            }

            // Validar contraseñas
            if (user.Password != user.VerifyPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
            }
            if (user.Password.Length > 12 || user.Password.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener entre 5 y 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          
            }

            // Validar longitud del nombre y apellido
            if (user.Name.Length > 15)
            {
                MessageBox.Show("El nombre debe tener un máximo de 15 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       
            }
            if (user.LastName.Length > 12)
            {
                MessageBox.Show("El apellido debe tener un máximo de 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         
            }

            // Validar número de teléfono
            if (user.Phone.ToString().Length != 8)
            {
                MessageBox.Show("El número de teléfono en Nicaragua debe tener exactamente 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
   
            }


            // Guardar el usuario (asegúrate de que RegistroUsuarios esté definido)
            Userregistration userRegistration = new Userregistration();
            userRegistration.SaveUser1(user);
            MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        internal void SaveUserValidation()
        {
            
        }
    }
}
