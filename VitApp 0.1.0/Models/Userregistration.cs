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

        // Método para guardar un usuario en el archivo
        public void SaveUser1(User user)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo, true)) // 'true' para agregar sin sobrescribir
            {
                writer.WriteLine($"{user.Id},{user.Name},{user.LastName},{user.BornDate},{user.Hight},{user.Weight},{user.Phone},{user.Password},{user.VerifyPassword},{user.PhotoPath},{user.PStatusUser}");
            }
        }

        // Método para cargar usuarios desde el archivo
        public static List<User> UplaundUser()
        {
            var users = new List<User>();

            if (File.Exists(rutaArchivo)) // Verifica si el archivo existe
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) // Lee línea por línea
                    {
                        var data = line.Split(',');

                        if (data.Length == 11) // Asegúrate de que la línea tenga todos los campos
                        {
                            users.Add(new User
                            {
                                Id = int.Parse(data[0]),
                                Name = data[1],
                                LastName = data[2],
                                BornDate = DateTime.Parse(data[3]),
                                Hight = int.Parse(data[4]),
                                Weight = int.Parse(data[5]),
                                Phone = int.Parse(data[6]),
                                Password = data[7],
                                VerifyPassword = data[8],
                                PhotoPath = data[9],
                                PStatusUser = int.Parse(data[10])
                            });
                        }
                    }
                }
            }

            return users;
        }

        // Buscar un usuario por nombre
        public static User LookUser(string name)
        {
            var users = UplaundUser();
            return users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar un usuario por nombre
        public bool UpdateUser(string name, User newUser)
        {
            var users = UplaundUser();
            bool updated = false;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    users[i] = newUser;
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                SaveUser1(users); // Guardar toda la lista de usuarios nuevamente
            }

            return updated;
        }

        // Guardar toda la lista de usuarios nuevamente
        public void SaveUser1(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo, false)) // 'false' para sobrescribir el archivo
            {
                foreach (var user in users)
                {
                    writer.WriteLine($"{user.Id},{user.Name},{user.LastName},{user.BornDate},{user.Hight},{user.Weight},{user.Phone},{user.Password},{user.VerifyPassword},{user.PhotoPath},{user.PStatusUser}");
                }
            }
        }
    }
}
