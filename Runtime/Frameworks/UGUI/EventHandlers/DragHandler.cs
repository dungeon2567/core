using System;
using UnityEngine;
using UnityEngine.EventSystems;
using ReactUnity.UGUI.Behaviours;

namespace ReactUnity.UGUI.EventHandlers
{
    [EventHandlerPriority(EventPriority.Continuous)]
    public class DragHandler : MonoBehaviour, IDragHandler, IEventHandler
    {
        public event Action<BaseEventData> OnEvent = default;
        
        private ReactElement ReactEl;
         
        private void Start()
        {
            ReactEl = GetComponent<ReactElement>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            float scaleFactor = ReactEl?.Component?.Context?.RootCanvas?.scaleFactor ?? 1.0f;

            eventData.scrollDelta = new Vector2((eventData.position.x - eventData.pressPosition.x) / scaleFactor, (eventData.pressPosition.y - eventData.position.y) / scaleFactor);

            OnEvent?.Invoke(eventData);
        }

        public void ClearListeners()
        {
            OnEvent = null;
        }
    }
}
