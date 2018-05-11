using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Constants
    {
        public static readonly DateTime NEVER = DateTime.MinValue;

        public static Dictionary<ComponentType, float> priceCatalogue = new Dictionary<ComponentType, float>() {
            {ComponentType.WALL, 100 },
            {ComponentType.BEAM, 100},
            {ComponentType.WINDOW,75},
            {ComponentType.DOOR,100 }
        };

        public static Dictionary<ComponentType, float> costCatalogue = new Dictionary<ComponentType, float>() {
            {ComponentType.WALL, 50 },
            {ComponentType.BEAM, 50},
            {ComponentType.WINDOW,50},
            {ComponentType.DOOR,50 }
        };

    }
}
