namespace SharpGame.pingpong
{
    using System;
    using System.Collections.Generic;
    using SharpGame;

    public class GameField : ActorComponent
    {
        private GraphicPrimitive ViewComponent;
        private readonly ConsoleColor Color;

        public GameField(ConsoleColor Color)
        {
            this.Color = Color;
        }

        public override void Start()
        {
            this.ViewComponent = GetViewComponent(Color);
        }

        public GraphicPrimitive GetViewComponent(ConsoleColor Color)
        {
            GraphicPrimitive grPrim = new GraphicPrimitive();
            grPrim.symbol = '-';
            grPrim.backgroundColor = Color;

            return grPrim;
        }

        public override void Update(float deltaTime)
        {
            Game.Graphics.DrawPrimitive(ViewComponent, GetPositions());
        }

        private List<Position> GetPositions()
        {
            List<Position> positionsList = new List<Position>();
            Position pos = new Position();

            for (int i = 0; i < Actor.Scene.SceneWidth; i++)
            {
                for (int j = 0; j < Actor.Scene.SceneHeight; j++)
                {
                    if (i == Actor.Scene.SceneWidth / 2 && j % 2 == 0)
                    {
                        pos.x = i;
                        pos.y = j;
                        positionsList.Add(pos);
                    }
                }
            }

            return positionsList;
        }
    }
}
