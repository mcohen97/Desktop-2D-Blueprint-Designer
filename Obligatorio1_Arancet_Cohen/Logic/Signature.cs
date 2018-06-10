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
        private User signer;

        public Signature(User user, DateTime now)
        {
            this.signer = user;
            this.signatureDate = now;
        }

        public DateTime Date { get { return signatureDate; } internal set { } }
        public User Signer { get { return signer; } internal set { } }
    }
}
