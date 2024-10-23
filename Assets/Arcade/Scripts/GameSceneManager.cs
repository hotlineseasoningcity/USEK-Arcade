using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public class GameSceneManager: MonoBehaviour
    {

        public static void StartGame()
        {
            SceneManager.LoadScene($"{GameData.CurrentGameId}_menu");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("ArcadeMenu");
        }
    }
}
