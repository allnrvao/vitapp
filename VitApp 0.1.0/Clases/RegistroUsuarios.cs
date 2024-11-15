using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitApp_0._1._0.Clases
{
    internal class RegistroUsuarios
    {

        private static string rutaArchivo = "usuarios.txt";

        public static void GuardarUsuario(Usuario usuario)
        {
            using (StreamWriter Verificate = new StreamWriter(rutaArchivo, true))
            {
                Verificate.WriteLine($"{usuario.Name}|{usuario.LastName}|{usuario.Number}|{usuario.BornDate}|{usuario.Password}");
            }
        }

        public static List<Usuario> CargarUsuarios()
        {
            var usuarios = new List<Usuario>();

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
                            usuarios.Add(new Usuario
                            {
                                Name = datos[0], LastName = datos[1],  Number = datos[2],
                                BornDate = DateTime.Parse(datos[3]), Password = datos[4],
                            });
                        }
                    }
                }
            }

            return usuarios;
        }
    }
}
