using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace Logic.Domain
{
    public class Signature
    {
        private DateTime signatureDate;

        public Signature(User user, DateTime now)
        {
            ArchitectName = user.Name;
            ArchitectSurname = user.Surname;
            ArchitectUserName = user.UserName;
            signatureDate = now;
        }

        public DateTime Date { get { return signatureDate; } internal set { } }
        public string ArchitectName{ get; set; }
        public string ArchitectSurname { get; set; }
        public string ArchitectUserName { get; set; }

        public override string ToString()
        {
            return "Arquitecto: " + ArchitectName + " " + ArchitectSurname + ", Fecha: " + Date;
        }
    }
}
