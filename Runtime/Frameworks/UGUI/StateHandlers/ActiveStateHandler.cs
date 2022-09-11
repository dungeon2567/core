using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReactUnity.UGUI.StateHandlers
{
    public class ActiveStateHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IStateHandler
    {
        public event Action OnStateStart = default;
        public event Action OnStateEnd = default;
        
        private bool IsDown; 
        
        private void OnDisable() {
            if(IsDown) {
                OnStateEnd?.Invoke();
                
                IsDown = false;
            }
        }

        public void ClearListeners()
        {
            OnStateStart = null;
            OnStateEnd = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnStateStart?.Invoke();
            
            IsDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnStateEnd?.Invoke();
            
            IsDown = false;
        }
    }
}
