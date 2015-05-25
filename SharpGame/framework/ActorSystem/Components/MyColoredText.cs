namespace SharpGame
{
    using System;
    using System.Collections.Generic;

    public class MyColoredText : ActorComponent
    {
        private readonly char[] text;
        private static Random _random = new Random();

        public MyColoredText(String text)
        {
            this.text = text.ToCharArray();
        }

        private List<GraphicPrimitive> GetGraphicsData()
        {
            List<GraphicPrimitive> grPrimList = new List<GraphicPrimitive>();
            GraphicPrimitive grPrim = new GraphicPrimitive();

            int xPos = (int)Actor.LocalPosition.x <= 0 ? 0 : (int)Actor.LocalPosition.x;
            int yPos = (int)Actor.LocalPosition.y <= 0 ? 0 : (int)Actor.LocalPosition.y;

            for (int i = 0; i < text.Length; i++)
            {
                grPrim.symbol = text[i];
                //grPrim.x = xPos + i;
                //grPrim.y = yPos;
                grPrim.backgroundColor = GetRandomConsoleColor();
                grPrim.foregroundColor = GetRandomConsoleColor();
                grPrimList.Add(grPrim);
            }
            return grPrimList;
        }

        public override void Update(float deltaTime)
        {
            //Game.Graphics.DrawPrimitive(GetGraphicsData());
        }

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    }
}
