using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Window : Opening, IDrawable {

        public float HeightAboveFloor { get; private set; }

        public Window(Point aPlace) : base(aPlace) {
            HeightAboveFloor = 1;
        }

        public override ComponentType GetComponentType() {
            return ComponentType.WINDOW;
        }

        public override float CalculatePrice() {
            return Constants.PRICE_CATALOGUE[GetComponentType()];
        }

        public override float CalculateCost() {
            return Constants.COST_CATALOGUE[GetComponentType()];
        }
    }
}
