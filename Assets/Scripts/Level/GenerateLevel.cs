using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour{

    [SerializeField]private GameObject[] easyLevels;
    [SerializeField]private GameObject[] mediumLevels;
    [SerializeField]private GameObject[] hardLevels;

    private DifficultySelector diffSelector;

    private void Start()
    {
        diffSelector = GetComponent<DifficultySelector>();
    }

    public void GenerateMyLevel()
    {
        if (diffSelector.GetMyDifficulty == DifficultySelector.LevelDifficulty.Easy)
            GenerateMyLevel(easyLevels);
        if (diffSelector.GetMyDifficulty == DifficultySelector.LevelDifficulty.Medium)
            GenerateMyLevel(mediumLevels);
        if (diffSelector.GetMyDifficulty == DifficultySelector.LevelDifficulty.Hard)
            GenerateMyLevel(hardLevels);
    }

    private void GenerateMyLevel(GameObject[] difflevel)
    {
        int randomLvl = Random.Range(0, difflevel.Length - 1);
        GameObject lvl = Instantiate(difflevel[randomLvl]);
        lvl.transform.position = new Vector2(0, 0);
        Debug.Log("Generated: " + lvl.name);
    }
}
