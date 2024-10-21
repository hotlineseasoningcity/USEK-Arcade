using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcade
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData")]
    public class GameData : ScriptableObject
    {
        public string GameName;
        public string GameID;
        public List<GameVariable> StartGameData;

        [System.Serializable]
        public class GameVariable
        {
            public VarType type;
            public string identifier;
            [SerializeField]
            string startValue;
            string currentValue;

            public bool Get()
            {
                if(type == VarType.Bool)
                {
                    if (currentValue == "True")
                        return true;
                    else if (currentValue == "False")
                        return false;
                }
                Debug.LogError("");
                return false;
            }

            public enum VarType
            {
                Bool,
                Int,
                Float,
                String
            }
        }
    }

}