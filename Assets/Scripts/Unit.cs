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
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _pathLength;
        private const float _moveTime = 10f;
        private bool _isMoving;
        private Sequence _sequence;
        private float _speed;
        private float _currentTime = 0f;

        
        public Vector3[] PathPoints = new Vector3[] { };
        public List<Vector3> DrawnLinePoints = new List<Vector3>();

        public bool CanMove;
        public bool IsPointed;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        

        public void InitUnitMoving(List<Vector3> points)
        {
            DrawnLinePoints = points;
            PathPoints = BezierUtility.GetBezierPointList(points.Count, DrawnLinePoints);
            _pathLength = BezierUtility.FindPathLength(PathPoints);


            _speed = _pathLength / _moveTime;


            Moving();
        }


        private void Moving()
        {
            StartCoroutine(Move());
        }


        public IEnumerator Move()
        {
            var time = _moveTime / PathPoints.Length;
            for (int i = 0; i < PathPoints.Length - 1; i++)
            {
                transform.position = Vector3.Lerp(PathPoints[i], PathPoints[i + 1], _speed * Time.deltaTime);
                transform.DOMove(PathPoints[i + 1], time * Time.deltaTime);

                yield return null;
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