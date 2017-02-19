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
            GenerateEasy();
        if (diffSelector.GetMyDifficulty == DifficultySelector.LevelDifficulty.Medium)
            GenerateMedium();
        if (diffSelector.GetMyDifficulty == DifficultySelector.LevelDifficulty.Hard)
            GenerateHard();
    }
    // UGLY
    // MAAK ER 1 FUNCTION VAN!!!
    private void GenerateEasy()
    {
        int randomLvl = Random.Range(0, easyLevels.Length - 1);
        GameObject lvl = Instantiate(easyLevels[randomLvl]);
        lvl.transform.position = new Vector2(0, 0);
        Debug.Log("Generated: " + lvl.name);
    }
    private void GenerateMedium()
    {
        int randomLvl = Random.Range(0, mediumLevels.Length - 1);
        GameObject lvl = Instantiate(mediumLevels[randomLvl]);
        lvl.transform.position = new Vector2(0, 0);
        Debug.Log("Generated: " + lvl.name);
    }

    private void GenerateHard()
    {
        int randomLvl = Random.Range(0, hardLevels.Length - 1);
        GameObject lvl = Instantiate(hardLevels[randomLvl]);
        lvl.transform.position = new Vector2(0, 0);
        Debug.Log("Generated: " + lvl.name);
    }
}
