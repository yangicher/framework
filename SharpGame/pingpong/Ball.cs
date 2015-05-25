namespace SharpGame.pingpong
{
    using System;
    using System.Collections.Generic;
    using SharpGame;

    public class Ball : ActorComponent
    {
        private GraphicPrimitive ViewComponent;

        private readonly char Symbol;
        private readonly ConsoleColor Color;

        public Vector3 Direction { get; set; }
        public float Speed;

        public Ball(char Symbol, ConsoleColor Color)
        {
            this.Symbol = Symbol;
            this.Color = Color;
        }

        public override void Start()
        {
            ViewComponent = GetView();
        }

        public override void Update(float deltaTime)
        {
            Actor.LocalPosition += Direction * Speed * deltaTime;

            Game.Graphics.DrawPrimitive(ViewComponent, GetPositions());
        }

        private GraphicPrimitive GetView()
        {
            GraphicPrimitive grPrim = new GraphicPrimitive();
            grPrim.symbol = Symbol;
            grPrim.foregroundColor = Color;

            return grPrim;
        }

        private List<Position> GetPositions()
        {
            List<Position> positionsList = new List<Position>();
            Position pos = new Position();

            pos.x = (int)Actor.LocalPosition.x;
            pos.y = (int)Actor.LocalPosition.y;

            positionsList.Add(pos);

            return positionsList;
        }
    }
}
