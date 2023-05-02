using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class Unit : MonoBehaviour
        , IPointerExitHandler
        , IPointerEnterHandler
    {
        public bool IsPointed;

        // public void OnPointerDown(PointerEventData eventData)
        // {
        //     IsPointed = true;
        //     Debug.Log($"OnPointerDown: {IsPointed}");
        // }

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

        // public void OnPointerClick(PointerEventData eventData)
        // {
        //     Debug.Log($"OnPointerClick: {IsPointed}");
        // }
    }
}