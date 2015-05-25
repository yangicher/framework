﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGame
{
    public class ColoredText : ActorComponent
    {
        public char[,] Text { get; set; }

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }

        public override void Update(float deltaTime)
        {
            if (Text == null)
                return;

            int width = Text.GetLength(1);
            int height = Text.GetLength(0);

            Vector3 actorPosition = Actor.WorldPosition;
            int startX = (int)(actorPosition.x - width * 0.5f);
            int startY = (int)(actorPosition.y - height * 0.5f);

            //for (int y = 0; y < height; y++)
            //{
            //    for (int x = 0; x < width; x++)
            //    {
            //        Game.Graphics.DrawPrimitive(startX + x, startY + y,
            //            new GraphicPrimitive(Text[y, x], ForegroundColor, BackgroundColor, actorPosition.z));
            //    }
            //}
        }
    }
}
