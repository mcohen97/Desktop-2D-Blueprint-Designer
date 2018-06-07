using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace Logic
{
    public class Signature
    {
        private DateTime signatureDate;
        private User user;

        public Signature(User user, DateTime now)
        {
            this.user = user;
            this.signatureDate = now;
        }

        public DateTime Date { get { return signatureDate; } internal set { } }
        public User User { get { return user; } internal set { } }
    }
}
