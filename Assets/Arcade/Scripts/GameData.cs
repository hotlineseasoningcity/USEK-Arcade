using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public static class GameData
    {
        public static string CurrentGameId;
        //{
        //    get {
        //        string _currID = SceneManager.GetActiveScene().name.Split('_')[0];
        //        if (_currID != CurrentGameId)
        //            CurrentGameId = _currID;
        //            return  }
        //    set { }
        //}

        public static void Set(string id, int value)
        {
            id = $"{CurrentGameId}_{id}";
            PlayerPrefs.SetInt(id, value);
        }
        public static void Set(string id, string value)
        {
            id = $"{CurrentGameId}_{id}";
            PlayerPrefs.SetString(id, value);
        }
        public static void Set(string id, float value)
        {
            id = $"{CurrentGameId}_{id}";
            PlayerPrefs.SetFloat(id, value);
        }

        public static int GetInt(string id)
        {
            id = $"{CurrentGameId}_{id}";
            int value = PlayerPrefs.GetInt(id);
            return value;
        }
        public static string GetString(string id)
        {
            id = $"{CurrentGameId}_{id}";
            string value = PlayerPrefs.GetString(id);
            return value;
        }
        public static float GetFloat(string id)
        {
            id = $"{CurrentGameId}_{id}";
            float value = PlayerPrefs.GetFloat(id);
            return value;
        }
    }
}