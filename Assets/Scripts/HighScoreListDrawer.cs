using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Izhguzin.DataPersistence
{
    [RequireComponent(typeof(UIDocument))]
    public class HighScoreListDrawer : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;

        private void Awake()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            VisualElement listContent = root.Q("list-container");

            List<(string name, int value)> playerList = _gameSettings.GetHighScoreList();

            for (int i = 1; i < playerList.Count; i++)
            {
                (string name, int score) = playerList[i];
                listContent.Add(new Label($"{i}) {name} :: {score}"));
            }
        }
    }
}