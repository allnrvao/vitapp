using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VitApp_0._1._0.Models
{
    internal class AssignPhysicStatus
    {
        public int Q1;
        public int Q2;
        public int Q3;
        public int Q4;
        public int PStatus;

        public void CalculateStatus()
        {
            PStatus = Q1 + Q2 + Q3 + Q4;
        }
    }

}
