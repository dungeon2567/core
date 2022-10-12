using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReactUnity.UGUI.EventHandlers
{
    [EventHandlerPriority(EventPriority.Discrete)]
    public class EndDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IEventHandler
    {
        public event Action<BaseEventData> OnEvent = default;

        private bool IsDragging;
        private PointerEventData EventData;

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDragging = true;
            
            EventData = eventData;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEvent?.Invoke(eventData);
            
            EventData = null;
            
            IsDragging = false;
        }
        
        private void OnDisable(){
            if(IsDragging) {
                OnEvent?.Invoke(EventData);
                
                EventData = null;
                

                IsDragging = false;
            }
        }

        private void OnDisable()
        {
            if (IsDragging)
            {
                OnEvent?.Invoke(null);

                IsDragging = false;
            }
        }

        public void ClearListeners()
        {
            OnEvent = null;
        }
    }
}
