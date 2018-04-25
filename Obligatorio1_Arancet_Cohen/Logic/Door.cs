using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Door : Opening {

        public Door(Point aPlace) : base(aPlace) {
            HeightValue = 2.20F;
            LengthValue = 0.85F;
            UnitPrice = 50;
        }
    }
}
