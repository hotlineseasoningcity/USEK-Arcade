using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static string CurrentGameId;

    public static void Set(string id, int value, bool addToValue = false)
    {
        string fullId = $"{CurrentGameId}_{id}";
        PlayerPrefs.SetInt(id, addToValue? GetInt(id) + value: value);
    }
    public static void Set(string id, string value, bool addToValue = false)
    {
        string fullId = $"{CurrentGameId}_{id}";
        PlayerPrefs.SetString(id, addToValue? GetString(id) + value : value);
        }
    public static void Set(string id, float value, bool addToValue = false)
    {
        string fullId = $"{CurrentGameId}_{id}";
        PlayerPrefs.SetFloat(id, addToValue ? GetFloat(id) + value : value);
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

    public static void ResetValues(params string[] values)
    {
        string fullId = "";

        foreach (string value in values)
        {
            if (value == "Higshcore")
                continue;
            fullId = $"{CurrentGameId}_{value}";
            PlayerPrefs.DeleteKey(fullId);
        }
    }
}