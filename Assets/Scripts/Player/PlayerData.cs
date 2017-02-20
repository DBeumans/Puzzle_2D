using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    [SerializeField]private string currentPlayer = "Player";

    public string GetCurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }
}
