using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public class GameSceneManager: MonoBehaviour
    {
        public static string CurrentGameId;

        public static void StartGame()
        {
            SceneManager.LoadScene($"{CurrentGameId}_menu");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("ArcadeMenu");
        }
    }
}
