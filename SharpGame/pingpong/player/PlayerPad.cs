namespace SharpGame.pingpong
{
    using System;
    using System.Collections.Generic;

    public class PlayerPad : ActorComponent
    {
        private readonly int Size;
        private GraphicPrimitive viewComponent;

        public PlayerPad(char Symbol, int Size, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.Size = Size;
            this.viewComponent = GetView(Symbol, foregroundColor, backgroundColor);
        }

        //public override Collider Collider
        //{
        //    get
        //    {
        //        return new Collider(Position.x, Position.x, Position.y, Position.y + Size);
        //    }
        //    set
        //    {
        //        base.Collider = value;
        //    }
        //}

        private GraphicPrimitive GetView(char Symbol, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            GraphicPrimitive grPrim = new GraphicPrimitive();

            grPrim.symbol = Symbol;
            grPrim.backgroundColor = backgroundColor;
            grPrim.foregroundColor = foregroundColor;

            return grPrim;
        }

        public override void Update(float deltaTime)
        {
            CheckOnMove();

            Game.Graphics.DrawPrimitive(viewComponent, GetPositions());
        }

        private void CheckOnMove()
        {
            if (Input.IsKeyDown(ConsoleKey.W) || Input.IsKeyDown(ConsoleKey.UpArrow))
                SetPadMove(-0.2f);
            else if (Input.IsKeyDown(ConsoleKey.S) || Input.IsKeyDown(ConsoleKey.DownArrow))
                SetPadMove(0.2f);
        }

        private void SetPadMove(float step)
        {
            float value = Actor.LocalPosition.y + step;
            if (value < 0)
                Actor.LocalPosition = new Vector3(Actor.LocalPosition.x, 0, 0);
            else if (value >= Actor.Scene.SceneHeight - Size)
                Actor.LocalPosition = new Vector3(Actor.LocalPosition.x, Actor.Scene.SceneHeight - Size, 0);
            else
                Actor.LocalPosition = new Vector3(Actor.LocalPosition.x, value, 0);
        }

        private List<Position> GetPositions()
        {
            List<Position> positionsList = new List<Position>();
            Position pos = new Position();

            int xPos = (int)Actor.LocalPosition.x;
            int yPos = (int)Actor.LocalPosition.y;

            for (int i = 0; i < Size; i++)
            {
                pos.x = xPos;
                pos.y = yPos + i;
                positionsList.Add(pos);
            }

            return positionsList;
        }
    }
}
