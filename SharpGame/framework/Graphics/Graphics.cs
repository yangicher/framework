using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class Graphics
    {
        private GraphicPrimitive[,] frontBuffer;
        private GraphicPrimitive[,] backBuffer;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Graphics() : this(Console.WindowWidth, Console.WindowHeight - 1)
        {
        }

        public Graphics(int width, int height)
        {
            Width = width;
            Height = height;

            frontBuffer = new GraphicPrimitive[Height, Width];
            backBuffer = new GraphicPrimitive[Height, Width];

            Console.CursorVisible = false;
        }

        public void ClearBuffer()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    frontBuffer[y, x] = new GraphicPrimitive(' ', ConsoleColor.White, ConsoleColor.Black, float.MinValue);
                }
            }
        }


        public void DrawOnScreen()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (frontBuffer[y, x] != backBuffer[y, x])
                        DrawPrimitiveOnScreen(x, y, frontBuffer[y, x]);
                }
            }
        }

        public void SwapBuffers()
        {
            var temp = frontBuffer;
            frontBuffer = backBuffer;
            backBuffer = temp;
        }

        public void DrawPrimitive(int x, int y, GraphicPrimitive primitive)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return;

            if (frontBuffer[y, x].depth < primitive.depth)
                frontBuffer[y, x] = primitive;
        }

        private void DrawPrimitiveOnScreen(int x, int y, GraphicPrimitive primitive)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = primitive.backgroundColor;
            Console.ForegroundColor = primitive.foregroundColor;

            Console.Write(primitive.symbol);
        }
    }
}
