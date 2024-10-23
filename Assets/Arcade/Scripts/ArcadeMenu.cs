using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Arcade
{
    [System.Serializable]
    public struct ArcadeGameInfo
    {
        [SerializeField]
        public string GameID;
        [SerializeField]
        public string GameDisplayName;
        [SerializeField]
        public Sprite GameThumbnail; 
    }

    public class ArcadeMenu : MonoBehaviour
    {
        [SerializeField]
        private ArcadeGameInfo[] _gamesInfo;
        private int _index;
        [SerializeField]
        private Color _highlightCardColor;
        [SerializeField]
        private GameObject[] _gameCard;
        [SerializeField]
        private TextMeshProUGUI[] _gameNameTexts;
        [SerializeField]
        private Image[] _gameCardImages;
        [SerializeField]
        private Image[] _gameThumbnailImage;
        private Sprite[] _gameThumbnails;
        private Color _defaultCardColor;
        private float horizontalInput;

        void LoadGamesThumbnails()
        {
            foreach(ArcadeGameInfo gameInfo in _gamesInfo)
            {

            }
        }

        void ShowGamesList()
        {
            if (_gamesInfo.Length <= 0)
            {
                Debug.LogError("No games listed");
                return;
            }
            for (int i = 0; i < _gamesInfo.Length; i++)
            {
                if (_gameNameTexts.Length > i)
                    _gameNameTexts[i].text = _gamesInfo[i].GameDisplayName;
            }
            _index = 0;

        }

        void ShowHighScoresList()
        {

        }

        //Cargar el menú del juego seleccionado
        void StartGame()
        {
            if (_gamesInfo.Length <= 0)
            {
                Debug.LogError("No games listed");
                return;
            }
            GameData.CurrentGameId = _gamesInfo[_index].GameID;
            GameSceneManager.StartGame();
        }

        void MoveIndex(int a)
        {
            _index += a;
            _index %= _gamesInfo.Length;
            for(int i = 0; i < _gameCardImages.Length; i++)
            {
                if (i == _index)
                    _gameCardImages[i].color = _highlightCardColor;
                else
                    _gameCardImages[i].color = _defaultCardColor;
            }
        }

        private void Start()
        {
            _defaultCardColor = _gameCardImages[0].color;
            ShowGamesList();
        }

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput >= 0.1f || horizontalInput <= -0.1f )
            {
                MoveIndex((int)Mathf.Sign(horizontalInput));
                horizontalInput = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
    }
}

