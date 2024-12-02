using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitApp_0._1._0.Clases
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public int Hight { get; set; }
        public int Weight { get; set; }
        public int Phone {  get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
        public string PhotoPath { get; set; }
        public int PStatusUser { get; set; }
    }


}
