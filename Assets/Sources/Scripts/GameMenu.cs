using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class GameMenu : Menu, IGameScoreListener, IHighScoreListener
    {
        [SerializeField] private Elements _elements;
        private GameEntity _listener;

        private void OnEnable()
        {
            _listener = Contexts.sharedInstance.game.CreateEntity();
            _listener.AddGameScoreListener(this);
            _listener.AddHighScoreListener(this);
        }

        public void OnGameScore(GameEntity entity, int value)
        {
            _elements.ScoreText.text = value.ToString();
        }

        public void OnHighScore(GameEntity entity, int value)
        {
            _elements.HighScoreText.text = value.ToString();
        }

        [Serializable]
        private struct Elements
        {
            public TextMeshProUGUI ScoreText;
            public TextMeshProUGUI HighScoreText;
            public Button PauseButton;
        }
    }
}