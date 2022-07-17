using System;
using UnityEngine;
using UnityEngine.EventSystems;
using ReactUnity.UGUI.Behaviours;

namespace ReactUnity.UGUI.EventHandlers
{
    [EventHandlerPriority(EventPriority.Continuous)]
    public class PointerEnterHandler : MonoBehaviour, IPointerEnterHandler, IEventHandler
    {
        public event Action<BaseEventData> OnEvent = default;

        private ReactElement ReactEl;

        private void Start()
        {
            ReactEl = GetComponent<ReactElement>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            float scaleFactor = ReactEl?.Component?.Canvas?.scaleFactor ?? 1.0f;

            eventData.position = new Vector2(eventData.position.x / scaleFactor, eventData.position.y / scaleFactor);
            eventData.pressPosition = new Vector2(eventData.pressPosition.x / scaleFactor, eventData.pressPosition.y / scaleFactor);

            OnEvent?.Invoke(eventData);
        }

        public void ClearListeners()
        {
            OnEvent = null;
        }
    }
}
