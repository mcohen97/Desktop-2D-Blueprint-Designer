using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class LayersStructure
    {
        public Bitmap wallsLayer;
        public Bitmap beamsLayer;
        public Bitmap columnsLayer;
        public Bitmap openingLayer;
        public Bitmap gridLayer;
        public Bitmap currentLineLayer;
        public Bitmap currentPointLayer;

        public LayersStructure(Bitmap wallsLayer, Bitmap beamsLayer, Bitmap columnsLayer, Bitmap openingLayer, Bitmap gridLayer, Bitmap currentLineLayer, Bitmap currentPointLayer)
        {
            this.wallsLayer = wallsLayer;
            this.beamsLayer = beamsLayer;
            this.columnsLayer = columnsLayer;
            this.openingLayer = openingLayer;
            this.gridLayer = gridLayer;
            this.currentLineLayer = currentLineLayer;
            this.currentPointLayer = currentPointLayer;
        }

        public LayersStructure(int width, int height)
        {
            this.wallsLayer = new Bitmap(width, height);
            this.beamsLayer = new Bitmap(width, height);
            this.columnsLayer = new Bitmap(width, height);
            this.openingLayer = new Bitmap(width, height);
            this.gridLayer = new Bitmap(width, height);
            this.currentLineLayer = new Bitmap(width, height);
            this.currentPointLayer = new Bitmap(width, height);
        }
    }
}
