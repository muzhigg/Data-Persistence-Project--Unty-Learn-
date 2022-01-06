using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Izhguzin.DataPersistence.Menu
{
    [RequireComponent(typeof(UIDocument))]
    public class UIEventDispatcher : MonoBehaviour
    {
        [SerializeField] private List<EventItem> _events = new();

        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            foreach (EventItem eventItem in _events) root.Q(eventItem.elementId)?.RegisterCallback<ClickEvent>(evt => eventItem.events.Invoke());
        }

        [Serializable]
        private class EventItem
        {
            public string elementId;
            public UnityEvent events;
        }
    }
}