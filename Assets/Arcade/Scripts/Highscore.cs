using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Arcade
{
    public class Highscore
    {
        List<HighscoreEntry> _highscoresTable = new List<HighscoreEntry>();

        void LoadHighScores()
        {
            string gameID = GameData.CurrentGameId;
            string data = GameData.GetString("Highscores");
            string[] highscores = data.Split(';');
            for(int i = 0; i < highscores.Length-1; i++)
            {
                HighscoreEntry entry;
                entry.name = highscores[i];
                entry.score = int.Parse(highscores[i+1]);
            }
        }

        public bool CheckIfHighscore(int score)
        {
            foreach(HighscoreEntry entry in _highscoresTable)
                if (score >= entry.score)
                    return true;
            if (_highscoresTable.Count < 5)
                return true;

            return false;
        }

        public void RegisterHighscore(string name, int score)
        {
            HighscoreEntry newEntry;
            newEntry.name = name;
            newEntry.score = score;

            HighscoreEntry hs;
            _highscoresTable = _highscoresTable.OrderByDescending(hs => hs.score).Reverse().ToList();
            SaveHighscore();
        }

        string FromTableToString()
        {
            string output = "";

            foreach(HighscoreEntry entry in _highscoresTable)
                output += $"{entry.name}:{entry.score};";

            return output;
        }

        void SaveHighscore()
        {
            string highscoreData = FromTableToString();
            GameData.Set("Highscores",highscoreData);
            PlayerPrefs.Save();
        }

        struct HighscoreEntry
        {
            public string name;
            public int score;
        }
    }
}
