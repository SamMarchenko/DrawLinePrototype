using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class Unit : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _pathLength;
        private const float _moveTime = 3f;
        private bool _isMoving;
        private Sequence _sequence;
        private float _speed;
        private float _currentTime = 0f;


        public List<Vector3> DrawnLinePoints = new List<Vector3>();

        public bool CanMove;
        public bool IsPointed;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;


        public void InitUnitMoving(List<Vector3> points)
        {
            DrawnLinePoints = points;
            _pathLength = BezierUtility.FindPathLength(DrawnLinePoints);


            _speed = _pathLength / _moveTime;
            Debug.Log($"{this.gameObject.name}.Length = {_pathLength}. Speed = {_speed}");


            Moving();
        }


        private void Moving()
        {
            var moveTime = _pathLength / _speed;
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(DOTween
                .To(() => 0f, t => { transform.position = BezierUtility.BezierPoint(t, DrawnLinePoints); }, 1f,
                    moveTime).SetEase(Ease.InOutSine));
            _sequence.OnComplete(() => { Debug.Log("Я добежал"); });
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