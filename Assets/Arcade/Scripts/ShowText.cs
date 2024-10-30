using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Arcade
{
    public class ShowText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textMesh;

        [SerializeField]
        private float _textDelay;

        [SerializeField]
        private TextAsset _textFile;

        [SerializeField]
        [TextArea(7, 10)]
        private string _fullText;

        [SerializeField]
        private string _lineSeparator = "";

        private string[] _lines;
        private int _lineIndex;
        private bool _showingTextLine;

        void ParseText()
        {
            if (_textFile != null)
                _fullText = _textFile.text;
            _lines = _fullText.Split(_lineSeparator, System.StringSplitOptions.RemoveEmptyEntries);
            _lineIndex = 0;
        }

        IEnumerator DisplayTextLine()
        {
            if (_lineIndex < _lines.Length)
            {
                _showingTextLine = true;
                int charIndex = 0;
                _textMesh.text = _lines[_lineIndex];

                while (charIndex < _lines[_lineIndex].Length)
                {
                    charIndex++;
                    _textMesh.maxVisibleCharacters = charIndex;
                    yield return new WaitForSeconds(_textDelay);
                }
            }
            _showingTextLine = false;
        }

        void ShowFullLine()
        {
            if (_showingTextLine)
            {
                StopAllCoroutines();
                _textMesh.maxVisibleCharacters = _lines[_lineIndex].Length;
                _showingTextLine = false;
            }
        }
        void ShowNextLine()
        {
            if (!_showingTextLine)
            {
                _lineIndex++;
                StartCoroutine(DisplayTextLine());
            }
            else
            {
                ShowFullLine();
            }
        }
        void SkipToNextScene()
        {
            if (!_showingTextLine)
            {
                GameSceneManager.NextLevel();
            }
            else
            {
                ShowFullLine();
            }
        }

        private void Awake()
        {
            ParseText();
        }
        private void Start()
        {
            StartCoroutine(DisplayTextLine());
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowFullLine();
            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {
                ShowNextLine();
            }

            else if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SkipToNextScene();
            }
        }
    }
}
