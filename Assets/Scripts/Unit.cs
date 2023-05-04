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
        [SerializeField] private List<Vector3> _path = new List<Vector3>();
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _pathLength;
        private const float _moveTime = 3f;
        private bool _isMoving;
        private Sequence _sequence;
        private float _speed;
        private float _currentTime = 0f;


        
        
        public bool IsPointed;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Action OnCollisionWithPlayer;
        public Action OnFinish;


        public void InitUnitMoving(List<Vector3> points)
        {
            _path = points;
            _pathLength = BezierUtility.FindPathLength(_path);


            _speed = _pathLength / _moveTime;


            Moving();
        }


        private void Moving()
        {
            var moveTime = _pathLength / _speed;
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence.Append(DOTween
                .To(() => 0f, t => { transform.position = BezierUtility.BezierPoint(t, _path); }, 1f,
                    moveTime).SetEase(Ease.InOutSine));
            _sequence.OnComplete(() => { OnFinish?.Invoke(); });
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointed = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointed = true;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.GetComponent<Unit>();
            if (target != null)
            {
                OnCollisionWithPlayer?.Invoke();
            }
        }

        public void StopMoving()
        {
            _sequence?.Kill();
        }
    }
}