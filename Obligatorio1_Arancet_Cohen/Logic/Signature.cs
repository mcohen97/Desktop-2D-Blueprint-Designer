using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace Logic
{
    class Signature
    {
        private DateTime now;
        private User user;

        public Signature(User user, DateTime now)
        {
            this.user = user;
            this.now = now;
        }

        public DateTime Date { get; internal set; }
        public User User { get; internal set; }
    }
}
