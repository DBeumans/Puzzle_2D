using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DifficultySelector : MonoBehaviour {

    public enum LevelDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    [SerializeField]private LevelDifficulty myDifficulty;

    public LevelDifficulty GetMyDifficulty { get { return myDifficulty; } }

    public void SetMyDifficulty(string diff)
    {
        diff.ToLower();
        if (diff == null)
            return;
        if (diff == "easy")
            myDifficulty = LevelDifficulty.Easy;

        if (diff == "medium")
            myDifficulty = LevelDifficulty.Medium;

        if (diff == "hard")
            myDifficulty = LevelDifficulty.Hard;
    }


}
