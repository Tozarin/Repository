﻿namespace MazeEscape
{
    public class Edge
    {
        private int _xFirstPoint;
        private int _yFirstPoint;
        private int _xSecondPoint;
        private int _ySecondPoint;

        public (int, int) FirstPoint => (_xFirstPoint, _yFirstPoint);
        public (int, int) SecondPoint => (_xSecondPoint, _ySecondPoint);
        public List<(int, int)> Points => new List<(int, int)> { FirstPoint, SecondPoint };

        public Edge(int xFirstPoint, int yFirstPoint, int xSecondPoint, int ySecondPoint)
        {
            _xFirstPoint = xFirstPoint;
            _yFirstPoint = yFirstPoint;
            _xSecondPoint = xSecondPoint;
            _ySecondPoint = ySecondPoint;
        }

        public Edge((int, int) firstPoint, (int, int) secondPoint)
        {
            _xFirstPoint = firstPoint.Item1;
            _yFirstPoint = firstPoint.Item2;
            _xSecondPoint = secondPoint.Item1;
            _ySecondPoint = secondPoint.Item2;
        }
            

        public Edge WithFirstPoint(int x, int y) => new Edge(x, y, _xSecondPoint, _ySecondPoint);

        public Edge WithSecondPoint(int x, int y) => new Edge(_xFirstPoint, _yFirstPoint, x, y);

        public bool IsConnectedWith(Edge edge)
            => Points.Contains(edge.FirstPoint) || Points.Contains(edge.SecondPoint);

        public bool IsSameAs(Edge edge)
            => Points.Contains(edge.FirstPoint) && Points.Contains(edge.SecondPoint);

        public (int, int) GetSamePoint(Edge edge)
        {
            if ((edge.FirstPoint == FirstPoint) || (edge.FirstPoint == SecondPoint))
                return edge.FirstPoint;
            if ((edge.SecondPoint == FirstPoint) || (edge.SecondPoint == SecondPoint))
                return edge.SecondPoint;

            throw new Exception("Edges are not connected");
        }
    }
}
