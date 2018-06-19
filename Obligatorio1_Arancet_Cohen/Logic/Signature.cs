using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using ServicesExceptions;

namespace Logic.Domain
{
    public class Signature
    {
        private DateTime signatureDate;
        private User signer;

        public Signature(User user, DateTime now)
        {
            if (!user.HasPermission(Permission.CAN_SIGN_BLUEPRINT)) {
                throw new NoPermissionsException();
            }
            this.signer = user;
            this.signatureDate = now;
        }

        public DateTime Date { get { return signatureDate; } internal set { } }
        public User Signer { get { return signer; } internal set { } }
    }
}
