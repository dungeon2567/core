using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReactUnity.UGUI.EventHandlers
{
    [EventHandlerPriority(EventPriority.Continuous)]
    public class PointerExitHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventHandler
    {
        public event Action<BaseEventData> OnEvent = default;
        
        private bool IsHovered;
        private PointerEventData LastEventData;

        public void OnPointerExit(PointerEventData eventData)
        {
            OnEvent?.Invoke(eventData);
            
            LastEventData = null;
            
            IsHovered = false;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            IsHovered = true;
            
            LastEventData = eventData;
        }
        
        private void OnDisable()
        {
            if(IsHovered) {
                OnEvent?.Invoke(LastEventData);
                
                IsHovered = false;
                
                LastEventData = null;
            }
        }

        public void ClearListeners()
        {
            OnEvent = null;
        }
    }
}
