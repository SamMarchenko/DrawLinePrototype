using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class Finish : MonoBehaviour
        , IPointerExitHandler
        , IPointerEnterHandler
    {
        public bool IsPointed;

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointed = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointed = true;
        }
    }
}