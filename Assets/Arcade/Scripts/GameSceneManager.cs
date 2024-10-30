using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public class GameSceneManager
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene($"{GameData.CurrentGameId}_{sceneName}");
        }

        public static void StartGame()
        {
            LoadScene("menu");
        }

        public static void NextLevel()
        {
            string nextScene = "";
            string currentScene = SceneManager.GetActiveScene().name;
            currentScene = currentScene.Split("_")[1];
            switch (currentScene)
            {
                case "menu": nextScene = "intro";
                    break;
                case "intro": nextScene = "level1"; 
                    break;
                case "level1": nextScene = "bonus1";
                    break;
                case "bonus1": nextScene = "level2";
                    break;
                case "level2": nextScene ="bonus2";
                    break;
                case "bonus2": nextScene = "boss";
                    break;
                case "boss": nextScene = "end";
                    break;
                case "end": nextScene = "menu";
                    break;
            }

            LoadScene(nextScene);
        }

        public static void GameOver()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            currentScene = currentScene.Split("_")[1];
            if (currentScene != "gameOver")
                LoadScene("gameOver");
            else
                LoadScene("menu");
        }
    }
}