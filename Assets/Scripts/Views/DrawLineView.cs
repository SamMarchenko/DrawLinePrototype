using UnityEngine;

namespace Views
{
    public class DrawLineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _line;
        [SerializeField] private Vector3 _previousPos;
        [SerializeField, Range(0, 1)] private float minDistance = 0.1f;

        public LineRenderer LineRenderer => _line;

        public void Init() => 
            _line.positionCount = 1;

        public void Draw()
        {
            var currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 0;

            if (Vector3.Distance(currentPos, _previousPos) > minDistance)
            {
                if (_previousPos == transform.position)
                {
                    _line.SetPosition(0, currentPos);
                }
                else
                {
                    _line.positionCount++;
                    _line.SetPosition(_line.positionCount - 1, currentPos);
                }
                    
                _previousPos = currentPos;
            }
        }
    }
}