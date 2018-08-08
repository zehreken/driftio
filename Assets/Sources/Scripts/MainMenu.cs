using System;
using cln.Sources.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class MainMenu : Menu, IGameScoreListener
    {
        [SerializeField] private Elements _elements;
        private GameEntity _listener;

        private void Start()
        {
            Debug.Log(GetType());

            _elements.PlayButton.onClick.AddListener(OnClickPlay);
            _elements.LeaderboardButton.onClick.AddListener(OnClickLeaderboard);
            _elements.ToggleSoundButton.onClick.AddListener(OnClickToggleSound);
            _elements.LastScoreText.text = "0";
            _elements.HighScoreText.text = PlayerPrefs.GetInt("high_score").ToString();
            _elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
            _elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
        }

        private void OnEnable()
        {
            _listener = Contexts.sharedInstance.game.CreateEntity();
            _listener.AddGameScoreListener(this);
            _elements.HighScoreText.text = PlayerPrefs.GetInt("high_score").ToString();
        }

        private void OnClickPlay()
        {
            Debug.Log("on click play");
            GameObject.Find("Main").GetComponent<Main>().StartGame();

            MenuManager.Close(typeof(MainMenu));
            MenuManager.Show(typeof(GameMenu));
            Services.GetAdService().RequestBanner();
            Services.GetAdService().RequestInterstitial();
        }

        private void OnClickLeaderboard()
        {
            Services.GetGpgService().ShowLeaderboard();
        }

        private void OnClickToggleSound()
        {
            Services.GetAudioService().ToggleSound();
            _elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
            _elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
        }

        public void OnGameScore(GameEntity entity, int value)
        {
            _elements.LastScoreText.text = value.ToString();
        }

        private void OnDestroy()
        {
            _elements.PlayButton.onClick.RemoveListener(OnClickPlay);
            _elements.LeaderboardButton.onClick.RemoveListener(OnClickLeaderboard);
            _elements.ToggleSoundButton.onClick.RemoveListener(OnClickToggleSound);
        }

        [Serializable]
        private struct Elements
        {
            public TextMeshProUGUI LastScoreText;
            public TextMeshProUGUI HighScoreText;
            public Button PlayButton;
            public Button LeaderboardButton;
            public Button ToggleSoundButton;
            public GameObject[] SoundImages;
        }
    }
}