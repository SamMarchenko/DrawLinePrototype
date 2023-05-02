using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class Unit : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] private float _pathLength;
        private const float _moveTime = 4f;
        private bool _isMoving;
        private Sequence _sequence;
        
        public Vector3[] PathPoints = new Vector3[]{};
        public List<Vector3> DrawnLinePoints = new List<Vector3>();

        public bool CanMove;
        public bool IsPointed;

        public void InitUnitMoving(List<Vector3> points)
        {
            DrawnLinePoints = points;
            PathPoints = BezierUtility.GetBeizerPointList(points.Count,DrawnLinePoints);
            _pathLength = BezierUtility.FindPathLength(PathPoints);

            CanMove = true;
        }
        
        
        void Update()
        {
            if (CanMove && !_isMoving)
            {
                StartCoroutine(Move());
            }
            
        }
        

        public IEnumerator Move()
        {
            _isMoving = true;
            for (int i = 0; i < PathPoints.Length - 1; i++)
            {
                transform.position = Vector3.Lerp(PathPoints[i], PathPoints[i + 1], _moveTime/PathPoints.Length);
                yield return new WaitForSeconds(0.02f);
            }
        }
        
        

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointed = false;
            Debug.Log($"OnPointerExit: {IsPointed}");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointed = true;
            Debug.Log($"OnPointerDown: {IsPointed}");
        }
    }
}