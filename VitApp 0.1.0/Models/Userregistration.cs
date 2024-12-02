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
        private static string rutaArchivo = "usuarios.txt";

        public static void SaveUser1(User user)
        {
            using (StreamWriter Verificate = new StreamWriter(rutaArchivo, true))
            {
                Verificate.WriteLine($"{user.Name}|{user.LastName}|{user.Phone}|{user.BornDate}|{user.Password}{user.VerifyPassword}{user.Weight}{user.Hight}{user.PStatusUser}");
            }
        }

        public static List<User> UploadUseund()
        {
            var users= new List<User>();

            if (File.Exists(rutaArchivo))
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var data = line.Split('|');
                        if (data.Length == 9)
                        {
                            users.Add(new User
                            {
                                Name = data[0],
                                LastName = data[1],
                                Phone = int.Parse(data[2]),
                                BornDate = DateTime.Parse(data[3]),
                                Password = data[4],
                                VerifyPassword = data[5],
                                Weight = int.Parse(data[6]),
                                Hight = int.Parse(data[7]),
                                PStatusUser = int.Parse(data[8]),

                            });
                        }
                    }
                }
            }

            return users;
        }
    }
}


    
