using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitApp_0._1._0.Clases;
using VitApp_0._1._0.Classes;

internal class Validations
{
    public bool SaveUserValidation(User user)
    {
        // Validar si el número de teléfono es numérico
        if (!long.TryParse(user.Phone.ToString(), out _))
        {
            MessageBox.Show("El número de teléfono debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar si el número de teléfono es negativo
        if (user.Phone < 0)
        {
            MessageBox.Show("El número de teléfono no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar campos vacíos
        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.VerifyPassword))
        {
            MessageBox.Show("Ningún campo puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar contraseñas
        if (user.Password != user.VerifyPassword)
        {
            MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (user.Password.Length > 12 || user.Password.Length < 5)
        {
            MessageBox.Show("La contraseña debe tener entre 5 y 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar longitud del nombre y apellido
        if (user.Name.Length > 15)
        {
            MessageBox.Show("El nombre debe tener un máximo de 15 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (user.LastName.Length > 12)
        {
            MessageBox.Show("El apellido debe tener un máximo de 12 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar número de teléfono en Nicaragua (exactamente 8 dígitos)
        if (user.Phone.ToString().Length != 8)
        {
            MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;

    }
    public static bool Login(string name, string pasword)
    {
        var users = Userregistration.UploadUseund();
        foreach (var usuario in users)
        {
            if (usuario.Name == name && usuario.Password == pasword)
            {
                return true;
            }
        }
        return false;
    }
}

 