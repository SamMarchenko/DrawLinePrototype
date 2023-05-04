using UnityEngine;
using Views;

namespace Factories
{
    public class LineFactory
    {
        private DrawLineView _lineViewPrefab;
        public LineFactory(DrawLineView drawLineView) => 
            _lineViewPrefab = drawLineView;

        public DrawLineView CreateLine(Color color)
        {
            var line = MonoBehaviour.Instantiate(_lineViewPrefab);
            line.LineRenderer.material.color = color;
            return line;
        }
    }
}