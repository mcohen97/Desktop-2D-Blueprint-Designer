using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Window : Opening {

        public float HeightAboveFloor { get; private set; }

        public Window(Point aPlace) : base(aPlace) {
            HeightAboveFloor = 1;
        }
    }
}
