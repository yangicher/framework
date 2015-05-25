namespace SharpGame.pingpong
{
    using System;
    using System.Collections.Generic;
    using SharpGame;

    public class Score : ActorComponent
    {
        private GraphicPrimitive ViewComponent;
        private int Count;

        public Score()
        {
            this.Count = 0;
        }

        public override void Start()
        {
            this.ViewComponent = GetViewComponent();
        }

        public GraphicPrimitive GetViewComponent()
        {
            GraphicPrimitive grPrim = new GraphicPrimitive();
            grPrim.symbol = (char)Count;

            return grPrim;
        }

        public override void Update(float deltaTime)
        {
            //Game.Graphics.DrawPrimitive(ViewComponent, GetPositions());
        }

        private List<Position> GetPositions()
        {
            List<Position> positionsList = new List<Position>();
            Position pos = new Position();
            
            //pos.x = (int)Parent.Position.x;
            //pos.y = (int)Parent.Position.y;
            positionsList.Add(pos);

            return positionsList;
        }
    }
}
