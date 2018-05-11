using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Window : Opening, IDrawable {

        public float HeightAboveFloor { get; private set; }

        public Window(Point aPlace) : base(aPlace) {
            HeightAboveFloor = 1;
        }

        public ComponentType GetComponentType() {
            return ComponentType.WINDOW;
        }

        public override float CalculatePrice() {
            return Constants.priceCatalogue[GetComponentType()];
        }

        public override float CalculateCost() {
            return Constants.costCatalogue[GetComponentType()];
        }
    }
}
