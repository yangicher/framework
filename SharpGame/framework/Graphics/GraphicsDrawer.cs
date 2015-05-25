namespace SharpGame
{
    using System;
    using System.Collections.Generic;

    public class GraphicsDrawer
    {
        private Dictionary<GraphicPrimitive, List<Position>> BufferList;
        private Dictionary<GraphicPrimitive, List<Position>> ListForClear;

        private GraphicPrimitive EmptyCell;

        public GraphicsDrawer()
        {
            BufferList = new Dictionary<GraphicPrimitive, List<Position>>();
            ListForClear = new Dictionary<GraphicPrimitive, List<Position>>();
            EmptyCell = new GraphicPrimitive();
        }

        public void DrawPrimitive(GraphicPrimitive view, List<Position> positions)
        {
            if (BufferList.ContainsKey(view))
                CheckLayer(view, positions);
            else
                BufferList.Add(view, positions);
        }

        private void CheckLayer(GraphicPrimitive view, List<Position> positions)
        {
            List<Position> temp = new List<Position>();

            for (int i = 0; i < BufferList[view].Count; i++)
            {
                if (!positions.Contains(BufferList[view][i]))
                    temp.Add(BufferList[view][i]);
            }

            if (!ListForClear.ContainsKey(EmptyCell))
                ListForClear.Add(EmptyCell, temp);
            else
                ListForClear[EmptyCell].AddRange(temp);

            BufferList.Remove(view);
            BufferList.Add(view, positions);
        }

        public void DrawOnScreen()
        {
            DrawList(ListForClear);
            DrawList(BufferList);

            ListForClear.Clear();
        }

        private void DrawList(Dictionary<GraphicPrimitive, List<Position>> list)
        {
            foreach (KeyValuePair<GraphicPrimitive, List<Position>> item in list)
                for (int i = 0; i < item.Value.Count; i++)
                    Draw(item.Key, item.Value[i].x, item.Value[i].y);
        }

        private void Draw(GraphicPrimitive grPrim, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = grPrim.backgroundColor;
            Console.ForegroundColor = grPrim.foregroundColor;
            Console.Write(grPrim.symbol);
        }

        public void Destroy()
        {
            //buffer = null;
        }
    }
}
