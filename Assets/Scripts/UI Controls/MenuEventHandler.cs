using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Izhguzin.DataPersistence.Menu
{
    [RequireComponent(typeof(UIDocument))]
    public class MenuEventHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onStartButtonClickEvent = new();
        [SerializeField] private UnityEvent _onHighScoreClickEvent = new();
        [SerializeField] private UnityEvent<string> _onPlayerNameChangedEvent = new();

        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            root.Q<Button>("start").clicked += _onStartButtonClickEvent.Invoke;
            root.Q<Button>("high-score").clicked += _onHighScoreClickEvent.Invoke;
            root.Q<TextField>().RegisterValueChangedCallback(evt => _onPlayerNameChangedEvent.Invoke(evt.newValue));
        }
    }
}