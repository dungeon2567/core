using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReactUnity.UGUI.StateHandlers
{
    public class HoverStateHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IStateHandler
    {
        public event Action OnStateStart = default;
        public event Action OnStateEnd = default;
        
        private bool IsHovered;

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnStateStart?.Invoke();
            
            IsHovered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnStateEnd?.Invoke();
            
            IsHovered = false;
        }
        
        private void OnDisable()
        {
            if(IsHovered) {
                OnStateEnd?.Invoke();
                IsHovered = false;
            }
        }

        public void ClearListeners()
        {
            OnStateStart = null;
            OnStateEnd = null;
        }
    }
}
