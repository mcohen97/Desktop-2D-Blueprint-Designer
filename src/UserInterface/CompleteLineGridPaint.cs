using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class CompleteLineGridPaint : IGridPaintStrategy
    {
        private Bitmap layer;
        private int countX;
        private int countY;
        private int margin;

        public Bitmap Layer {
            get {
                return layer;
            }

            set {
                layer = value;
            }
        }
        public int CountX {
            get {
                return countX;
            }

            set {
                countX = value;
            }
        }
        public int CountY {
            get {
                return countY;
            }

            set {
                countY = value;
            }
        }
        public int Margin {
            get {
                return margin;
            }

            set {
                margin = value;
            }
        }

        public CompleteLineGridPaint(Bitmap layer, int gridCellCountX, int gridCellCountY, int gridLinesMarginToLayerInPixels)
        {
            Layer = layer;
            CountX = gridCellCountX;
            CountY = gridCellCountY;
            Margin = gridLinesMarginToLayerInPixels;
        }

        public void PaintGrid()
        {
            using (Graphics graphics = Graphics.FromImage(Layer))
            {
                for (int i = 0; i < CountY; i++)
                {
                    DrawGridHorizontalLines(graphics, i);
                }
                for (int i = 0; i < CountX; i++)
                {
                    DrawGridVerticalLines(graphics, i);
                }
                DrawGridRightAndBottomLines(graphics);
            }
        }

        private void DrawGridHorizontalLines(Graphics graphics, int axis)
        {
            DrawHorizontalLine(graphics, axis, 0);
        }
        private void DrawGridVerticalLines(Graphics graphics, int axis)
        {
            DrawVerticalLine(graphics, axis, 0);
        }
        private void DrawGridRightAndBottomLines(Graphics graphics)
        {
            DrawHorizontalLine(graphics, CountY, -Margin);
            DrawVerticalLine(graphics, CountX, -Margin);
        }
        private void DrawHorizontalLine(Graphics graphics, int axis, int offset)
        {
            int gridCellHeight = axis * layer.Height / countY + offset;
            graphics.DrawLine(Pens.White, 0, gridCellHeight, layer.Width, gridCellHeight);
        }
        private void DrawVerticalLine(Graphics graphics, int axis, int offset)
        {
            int gridCellWidth = axis * Layer.Width / CountX + offset;
            graphics.DrawLine(Pens.White, gridCellWidth, 0, gridCellWidth, Layer.Height);
        }

        public override string ToString()
        {
            return "Complete line";
        }

        public void SetCountX(int xLines)
        {
            CountX = xLines;
        }

        public void SetCountY(int yLines)
        {
            CountY = yLines;
        }

        public void SetMargin(int marginLines)
        {
            Margin = marginLines;
        }

        public void SetLayer(Bitmap layerToDraw)
        {
            Layer = layerToDraw;
        }
    }
}
