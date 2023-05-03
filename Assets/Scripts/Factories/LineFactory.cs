using UnityEngine;

namespace Scripts.Factories
{
    public class LineFactory
    {
        private DrawLine _linePrefab;
        public LineFactory(DrawLine drawLine)
        {
            _linePrefab = drawLine;
        }

        public DrawLine CreateLine(Color color)
        {
            var line = MonoBehaviour.Instantiate(_linePrefab);
            line.LineRenderer.material.color = color;
            return line;
        }
    }
}