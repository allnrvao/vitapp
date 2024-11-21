using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitApp_0._1._0.Clases;

namespace VitApp_0._1._0.Classes
{
    internal class Userregistration
    {
        public static string rutaArchivo = "usuarios.txt";

        public static void GuardarUsuario(User user)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                writer.WriteLine($"{user.Name},{user.LastName},{user.Phone},{user.BornDate},{user.Password},{user.VerifyPassword}{user.PhotoPath}");
            }
        }

        public static List<User> CargarUsuarios()
        {
            var users = new List<User>();

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');

                        if (data.Length == 7) // Ajustar según los campos que tengas
                        {
                            users.Add(new User
                            {
                               
                                Name = data[0],
                                LastName = data[1],
                                BornDate = DateTime.Parse(data[3]),
                                Password = data[4],
                                VerifyPassword = data[5],
                                PhotoPath = data[6],
                                
                            });
                        }
                    }
                }
            }

            return users;
        }

        // Buscar un usuario por nombre
        public static User BuscarUsuario(string name)
        {
            var users = CargarUsuarios();
            return users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar un usuario por nombre
        public static bool ActualizarUsuario(string name, User newUser)
        {
            var users1 = CargarUsuarios();
            bool updated = false;

            for (int i = 0; i < users1.Count; i++)
            {
                if (users1[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    users1[i] = newUser;
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                SaveUser(users1); // Guardar los cambios en el archivo
            }

            return updated;
        }

        // Guardar toda la lista de usuarios nuevamente
        public static void SaveUser(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo, false))
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.Name},{user.LastName},{user.Phone},{user.BornDate},{user.Password},{user.VerifyPassword}");
                }
            }
        }
    }
}

