using UnityEngine;
using UnityEngine.EventSystems;

namespace Views
{
    public class FinishView : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
    {

        [SerializeField] private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public bool IsPointed;

        public void OnPointerExit(PointerEventData eventData) => 
            IsPointed = false;

        public void OnPointerEnter(PointerEventData eventData) => 
            IsPointed = true;
    }
}