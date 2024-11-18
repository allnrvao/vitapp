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
        internal class RegistroUsuarios
        {
            User user = new User();
            private static string rutaArchivo = "usuarios.txt";

            public static void GuardarUsuario(User user)
            {
                using (StreamWriter Verificate = new StreamWriter(rutaArchivo, true))
                {
                    Verificate.WriteLine($"{user.Name}|{user.LastName}|{user.Phone}|{user.BornDate}|{user.Password}");
                }
            }

            public static List<User> CargarUsuarios()
            {
                var user = new List<User>();

                if (File.Exists(rutaArchivo))
                {
                    using (StreamReader sr = new StreamReader(rutaArchivo))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            var datos = linea.Split('|');
                            if (datos.Length == 5)
                            {
                                user.Add(new User
                                {
                                    Name = datos[0],
                                    LastName = datos[1],
                                    Phone = datos[4],
                                    BornDate = DateTime.Parse(datos[3]),
                                    Password = datos[4],
                                });
                            }
                        }
                    }
                }

                return user;
            }
        }
    }
}
