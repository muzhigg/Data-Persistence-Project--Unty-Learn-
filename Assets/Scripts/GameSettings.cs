using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Izhguzin.DataPersistence
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public string PlayerName { get; set; } = "";

        public (string playerName, int value) HighScore
        {
            get => (PlayerPrefs.GetString("HighScore-Name", ""), PlayerPrefs.GetInt("HighScore-Value", 0));
            set
            {
                PlayerPrefs.SetInt("HighScore-Value", value.value);
                PlayerPrefs.SetString("HighScore-Name", value.playerName);
                SaveHighScoreList(value.playerName, value.value);
            }
        }

        [NotNull]
        public List<(string name, int value)> GetHighScoreList()
        {
            List<(string name, int value)> highScoreList = new();

            for (int i = 1; i < 10; i++)
            {
                string name = PlayerPrefs.GetString($"HighScore-Name-{i}", "");
                int score = PlayerPrefs.GetInt($"HighScore-Value-{i}", 0);
                Debug.Log($"{name} :: {score}");
                /*if (score != 0) */highScoreList.Add((name, score));
            }

            return highScoreList;
        }

        private void SaveHighScoreList(string currentPlayer, int value)
        {
            List<(string name, int value)> currentList = GetHighScoreList();

            (string name, int value) valueTuple = currentList.FirstOrDefault(tuple => value > tuple.value);

            int number = 1;

            foreach ((string name, int value) tuple in currentList)
            {
                if (tuple == valueTuple)
                {
                    PlayerPrefs.SetInt($"HighScore-Value-{number}", value);
                    PlayerPrefs.SetString($"HighScore-Name-{number}", currentPlayer);
                    number++;
                }

                PlayerPrefs.SetInt($"HighScore-Value-{number}", tuple.value);
                PlayerPrefs.SetString($"HighScore-Name-{number}", tuple.name);
                number++;
            }
        }
    }
}