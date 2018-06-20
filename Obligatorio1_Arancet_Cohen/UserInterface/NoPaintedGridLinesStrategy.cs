using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class NoPaintedGridLinesStrategy : IGridPaintStrategy
    {
        public NoPaintedGridLinesStrategy()
        {
        }

        public void PaintGrid()
        {
        }

        public void SetCountX(int xLines)
        {
        }

        public void SetCountY(int yLines)
        {
        }

        public void SetLayer(Bitmap layerToDraw)
        {
        }

        public void SetMargin(int marginLines)
        {
        }

        public override string ToString()
        {
            return "No lines";
        }
    }
}
