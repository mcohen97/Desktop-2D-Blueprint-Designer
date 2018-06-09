using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public class Constants
    {
        public static readonly DateTime NEVER = DateTime.MinValue;

        public static readonly float MAX_WALL_LENGTH = 5;

        public static Dictionary<ComponentType, float> PRICE_CATALOGUE = new Dictionary<ComponentType, float>() {
            {ComponentType.WALL, 100},
            {ComponentType.BEAM, 100},
            {ComponentType.WINDOW, 75},
            {ComponentType.DOOR, 100},
            {ComponentType.COLUMN, 50}
        };

        public static Dictionary<ComponentType, float> COST_CATALOGUE = new Dictionary<ComponentType, float>() {
            {ComponentType.WALL, 50},
            {ComponentType.BEAM, 50},
            {ComponentType.WINDOW, 50},
            {ComponentType.DOOR, 50 },
            {ComponentType.COLUMN, 25}
        };

    }
}
