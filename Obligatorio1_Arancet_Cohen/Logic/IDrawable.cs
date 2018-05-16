using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    interface IDrawable {
        //this will return an enum to be mapped and get the colour and pattern for drawing
        ComponentType GetComponentType();
    }
}
