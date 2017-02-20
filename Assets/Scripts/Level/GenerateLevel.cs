using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour{

    [SerializeField]private GameObject[] levels;
    
    private void Start()
    {
        GenerateMyLevel(levels);
    }
    private void GenerateMyLevel(GameObject[] difflevel)
    {
        int randomLvl = Random.Range(0, difflevel.Length - 1);
        GameObject lvl = Instantiate(difflevel[randomLvl]);
        lvl.transform.position = new Vector2(0, 0);
        Debug.Log("Generated: " + lvl.name);
    }
}
